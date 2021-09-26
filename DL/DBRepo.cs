using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = Models;
// using Entity = DL.Entities;
using Models;

namespace DL
{
    public class DBRepo : IRepo
    {
        // private Entity.siadbContext _context;
        // public DBRepo(Entity.siadbContext context)
        // {
        //     _context = context;
        // }
        public Model.Customer AddCustomer(Model.Customer customer)
        {
            throw new NotImplementedException();
        }

        public List<Model.Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Model.Customer UpdateCustomer(Model.Customer customerToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}