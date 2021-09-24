using System;
using Models;

namespace UI
{
    public class MainMenu :IMenu
    {
        private Customer customer;
         public void Start()
        {
            bool exit = false;
            string input = "";
            do
            {
                Console.WriteLine("Welcome to Case Sensitive");
                Console.WriteLine("Please choose an option from the following:");
                Console.WriteLine("[1] Log in to your account");
                Console.WriteLine("[2] Register new user");
                Console.WriteLine("[x] Exit");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllCustomers();
                        CustomerNavigation();
                        break;
                    case "2":
                        CreateNewCustomer();
                        break;
                    case "x":
                        Console.WriteLine("Thank you! Please come again!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (!exit);
     }
