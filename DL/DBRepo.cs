using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity = DL.Entities;
using System.Data.SqlClient;
using System.IO;
using Models;
using Model = Models;

namespace DL
{
    public class DBRepo : IRepo
    {
        string connectionString = File.ReadAllText(@"../connectionString.txt");
        private Entity.siadbContext _context;

        public DBRepo(Entity.siadbContext context)
        {
            _context = context;
        }

        public Models.Customer AddCustomer(Models.Customer custom)
        {
            Entity.Customer customToAdd = new Entity.Customer()
            {
                Name = custom.Name,
                Email = custom.Email,
                Address = custom.Address,
                City = custom.City,
                State = custom.State
            };

            customToAdd = _context.Add(customToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Models.Customer()
            {
                // CustomerID = customerToAdd.CustomerID,
                Name = customToAdd.Name,
                Email = customToAdd.Email,
                Address = customToAdd.Address,
                City = customToAdd.City,
                State = customToAdd.State
            };

        }

        public Models.Customer UpdateCustomer(Models.Customer customToUpdate)
        {
            throw new NotImplementedException();

        }

        public List<Model.Customer> GetAllCustomers()
        {
            return _context.Customers.Select(
                customers => new Model.Customer()
                {
                    // CustomerID = customers.CustomerID,
                    Name = customers.Name,
                    Email = customers.Email,
                    Address = customers.Address,
                    City = customers.City,
                    State = customers.State
                }
            ).ToList();
        }

        public StoreFront AddStoreFront(StoreFront store)
        {
            throw new NotImplementedException();
        }

        public List<StoreFront> GetAllStoreFronts()
        {
            return _context.StoreFronts.Select(
                StoreFront => new Models.StoreFront() 
                {
                    // StoreID = StoreFront.StoreID,
                    Address = StoreFront.Address
                }
                ).ToList();
        }

        public StoreFront GetStoreFront(int StoreID)
        {
            throw new NotImplementedException();
        }
        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int CustomerID)
        {
            throw new NotImplementedException();
        }

        public Inventory AddInventory(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public List<Inventory> GetInventory(int StoreID)
        {
            throw new NotImplementedException();
        }
        List<StoreFront> IRepo.GetAllStoreFronts()
        {
            throw new NotImplementedException();
        }

        StoreFront IRepo.GetStoreFront(int StoreID)
        {
            throw new NotImplementedException();
        }

        public Product AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        List<Product> IRepo.GetAllProducts()
        {
            throw new NotImplementedException();
        }

        Customer IRepo.GetCustomer(int CustomerID)
        {
            throw new NotImplementedException();
        }

        List<Inventory> IRepo.GetInventory(int StoreID)
        {
            throw new NotImplementedException();
        }
    }
}