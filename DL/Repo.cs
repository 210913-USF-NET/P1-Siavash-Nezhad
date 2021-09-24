using System;
using System.Collections.Generic;
using Models;
using System.Linq;
using System.Threading.Tasks;

namespace DL
{
    public class Repo : IRepo
    {
        public Models.Customer AddCustomer(Models.Customer newCustomer)
        {
            throw new NotImplementedException();
        }

        public Models.LineItem AddLineItem(Models.LineItem newItem)
        {
           throw new NotImplementedException();
        }
        public List<Models.Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }
        public List<Customer> FindCustomerByName()
        {
            throw new NotImplementedException();
        }

        public List<Inventory> GetAllInventories(int storeID)
        {
            throw new NotImplementedException();
        }

        public List<LineItem> GetAllLineItems(int input)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Inventory UpdateStoreInventory(Inventory newInventory)
        {
            throw new NotImplementedException();
        }
        public Order AddOrder(Order newOrder)
        {
            throw new NotImplementedException();
        }
    }
}