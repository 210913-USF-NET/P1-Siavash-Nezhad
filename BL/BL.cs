using System;
using Models;
using System.Collections.Generic;
using DL;

namespace BLogic
{
    public class BL : IBL
    {
        private IRepo _repo;

        public BL(IRepo repo)
        {
            _repo = repo;
        }
        public StoreFront AddStoreFront(StoreFront store)
        {
            return _repo.AddStoreFront(store);
        }
        public List<StoreFront> GetAllStoreFronts()
        {
            return _repo.GetAllStoreFronts();
        }
        public Product AddProduct(Product ProductID)
        {
            return _repo.AddProduct(ProductID);
        }
        public List<Product> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }
        public Customer AddCustomer(Customer CustomerID)
        {
            return _repo.AddCustomer(CustomerID);
        }
        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }
        public Customer GetCustomer(int CustomerID)
        {
            return _repo.GetCustomer(CustomerID);            
        }
        public Customer UpdateCustomer(Customer customer)
        {
            return _repo.UpdateCustomer(customer);
        }
        public Inventory AddInventory(Inventory inventory)
        {
            return _repo.AddInventory(inventory);
        }
        public List<Inventory> GetInventory(int store)
        {
            return _repo.GetInventory(store);
        }
        public LineItem AddLineItem(LineItem lineitem)
        {
            return _repo.AddLineItem(lineitem);
        }
    }
}