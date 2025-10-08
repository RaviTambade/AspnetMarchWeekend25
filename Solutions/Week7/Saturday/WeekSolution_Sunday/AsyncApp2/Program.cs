
using AsyncApp2.Helpers;




Console.WriteLine("Calling methods asynchronously");

Task task1 = Task.Run(() =>
{
    Console.WriteLine("Thread ID : " + Thread.CurrentThread.ManagedThreadId.ToString());
    Console.WriteLine("Income tas Deduction");
 
});

Task task2 = Task.Run(() =>
{
    Console.WriteLine("Thread ID : " + Thread.CurrentThread.ManagedThreadId.ToString());
    Console.WriteLine("Sales Tax deducation");
});


Task task3 = Task.Run(() =>
{
    //independent  logic as bussiness Logic 
    Console.WriteLine("Thread ID : " + Thread.CurrentThread.ManagedThreadId.ToString());
    Console.WriteLine("Property Tax deducation");
});




