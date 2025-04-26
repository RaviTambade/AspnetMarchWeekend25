using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsynAwaitDemoApp.Entities;
namespace AsynAwaitDemoApp.Helpers
{
    public static class TaxDeductionManager
    {

        //NonBlocking Call
        //Async/Await

        //Asynchronous method to calculate income tax

        public async static Task<string> GetAdharID(string pancardId)
        {
            // Simulate a long-running operation
            await Task.Delay(10000);
            // Perform some operation to get Adhar ID based on PAN card ID

            //feth secure rest api with secrete key by passing input as PAN card Number
            //verify PAN card number
            //verify Adhar card number
            //get adhar card number from secure rest api
            string adharId = "1234-5678-9101"; // Example Adhar ID
            return adharId;
        } 
        public async static Task<decimal> CalculateIncomeTax(decimal income)
        {
            //simulate a long-running calculation
            await Task.Delay(10000);
            //checking PAN card verification of tax payer
            //veifying Adhar card identity
            //verify ITR filing details
            //After all these verifications, we will calculate the tax
            decimal taxRate = 0.2m; // Example tax rate
            return income * taxRate;
        }

        public async static Task<List<Product>> GetAllAvailableProducts()
        {
            // Simulate a long-running operation
            //fetch data from inventory mangement service which would tak 10 seconds delay
            //fetch data from inventory management service
            await Task.Delay(10000);
            // Perform some operation to get all available products

            List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Sony Bravia", Price = 10.99m, Quantity = 100, Category = "Electronics", Description = "Description of Product 1" },
                new Product { Id = 2, Name = "Cotton King Shirt", Price = 20.99m, Quantity = 50, Category = "Clothing", Description = "Description of Product 2" },
                new Product { Id = 3, Name = "Sapiands", Price = 30.99m, Quantity = 25, Category = "Books", Description = "Description of Product 3" }
            };
            return products;
        }


        public async static  Task<string> ParallelBackgroundTasks()
        {
            Task task1 = Task.Run(() => DoWork("Printing salary slips"));
            Task task2 = Task.Run(() => DoWork("sending auto generated emails to registered email ids"));
            Task task3 = Task.Run(() => DoWork("sending notification to registered mobile numbers using SMS service"));
            Task task4 = Task.Run(() => DoWork("sending notification to registered mobile numbers using Whatsapp service"));
            await  Task.WhenAll(task1, task2, task3, task4);
            return "All background tasks completed.";
        }


        private static void DoWork(string taskName)
        {
            // Simulate some work
            Console.WriteLine($"Doing work: {taskName}");
            Thread.Sleep(5000); // Simulate a delay
            Console.WriteLine($"Work completed: {taskName}");
        }

        //Blocking Calls

        public static decimal CalculateSalesTax(decimal amount)
        {
            decimal salesTaxRate = 0.07m; // Example sales tax rate
            return amount * salesTaxRate;
        }
        public static decimal CalculatePropertyTax(decimal propertyValue)
        {
            decimal propertyTaxRate = 0.015m; // Example property tax rate
            return propertyValue * propertyTaxRate;
        }

        public static decimal CalculateCapitalGainsTax(decimal capitalGains)
        {
            decimal capitalGainsTaxRate = 0.15m; // Example capital gains tax rate
            return capitalGains * capitalGainsTaxRate;
        }
        public static decimal CalculateCorporateTax(decimal corporateIncome)
        {
            decimal corporateTaxRate = 0.25m; // Example corporate tax rate
            return corporateIncome * corporateTaxRate;
        }

        public static decimal CalculateWealthTax(decimal netWorth)
        {
            decimal wealthTaxRate = 0.01m; // Example wealth tax rate
            return netWorth * wealthTaxRate;
        }


    }
}
