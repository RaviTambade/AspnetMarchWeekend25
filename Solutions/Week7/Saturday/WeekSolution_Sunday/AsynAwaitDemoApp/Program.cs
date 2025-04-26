//System.Threading.Thread.Sleep(10000); // Simulate some work being done
/*using System.Threading.Tasks;
Console.WriteLine("Welcome to Transflower!....");
Task.Delay(10000).Wait();
Console.WriteLine("Hello, World!");
Console.WriteLine("Press any key to exit...");
*/

using AsynAwaitDemoApp.Entities;
using AsynAwaitDemoApp.Helpers;


//Invoking asynchronous methods


// Example usage of GetAdharID
string panCardId = "ABZPT0595R";
string adharId = await TaxDeductionManager.GetAdharID(panCardId);
Console.WriteLine($"Adhar ID for PAN card {panCardId}: {adharId}");

decimal incomeTax = await TaxDeductionManager.CalculateIncomeTax(750000);
Console.WriteLine($"Income Tax: {incomeTax}");

List<Product> allProducts = await TaxDeductionManager.GetAllAvailableProducts();

Console.WriteLine("Available Products:");
foreach (var product in allProducts)
{
    Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}, Category: {product.Category}, Description: {product.Description}");
}

string  message = await TaxDeductionManager.ParallelBackgroundTasks();
Console.WriteLine(message);



/*
 Task uses;
1. Thread pool threds (by defualt)
2. Thread pool threads are managed by CLR
3. Thread pool threads are not blocked
4. Thread pool threads are not blocked by the main thread
5. Thread pool threads are not blocked by the UI thread


Task uses:
    1.Synchronization context
    2. Synchronization context is used to manage the execution of tasks
    3. state machine ( async/await)



//.net frameowrk 4.5
// WPF, WCF, WIF and WF
// WPF: Windows Presentation Foundation
// WCF: Windows Communication Foundation
// WIF: Windows Identity Foundation

// WF: Windows Workflow Foundation (BPM)
//BPM: Business Process Management
//BPM is applied into Bussiness Applications using concept called workflow
//Workflow is a sequence of steps that are followed to complete a task

//Workflow are of two types:
//1. Sequential Workflow
//2. State Machine Workflow





















 
 
 
 */