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
                
            do
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Please log in with your email address.");

                custoemail = Console.ReadLine();

                Console.WriteLine("--------------------");
                Console.WriteLine("Loading...");
                Console.WriteLine("--------------------");
                List<Customer> allCustomer = _bl.GetAllCustomers();
                foreach (Customer customer in allCustomer)
                {
                    if (custoemail == customer.Email)
                    {
                        MenuFactory.currentUser = customer;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Login successful! Welcome back, {customer.Name}!");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto CustomerHub;
                    } 
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email does not match our records. Please try again or sign up for an account.");
                Console.WriteLine("--------------------");
                Console.ForegroundColor = ConsoleColor.White;
                MenuFactory.currentUser = null;
                exit = true;
                return;
                
            

                CustomerHub:
                    Console.WriteLine($"\nWelcome {MenuFactory.currentUser.Name}!");
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("[0] - View Past Orders");
                    Console.WriteLine("[1] - Place a New Order");
                    Console.WriteLine("[2] - Update My Information");
                    Console.WriteLine("[X] - Exit");

                    switch (Console.ReadLine())
                    {
                        case "0": 
                            // View Past Orders
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not yet implemented.");
                            Console.ForegroundColor = ConsoleColor.White;
                            goto CustomerHub;

                        case "1":
                            //Place new order
                            MenuFactory.GetOrderMenu("ordering").Start(MenuFactory.currentUser);
                            break;

                        case "2":
                            // update customer!
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not yet implemented.");
                            Console.ForegroundColor = ConsoleColor.White;
                            // _bl.UpdateCustomer(MenuFactory.currentUser);
                            goto CustomerHub;

                        case "x": 
                            MenuFactory.currentUser = null;
                            exit = true;
                            break;
                    }
            } while (!exit);
        }
    }
}