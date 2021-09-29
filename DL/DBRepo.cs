using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity = DL.Entities;
using System.Data.SqlClient;
using System.IO;
using Models;
using Model = Models;
using Microsoft.EntityFrameworkCore;

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
                    CustomerID = customers.CustomerId,
                    Name = customers.Name,
                    Email = customers.Email,
                    Address = customers.Address,
                    City = customers.City,
                    State = customers.State
                }
            ).ToList();
        }

        // public StoreFront AddStoreFront(StoreFront store)
        // {
        //     throw new NotImplementedException();
        // }

        public List<Model.StoreFront> GetAllStoreFronts()
        {
            return _context.StoreFronts.Select(
                StoreFront => new Models.StoreFront()
                {
                    StoreID = StoreFront.StoreId,
                    Address = StoreFront.Address
                }
                ).ToList();
        }

        // public StoreFront GetStoreFront(int StoreID)
        // {
        //     throw new NotImplementedException();
        // }
        public List<Product> GetAllProducts()
        {
            return _context.Products.Select(
                Product => new Models.Product()
                {
                    ProductID = Product.ProductId,
                    DiscFormat = Product.DiscFormat,
                    DiscCap = Product.DiscCap,
                    Color = Product.Color,
                    Price = Product.Price
                }
                ).ToList();
        }

        public List<Models.Customer> GetCustomer(string name)
        {
            return _context.Customers.Where(u => u.Name.ToLower().Contains(name.ToLower())).Select(
                c => new Models.Customer()
            {
                        CustomerID = c.CustomerId,
                        Name = c.Name,
                        Email = c.Email,
                        Address = c.Address,
                        City = c.City,
                        State = c.State
            }).ToList();
        }



        // public Inventory AddInventory(Inventory inventory)
        // {
        //     throw new NotImplementedException();
        // }

        public List<Inventory> GetInventory(int StoreID)
        {
            return _context.Inventories.Select
            (i => new Model.Inventory
            {
                StoreID = i.StoreId,
                ProductID = i.ProductId,
                Quantity = i.Quantity
            }).ToList();
        }
        public Models.Inventory GetSingleInventory(int StoreID, int ProductID)
        {
            Entity.Inventory myInventory = _context.Inventories.FirstOrDefault(x => x.StoreId == StoreID && x.ProductId == ProductID);
            return new Models.Inventory()
            {
                InventoryID = myInventory.InventoryId,
                StoreID = myInventory.StoreId,
                ProductID = myInventory.ProductId,
                Quantity = myInventory.Quantity
            };
        }
        public Models.Product GetProduct(int ProductID)
        {
            Entity.Product myProduct = _context.Products.FirstOrDefault(x => x.ProductId == ProductID);
            return new Models.Product()
            {
                ProductID = myProduct.ProductId,
                DiscFormat = myProduct.DiscFormat,
                DiscCap = myProduct.DiscCap,
                Color = myProduct.Color,
                Price = myProduct.Price
            };
        }
        public Models.LineItem AddLineItem(Models.LineItem newlineitem)
        {
            Entity.LineItem lineitemToAdd = new Entity.LineItem()
            {
                OrderId = newlineitem.OrderID,
                StoreId = newlineitem.StoreID,
                ProductId = newlineitem.ProductID,
                Quantity = newlineitem.Quantity
            };

            lineitemToAdd = _context.Add(lineitemToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Models.LineItem()
            {
                OrderID = newlineitem.OrderID,
                StoreID = newlineitem.StoreID,
                ProductID = newlineitem.ProductID,
                Quantity = newlineitem.Quantity
            };
        }
        public Models.Order AddOrder(Models.Customer cust)
        {
            Entity.Order orderToAdd = new Entity.Order()
            {
                CustomerId = cust.CustomerID
            }
            ;
            orderToAdd = _context.Add(orderToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Models.Order()
            {
                OrderID = orderToAdd.OrderId,
                CustomerID = orderToAdd.CustomerId,
                DateOrder = orderToAdd.DateOrder
            };
        }
        public void UpdateStock(int storeToUpdate, Models.LineItem orderedProduct)
        {
            Entities.Inventory updatedInventory = (from i in _context.Inventories where i.ProductId == orderedProduct.ProductID && i.StoreId == storeToUpdate select i).SingleOrDefault();
            updatedInventory.Quantity = updatedInventory.Quantity - orderedProduct.Quantity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

    }
}
