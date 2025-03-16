using CRMLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLib.Repositories.Interfaces
{
    public  interface IRepoManager
    {
        List<Customer> ReadCustomers();
        void WriteCustomers(List<Customer> customers);
    }
}
