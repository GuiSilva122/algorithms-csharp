﻿#nullable enable
using NUnit.Framework;

public static class BankSample
{
    public static BankDbContext Database { get; } = new BankDbContext();

    public static async Task Main()
    {
        await new BankSampleTests().RunTests();

        var owner = new Owner(new Guid(), "John", "John");
        var checkingAccount = SetupAccount(owner, BankAccountType.Checking, 325);
        var savingsAccount = SetupAccount(owner, BankAccountType.Checking, 100);

        Console.WriteLine(checkingAccount != null && savingsAccount != null
                          ? "Accounts set up successfuly"
                          : "Error setting up accounts");
    }

    private static async Task<IBankAccount?> SetupAccount(Owner owner, BankAccountType accountType, decimal initialDeposit)
    {
        BankAccount? account = null;

        try
        {
            account = new BankAccount(new Guid(), owner.Id, accountType);
            await account.DepositAsync(initialDeposit);
            return account;
        }
        catch (Exception ex)
        {
            if (ex is ArgumentException)
            {
                Console.WriteLine($"WARNING: {ex.Message}");
                return account;
            }
            else
            {
                Console.WriteLine($"ERROR: ex.Message");
                return account;
            }
        }
    }
}

public class BankAccount : IBankAccount
{
    public BankAccount(Guid id, Guid ownerId, BankAccountType accountType, decimal initialBalance = 0)
    {
        this.Id = id;
        this.OwnerId = ownerId;
        this.AccountType = accountType;
        this.Balance = initialBalance;
    }

    public async Task<ITransaction> DepositAsync(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
        }

        var transaction = new Transaction(Guid.NewGuid(), this.OwnerId, this.Id, DateTime.UtcNow, amount);

        await BankSample.Database.Transactions.AddAsync(transaction);

        await BankSample.Database.SaveChangesAsync();

        this.Balance += amount;

        return transaction;
    }

    public async Task<ITransaction> WithdrawAsync(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
        }

        if (!this.AllowOverdraft && this.Balance + -amount < 0)
        {
            throw new OverdraftException(this.Balance - amount);
        }

        var transaction = new Transaction(Guid.NewGuid(), this.OwnerId, this.OwnerId, DateTime.UtcNow, amount);

        await BankSample.Database.Transactions.AddAsync(transaction);

        this.Balance -= amount;

        return transaction;
    }

    public Guid Id { get; }

    public Guid OwnerId { get; }

    public decimal Balance { get; private set; }

    public decimal InterestRate { get; private set; }

    public bool IsOverdrawn => this.Balance < 0;

    public bool AllowOverdraft { get; private set; }

    public BankAccountType AccountType { get; }
}

public class Transaction : ITransaction
{
    public Transaction(Guid id, Guid ownerId, Guid accountId, DateTime time, decimal amount)
    {
        this.Id = id;
        this.OwnerId = ownerId;
        this.AccountId = accountId;
        this.Time = time;
        this.Amount = amount;
    }

    public Guid Id { get; }

    public Guid OwnerId { get; }

    public Guid AccountId { get; }

    public DateTime Time { get; }

    public decimal Amount { get; }
}

public class Owner : IOwner
{
    public Owner(Guid id, string firstName, string lastName)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }
    public Guid Id { get; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}

public class OverdraftException : Exception
{
    public OverdraftException(decimal overdraftAmount)
    {
        this.OverdraftAmount = overdraftAmount;
    }

    public decimal OverdraftAmount { get; private set; }
}

public enum BankAccountType
{
    Checking = 0,
    Savings = 1,
}

public class BankDbContext
{
    public BankDbContext()
    {
        this.BankAccounts = new DbSet<IBankAccount>();
        this.Transactions = new DbSet<ITransaction>();
        this.Owners = new DbSet<IOwner>();
    }

    public DbSet<IBankAccount> BankAccounts { get; private set; }

    public DbSet<ITransaction> Transactions { get; private set; }

    public DbSet<IOwner> Owners { get; private set; }

    public async Task SaveChangesAsync()
    {
        // Can throw exceptions, for example if DB is locked

        await Task.Run(() => SaveChanges());
    }

    public void SaveChanges() { }
}

public class DbSet<TEntity>
{
    private IList<TEntity> entities;
    public DbSet()
    {
        entities = new List<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        await Task.Run(() => Add(entity));
    }

    public void Add(TEntity entity)
    {
        this.entities.Add(entity);
    }
}

/**************** Interfaces ****************/
public interface IBankAccount
{
    Guid Id { get; }

    Guid OwnerId { get; }

    decimal Balance { get; }

    decimal InterestRate { get; }

    BankAccountType AccountType { get; }

    bool IsOverdrawn { get; }

    bool AllowOverdraft { get; }

    Task<ITransaction> DepositAsync(decimal amount);

    Task<ITransaction> WithdrawAsync(decimal amount);
}

public interface ITransaction
{
    Guid Id { get; }

    Guid OwnerId { get; }

    Guid AccountId { get; }

    DateTime Time { get; }

    decimal Amount { get; }
}

public interface IOwner
{
    Guid Id { get; }

    string FirstName { get; }

    string LastName { get; }
}

/**************** Tests ****************/
public class BankSampleTests
{
    public async Task RunTests()
    {
        await new BankAccountTests().RunTests();
    }
}

public class BankAccountTests
{
    public async Task RunTests()
    {
        this.Initial_Balance_Test();
        this.Deposit_Invalid_Test();
        await this.Deposit_Balance_Test();
        await this.Deposit_Transaction_Test();
    }

    public void Initial_Balance_Test()
    {
        // Create a new account, balance should be 0
        Guid expectedId = Guid.NewGuid();
        Guid expectedOwnerId = Guid.NewGuid();
        BankAccountType expectedIdAccountType = BankAccountType.Savings;
        decimal expectedIdInitialBalance = 0;

        var account = new BankAccount(expectedId, expectedOwnerId, expectedIdAccountType);
        Assert.Multiple(() =>
        {
            Assert.That(account.Id, Is.EqualTo(expectedId));
            Assert.That(account.OwnerId, Is.EqualTo(expectedOwnerId));
            Assert.That(account.AccountType, Is.EqualTo(expectedIdAccountType));
            Assert.That(account.Balance, Is.EqualTo(expectedIdInitialBalance));
        });
    }
    public void Deposit_Invalid_Test()
    {
        // Create a new account, deposit an invalid amount, should throw exception
        // Using a Lambda expression
        var account = new BankAccount(Guid.NewGuid(), Guid.NewGuid(), BankAccountType.Savings);

        var exception = Assert.ThrowsAsync<ArgumentException>(async () =>
                                                              await account.DepositAsync(-10)
                                                             );
        Assert.That(exception!.Message, Does.Contain("Amount must be greater than zero."));
    }
    public async Task Deposit_Balance_Test()
    {
        // Create a new account, with a deposit of 500, balance should be 500
        decimal expectedAmount = 500;
        var account = new BankAccount(Guid.NewGuid(), Guid.NewGuid(), BankAccountType.Savings);
        await account.DepositAsync(expectedAmount);

        Assert.That(account.Balance, Is.EqualTo(expectedAmount));
    }
    public async Task Deposit_Transaction_Test()
    {
        // Create a new account, with a deposit of 500, transaction amount should be 500
        decimal expectedTransactionAmount = 500;
        var account = new BankAccount(Guid.NewGuid(), Guid.NewGuid(), BankAccountType.Savings);
        var transaction = await account.DepositAsync(expectedTransactionAmount);

        Assert.That(transaction.Amount, Is.EqualTo(expectedTransactionAmount));
    }
}