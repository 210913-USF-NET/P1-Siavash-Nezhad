using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override string ToString()
        // public override string
        {
            // Console.ForegroundColor = ConsoleColor.Yellow;
            return $"Customer ID: {this.CustomerID}, Name: {this.Name}, Email: {this.Email}, Address: {this.Address}, City: {this.City}, State: {this.State}";
            // Console.WriteLine("Customer ID: {0} Name: {1}, Email: {2}, Address: {3}, City: {4}, State: {5}", this.CustomerID, this.Name, this.Email, this.Address, this.City, this.State);
        }
    }
    
}