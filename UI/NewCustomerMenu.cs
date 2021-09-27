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
                Console.WriteLine("Please enter the following.");
                Console.WriteLine("Full name");
                newName = Console.ReadLine();
                Console.WriteLine("Email");
                newEmail = Console.ReadLine();
                Console.WriteLine("Address");
                newAddress = Console.ReadLine();
                Console.WriteLine("City");
                newCity = Console.ReadLine();
                Console.WriteLine("State");
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
                        Customer newCustom = new Customer();
                        newCustom.Name = newName;
                        newCustom.Email = newEmail;
                        newCustom.Address = newAddress;
                        newCustom.City = newCity;
                        newCustom.State = newState;
                        Customer addedCustom = _bl.AddCustomer(newCustom);
                        Console.WriteLine($"You created {addedCustom}");
                        Console.WriteLine("New user created! Please log in with your email address.");
                        exit = true;
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