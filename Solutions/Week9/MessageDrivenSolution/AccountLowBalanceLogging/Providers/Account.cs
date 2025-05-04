using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLowBalanceLogging.Providers
{

    public class Account
    {
        public delegate void LowBalanceEventHandler(object sender, BalanceEventArgs e);
        public event LowBalanceEventHandler LowBalance;

        public string AccountHolder { get; set; }
        public decimal Balance { get; private set; }

        public Account(string name, decimal initialBalance)
        {
            AccountHolder = name;
            Balance = initialBalance;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0) return;

            Balance -= amount;
            Console.WriteLine($"[{AccountHolder}] Withdrawn: {amount}, Balance: {Balance}");

            if (Balance < 1000)
            {
                // Fire event
                OnLowBalance(new BalanceEventArgs(AccountHolder, Balance));
            }
        }

        protected virtual void OnLowBalance(BalanceEventArgs e)
        {
           

            LowBalance?.Invoke(this, e); // Safe event call
        }
    }

}
