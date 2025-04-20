using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTaskbasedApp.BusinessOperations
{
    public  class TaskManager
    {

        public static  void  ExecuteTask(string taskName)
        {
            Thread secondaryThread = new Thread(() =>
            {
                Thread currentThread = Thread.CurrentThread;
                int threadId = currentThread.ManagedThreadId;
                Console.WriteLine($"Thread ID: {threadId}");

                Console.WriteLine($"Executing task: {taskName}");
                // Simulate task execution
                System.Threading.Thread.Sleep(5000);
                Console.WriteLine($"Task {taskName} completed.");
            });
            secondaryThread.Start();    
        }
        public static void ExecuteMultipleTasks(List<string> tasks)
        {
            foreach (var task in tasks)
            {
                ExecuteTask(task);
            }
        }
    }
}
