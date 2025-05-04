
using BasicProviderConsumerApp;

Account account = new Account(56000);
BankEventReciver bankEventReciver = new BankEventReciver();

account.lowBalance += bankEventReciver.ApplyPenalty; //subscribe to the event

//Subcription
//consumer and provider


account.withdraw(49000);  //invoke operation





