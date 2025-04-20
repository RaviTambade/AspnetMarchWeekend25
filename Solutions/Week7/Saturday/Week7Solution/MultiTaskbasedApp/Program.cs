//Entry point Code

using MultiTaskbasedApp.BusinessOperations;

Thread currentThread = Thread.CurrentThread;
int threadId = currentThread.ManagedThreadId;
Console.WriteLine($"Thread ID: {threadId}");
Console.WriteLine("Hello, World!");

TaskManager.ExecuteMultipleTasks(new List<string> { "Attend Session", "Read Notes",
                                                    "Perform Handson",
                                                    "Apply concepts in project" });
Console.WriteLine("All tasks completed.");

