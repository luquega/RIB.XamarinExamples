using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RIB.XamarinExamples.Models;

namespace RIB.XamarinExamples.Services
{
    public class MyDataService : IDataService
    {
        public Task<List<Customer>> GetCustomers()
        {
            var list = new List<Customer>();
            return Task.Run(async () =>
            {
                await Task.Delay(100);

                list.Add(new Customer
                {
                    Id = 123,
                    Name = "Rick",
                    DateCreated = DateTime.Now.AddDays(-1),
                    LicenseId = "01987944"
                });

                list.Add(new Customer
                {
                    Id = 456,
                    Name = "John",
                    DateCreated = DateTime.Now.AddDays(-10),
                    LicenseId = "01987943"
                });

                list.Add(new Customer
                {
                    Id = 789,
                    Name = "Lee",
                    DateCreated = DateTime.Now.AddDays(-19),
                    LicenseId = "01987942"
                });

                list.Add(new Customer
                {
                    Id = 1011,
                    Name = "Brad",
                    DateCreated = DateTime.Now.AddDays(0),
                    LicenseId = "01187941"
                });

                return list;
            });
        }
    }

    public interface IDataService
    {
        Task<List<Customer>> GetCustomers();
    }
}
