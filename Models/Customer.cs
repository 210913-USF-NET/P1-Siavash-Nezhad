using System;
using System.Collections.Generic;

namespace Models
{
    public class Customer
    {
        public Customer() { }

        //Constructor overloading (this is an example of polymorphism)
        //The constructor behaves differently!
        //depending on what is passed in
        public Customer(string Company) : this()
        {
            this.Company = company;
        }

        //constructor chaining
        public Customer(string Company, string State) : this(customer)
        {
            this.State = state;
        }

        public Customer(string Company, string State, string Email) : this(name, address) : this(name, state)
        {
            this.Email = email;
        }

        //Property
        public string CustomerID { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string State { get; set; }
        public List<Order> Orders { get; set; }
    }
}
