using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using 

namespace AccountLowBalanceLogging.Consumers
{
    public class EmailNotifier
    {
        public void SendLowBalanceAlert(object sender, BalanceEventArgs e)
        {
            Console.WriteLine($"📧 Email to {e.AccountHolder}: Your balance is low: {e.CurrentBalance}");
        }
    }
}
