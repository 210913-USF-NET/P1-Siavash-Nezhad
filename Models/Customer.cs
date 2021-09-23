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
        public Customer(string name) : this()
        {
            this.Name = name;
            this.CustomerDefaultStoreID = 100;
        }

        //constructor chaining
        public Customer(string name, string address) : this(name)
        {
            this.Address = address;
            this.CustomerDefaultStoreID = 100;
        }

        public Customer(string name, int age, string city) : this(name, age)
        {
        }

        //Property
        public string CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int CustomerDefaultStoreID { get; set; }
        public List<Order> Orders { get; set; }
    }
}
