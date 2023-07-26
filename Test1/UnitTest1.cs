using NUnit.Framework;
using System.Threading.Tasks;

namespace Test1
{
    public class BankAccountTests
    {
        public async Task RunTests()
        {
            this.Initial_Balance_Test();
            this.Deposit_Invalid_Test();
            this.Deposit_Balance_Test();
            this.Deposit_Transaction_Test();
        }

        public async void Initial_Balance_Test()
        {
            // Create a new account, balance should be 0

            Assert.IsTrue(true);
        }

        public void Deposit_Invalid_Test()
        {
            // Create a new account, deposit an invalid amount, should throw exception

            Assert.IsTrue(true);
        }

        public async void Deposit_Balance_Test()
        {
            // Create a new account, with a deposit of 500, balance should be 500

            Assert.IsTrue(true);
        }

        public async void Deposit_Transaction_Test()
        {
            // Create a new account, with a deposit of 500, transaction amount should be 500

            Assert.IsTrue(true);
        }
    }
}