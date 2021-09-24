using System;
using System.Collections.Generic;
using Models;

namespace DL
{
    public interface IRepo
    {
        public List<Customer> GetAllCustomers();
        public List<Customer> FindCustomerByName();
        public Customer AddCustomer(Customer newCustomer);
        public List<Inventory> GetAllInventories(int storeID);
        public Inventory UpdateStoreInventory(Inventory newInventory);
        public LineItem AddLineItem(LineItem newItem);
        public List<LineItem> GetAllLineItems(int input);
        public Order AddOrder(Order newOrder);
        public List<Order> GetAllOrders();
    }
}