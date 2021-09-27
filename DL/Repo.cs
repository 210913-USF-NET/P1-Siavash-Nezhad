using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public class Repo : IRepo
    {
        public Customer AddCustomer(Customer customer){
        {
            throw new NotImplementedException();
        }}

        public Inventory AddInventory(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public Product AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public StoreFront AddStoreFront(StoreFront store)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public List<StoreFront> GetAllStoreFronts()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int CustomerID)
        {
            throw new NotImplementedException();
        }

        public List<Inventory> GetInventory(int StoreID)
        {
            throw new NotImplementedException();
        }

        public StoreFront GetStoreFront(int StoreID)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomer(Customer customerToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}