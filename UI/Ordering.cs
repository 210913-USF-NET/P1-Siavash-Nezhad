using System;
using Models;
using BLogic;

namespace UI
{
    public class Ordering : IMenuCustomer
    {
        private IBL _bl;
        public Ordering (IBL bl)
        {
            _bl = bl;
        }
        public Customer currentUser = MenuFactory.currentUser;
        public void Start(Customer currentUser)
        {
            bool exit = false;
            do
            {
                
            }
            }
            exit = true;
        }
    }
}