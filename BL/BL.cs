using System;
using Models;
using System.Collections.Generic;
using DL;

namespace BL
{
    public class BL : IBL
    {
        private IRepo _repo;

        public BL(IRepo repo)
        {
            _repo = repo;
        }

        public Customer AddCustomer(Customer customer)
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

        public Customer GetCustomer(int customerID)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        // Stores [Add Store, Get Stores]
        // public StoreFront AddStoreFront(StoreFront store)
        // {
        //     return _repo.AddStoreFront(store);
        // }

        // public List<StoreFront> GetAllStoreFronts()
        // {
        //     return _repo.GetAllStoreFronts();
        // }


        // // Products [Add Product, Get Products]
        // public Product AddProduct(Product product)
        // {
        //     return _repo.AddProduct(product);
        // }
        // public List<Product> GetAllProducts()
        // {
        //     return _repo.GetAllProducts();
        // }

        // public Customer AddCustomer(Customer customer)
        // {
        //     return _repo.AddCustomer(customer);
        // }

        // public List<Customer> GetAllCustomers()
        // {
        //     return _repo.GetAllCustomers();
        // }

        // public Customer GetCustomer(int ID)
        // {
        //     return _repo.GetCustomer(customerID);            
        // }
        // public Customer UpdateCustomer(Customer customer)
        // {
        //     return _repo.UpdateCustomer(customer);
        // }
    }
}