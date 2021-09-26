using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = Models;
using Entity = DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class DBRepo : IRepo
    {
        private Entity.siadbContext _context;

        public DBRepo(Entity.siadbContext context)
        {
            _context = context;
        }

        public Model.Customer AddCustomer(Model.Customer custom)
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

            return new Model.Customer()
            {
                // CustomerID = customToAdd.CustomerID,
                Name = customToAdd.Name,
                Email = customToAdd.Email,
                Address = customToAdd.Address,
                City = customToAdd.City,
                State = customToAdd.State
            };

        }

        public Model.Customer UpdateCustomer(Model.Customer customToUpdate)
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
    }
}