using Models;
using System.Collections.Generic;

namespace DL
{
    public interface IRepo
    {
        List<Customer> GetAllCustomers();
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(Customer customerToUpdate);
    }
}