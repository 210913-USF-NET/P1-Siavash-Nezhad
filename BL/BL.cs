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
        // public StoreFront AddStoreFront(StoreFront store)
        // {
        //     return _repo.AddStoreFront(store);
        // }
        public List<StoreFront> GetAllStoreFronts()
        {
            return _repo.GetAllStoreFronts();
        }
        public Product GetProduct(int ProductID)
        {
            return _repo.GetProduct(ProductID);
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
        public List<Models.Customer> GetCustomer(string name)
        {
            return _repo.GetCustomer(name);
        }
        public Customer UpdateCustomer(Customer customer)
        {
            return _repo.UpdateCustomer(customer);
        }
        // public Inventory AddInventory(Inventory inventory)
        // {
        //     return _repo.AddInventory(inventory);
        // }
        public List<Inventory> GetInventory(int store)
        {
            return _repo.GetInventory(store);
        }
        public Inventory GetSingleInventory(int StoreID, int ProductID)
        {
            return _repo.GetSingleInventory(StoreID,ProductID);
        }
        public LineItem AddLineItem(LineItem lineitem)
        {
            return _repo.AddLineItem(lineitem);
        }
        public Models.Order AddOrder(Models.Customer cust)
        {
            return _repo.AddOrder(cust);
        }
        public void UpdateStock(int storeToUpdate, Models.LineItem orderedProduct)
        {
            _repo.UpdateStock(storeToUpdate, orderedProduct);
        }
    }
}