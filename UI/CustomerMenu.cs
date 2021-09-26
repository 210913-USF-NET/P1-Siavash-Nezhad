using System;
using Models;
using BLogic;
using System.Collections.Generic;

namespace UI
{
    public class CustomerMenu : IMenu
    {
        private IBL _bl;
        private CustomerService _customerService;

        public CustomerMenu(IBL bl, CustomerService customerService)
        {
            _bl = bl;
            _customerService = customerService;
        }

        public void Start()
        {
            bool exit = false;
            string input2 = "";
            
            do
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Please log in with your email address.");

                input2 = Console.ReadLine();

                Console.WriteLine("--------------------");
                Console.WriteLine("Loading...");
                Console.WriteLine("--------------------");

                List<Customer> allCustomer = _bl.GetAllCustomers();
                foreach (Customer customer in allCustomer)
                {
                    if (input2 == customer.Email.ToString())
                    {
                        Console.WriteLine("Login successful! Welcome back!");
                        exit = true;
                        break;
                    }
                }

                if (exit == false)
                {
                    Console.WriteLine("Email does not match our records. Please try again or sign up for an account.");
                    exit = true;
                }

            } while (!exit);
        }

    }
}