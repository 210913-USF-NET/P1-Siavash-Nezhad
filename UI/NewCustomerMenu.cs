using System;
using Models;
using System.Collections.Generic;
using BLogic;

namespace UI
{
    public class NewCustomerMenu : IMenu
    {
        private IBL _bl;
        private NewCustomerService _newCustomerService;

        public NewCustomerMenu(IBL bl, NewCustomerService newCustomerService)
        {
            _bl = bl;
            _newCustomerService = newCustomerService;
        }

        public void Start()
        {
            bool exit = false;
            string input = "";
            string newName = "";
            string newEmail = "";
            string newAddress = "";
            string newCity = "";
            string newState = "";
            do
            {
                userInput:
                Console.WriteLine("--------------------");
                Console.WriteLine("Please enter the following:");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Full name");
                Console.ForegroundColor = ConsoleColor.White;
                newName = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Email");
                Console.ForegroundColor = ConsoleColor.White;
                newEmail = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Address");
                Console.ForegroundColor = ConsoleColor.White;
                newAddress = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("City");
                Console.ForegroundColor = ConsoleColor.White;
                newCity = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("State");
                Console.ForegroundColor = ConsoleColor.White;
                newState = Console.ReadLine();

                confirm:
                Console.WriteLine("--------------------");
                Console.WriteLine($"Name: {newName}");
                Console.WriteLine($"Email: {newEmail}");
                Console.WriteLine($"Address: {newAddress}");
                Console.WriteLine($"City: {newCity}");
                Console.WriteLine($"State: {newState}");
                Console.WriteLine("Is this correct? [Y] to confirm or [N] to reset");

                input = Console.ReadLine().ToLower();

                switch(input){
                    case "y":

                        List<Customer> allCustom = _bl.GetAllCustomers();
                        foreach (Customer customer in allCustom)
                        {
                            if (newEmail == customer.Email)
                            {
                                Console.WriteLine($"An account already exists with this email. Please use another email or log in.");
                                exit = true;
                            }
                        }

                        if (exit == false)
                        {
                            Customer newCustom = new Customer();
                            newCustom.Name = newName;
                            newCustom.Email = newEmail;
                            newCustom.Address = newAddress;
                            newCustom.City = newCity;
                            newCustom.State = newState;
                            // Customer addedCustom = _bl.AddCustomer(newCustom);
                            Console.WriteLine($"You successfully created an account for {newName} at {newEmail}");
                            Console.WriteLine("Please log in with your email address.");
                            exit = true;
                        }
                    break;
                    
                    case "n":
                        goto userInput;

                    default:
                        Console.WriteLine("Please enter [Y] or [N]");
                        goto confirm;
                }
            } while (!exit);
        }
    }
}