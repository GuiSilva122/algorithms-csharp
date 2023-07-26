using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class DomainTests
    {
        [Test]
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

        [Test]
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

        [Test]
        public async Task Deposit_Balance_Test()
        {
            // Create a new account, with a deposit of 500, balance should be 500
            decimal expectedAmount = 500;
            var account = new BankAccount(Guid.NewGuid(), Guid.NewGuid(), BankAccountType.Savings);
            await account.DepositAsync(expectedAmount);

            Assert.That(account.Balance, Is.EqualTo(expectedAmount));
        }

        [Test]
        public async Task Deposit_Transaction_Test()
        {
            // Create a new account, with a deposit of 500, transaction amount should be 500
            decimal expectedTransactionAmount = 500;
            var account = new BankAccount(Guid.NewGuid(), Guid.NewGuid(), BankAccountType.Savings);
            var transaction = await account.DepositAsync(expectedTransactionAmount);

            Assert.That(transaction.Amount, Is.EqualTo(expectedTransactionAmount));
        }
    }
}