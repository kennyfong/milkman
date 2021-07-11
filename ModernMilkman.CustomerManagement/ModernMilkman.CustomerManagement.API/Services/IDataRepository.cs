using ModernMilkman.CustomerManagement.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkman.CustomerManagement.API.Services
{
    public interface IDataRepository
    {
        public List<Customer> ReturnAllCustomers();

        public List<Customer> ReturnAllActiveCustomers();

        public void MarkCustomerInActive(int customerId);

        public void DeleteCustomer(int customerId);

        public void SetMainAddress(int customerId, int addressId);

        public void DeleteAddress(int customerId, int addressId);

        public void AddCustomer(Customer customer);
    }
}
