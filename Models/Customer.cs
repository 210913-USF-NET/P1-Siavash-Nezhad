using System;
using System.Collections.Generic;

namespace Models
{
    public class Customer
    {
        public Customer() {}

        public Customer(string name) : this ()
        {
            this.Name = name;
        }

        public Customer(string name, string address) : this(name)
        {
            this.Address = address;
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public List<Order> Orders { get; set; }
    }
}