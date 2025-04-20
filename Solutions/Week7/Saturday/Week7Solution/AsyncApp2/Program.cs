
using AsyncApp2.Helpers;
Console.WriteLine("Primary Thread:  "+ Thread.CurrentThread.ManagedThreadId.ToString());

Action sayWelcome = static delegate ()
{
    int count =786;
    count++;
    Console.WriteLine("Method is SayWelcome");
    Console.WriteLine("Thread ID : "+Thread.CurrentThread.ManagedThreadId.ToString());
    Console.WriteLine($"Count is {count}");
    Console.WriteLine("Welcome to C#");
};


//task 2:
Action sayHello = static () =>
{
    int count = 745;
    count ++;
    Console.WriteLine("Method is SayHello");
    Console.WriteLine("Thread ID : " + Thread.CurrentThread.ManagedThreadId.ToString());
    Console.WriteLine($"Count is {count}");
    Console.WriteLine("Hello World");
};


//blocking call

Console.WriteLine("Calling methods synchronously");
sayWelcome();
sayHello();

//Task

//Non-Blocking call

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




