using AccountLowBalanceLogging.Providers;
using AccountLowBalanceLogging.Consumers;

var acc = new Account("Abhay Navale", 20000);
var email = new EmailNotifier();
var logger = new LogService();

// Subscribing to the event
acc.LowBalance += email.SendLowBalanceAlert;
acc.LowBalance += logger.LogLowBalance;

// Perform withdrawals
acc.Withdraw(500);   // Balance = 1500
acc.Withdraw(600);   // Balance = 900 → triggers event
acc.Withdraw(200);   // Balance = 700 → triggers again