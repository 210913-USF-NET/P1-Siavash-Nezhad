using BLogic;
using Models;
using System;
using System.Collections.Generic;

namespace UI
{
    public class CustomerMenu : IMenu
    {
        private IBL _bl;

        public CustomerMenu(IBL bl)
        {
            _bl = bl;
        }

        

        public void Start()
        {
                bool exit = false;
                string custoemail = "";
                
                
                Console.WriteLine("--------------------");
                Console.WriteLine("Please log in with your email address.");

                custoemail = Console.ReadLine();

                Console.WriteLine("--------------------");
                Console.WriteLine("Loading...");
                Console.WriteLine("--------------------");

                List<Customer> allCustomer = _bl.GetAllCustomers();
                foreach (Customer customer in allCustomer)
                {
                    if (custoemail == customer.Email.ToString())
                    {
                        MenuFactory.currentUser = customer;
                        Console.WriteLine($"Login successful! Welcome back, {customer.Name}!");
                        exit = true;
                    }
                }

                if (exit == false)
                {
                    Console.WriteLine("Email does not match our records. Please try again or sign up for an account.");
                    exit = true;
                }

            // Check default store. 

            string input;
            int parsedInput;
            bool parseSuccess;
            do
            {
                Console.WriteLine($"\nWelcome {MenuFactory.currentUser.Name}!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] - View Past Orders");
                Console.WriteLine("[1] - Place a New Order");
                Console.WriteLine("[2] - Place a New Order");
                Console.WriteLine("[X]- Exit");

                switch (Console.ReadLine())
                {
                    case "0": 
                        // View Past Orders
                        Console.WriteLine("Not yet implemented.");
                        break; 

                    case "1":
                        //Place new order
                        MenuFactory.GetMenu("ordering").Start();
                        break;

                    case "2":
                        // update customer!
                        _bl.UpdateCustomer(MenuFactory.currentUser);
                        break;

                    case "x": 
                        exit = true;
                        break;
                }
            } while(!exit);
        }
    }
}