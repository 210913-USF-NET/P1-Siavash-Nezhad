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

        public Customer(string name, string email) : this(name)
        {
            this.Email = email;
        }

        public Customer(string name, string email, string address) : this(name, email)
        {
            this.Address = address;
        }

        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}