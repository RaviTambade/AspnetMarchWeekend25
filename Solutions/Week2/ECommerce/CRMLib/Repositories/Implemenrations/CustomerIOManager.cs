﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using CRMLib.Repositories.Interfaces;
using CRMLib.Entities;

namespace CRMLib.Repositories.Implemenrations
{
    //Persistence Manager
    //Data Access Layer
    internal class CustomerIOManager: IRepoManager
    {
        public CustomerIOManager() { }

        public List<Customer> ReadCustomers()
        {
            //Deserialize customers
            //read customers from file
            List<Customer> customers = new List<Customer>();
            string filePath = @"d:/tryout/customers.json";
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                customers = JsonSerializer.Deserialize<List<Customer>>(jsonString);
            }
            return customers;
        }

        public void WriteCustomers(List<Customer> customers)
        {
            //Serialize customers
            //write customers to file
            string jsonString = JsonSerializer.Serialize(customers);
            string filePath = @"d:/tryout/customers.json";
            File.WriteAllText(filePath, jsonString);
        }
    }
}
