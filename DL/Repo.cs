using System;
using System.Collections.Generic;
using Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entity = DL.Entities;

namespace DL
{
    public class Repo : IRepo
    {
        private Entity.Project00Context _context;
        public Repo(Entity.Project00Context context)
        {
            _context = context;
        }

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
        List<Customer> FindCustomerByName()
        {
            throw new NotImplementedException();
        }

        public List<Inventory> GetAllInventories(int storeId)
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
    }
}