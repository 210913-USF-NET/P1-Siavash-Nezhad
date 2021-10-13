using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private DBContext _context;

        public DBRepo(DBContext context)
        {
            _context = context;
        }

        public Models.Customer AddCustomer(Models.Customer custom)
        {
            Customer customToAdd = new Customer()
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

        public List<Models.Customer> GetAllCustomers()
        {
            return _context.Customers.AsNoTracking().Select(
                customers => new Models.Customer()
                {
                    CustomerID = customers.CustomerID,
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

        public List<Models.StoreFront> GetAllStoreFronts()
        {
            return _context.StoreFronts.Select(
                StoreFront => new Models.StoreFront()
                {
                    StoreID = StoreFront.StoreID,
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
                    ProductID = Product.ProductID,
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
                        CustomerID = c.CustomerID,
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

        public List<Models.Inventory> GetInventory(int StoreID)
        {
            return _context.Inventories.Where(inventory => inventory.StoreID == StoreID).Select(
                inventories => new Model.Inventory()
            {
                InventoryID = inventories.InventoryID,
                StoreID = inventories.StoreID,
                ProductID = inventories.ProductID,
                Quantity = inventories.Quantity
            }
            ).ToList();
        }
        public Models.Inventory GetSingleInventory(int StoreID, int ProductID)
        {
            Inventory myInventory = _context.Inventories.FirstOrDefault(x => x.StoreID == StoreID && x.ProductID == ProductID);
            return new Models.Inventory()
            {
                InventoryID = myInventory.InventoryID,
                StoreID = myInventory.StoreID,
                ProductID = myInventory.ProductID,
                Quantity = myInventory.Quantity
            };
        }
        public Models.Product GetProduct(int ProductID)
        {
            Product myProduct = _context.Products.FirstOrDefault(x => x.ProductID == ProductID);
            return new Models.Product()
            {
                ProductID = myProduct.ProductID,
                DiscFormat = myProduct.DiscFormat,
                DiscCap = myProduct.DiscCap,
                Color = myProduct.Color,
                Price = myProduct.Price
            };
        }
        public Models.Product GetProduct(string DiscFormat, int DiscCap, string Color)
        {
            Product myProduct = _context.Products.FirstOrDefault(x => x.DiscFormat == DiscFormat && x.DiscCap == DiscCap && x.Color == Color);
            return new Models.Product()
            {
                ProductID = myProduct.ProductID,
                DiscFormat = myProduct.DiscFormat,
                DiscCap = myProduct.DiscCap,
                Color = myProduct.Color,
                Price = myProduct.Price
            };
        }
        public Models.LineItem AddLineItem(Models.LineItem newlineitem)
        {
            LineItem lineitemToAdd = new LineItem()
            {
                OrderID = newlineitem.OrderID,
                StoreID = newlineitem.StoreID,
                ProductID = newlineitem.ProductID,
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
            Order orderToAdd = new Order()
            {
                CustomerID = cust.CustomerID
            }
            ;
            orderToAdd = _context.Add(orderToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Models.Order()
            {
                OrderID = orderToAdd.OrderID,
                CustomerID = orderToAdd.CustomerID,
                DateOrder = orderToAdd.DateOrder
            };
        }
        public void UpdateStock(int storeToUpdate, Models.LineItem orderedProduct)
        {
            Inventory updatedInventory = (from i in _context.Inventories where i.ProductID == orderedProduct.ProductID && i.StoreID == storeToUpdate select i).SingleOrDefault();
            updatedInventory.Quantity = updatedInventory.Quantity - orderedProduct.Quantity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

    }
}
