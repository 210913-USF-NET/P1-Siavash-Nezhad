using System;
using System.Collections.Generic;
using Models;

namespace DL
{
    public interface IRepo
    {
        List<Customer> GetAllCustomers();
        List<Customer> FindCustomerByName();
        Customer AddCustomer(Customer newCustomer);
        List<Inventory> GetAllInventories(int storeID);
        Inventory UpdateStoreInventory(Inventory newInventory);
        LineItem AddLineItem(LineItem newItem);
        List<LineItem> GetAllLineItems(int input);
        Order AddOrder(Order newOrder);
        List<Order> GetAllOrders();
    }
}