using System;
using Models;
using System.Collections.Generic;

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
                Console.WriteLine("Email");
                Console.WriteLine("Address");
                Console.WriteLine("City");
                Console.WriteLine("State");

                newName = Console.ReadLine();
                newEmail = Console.ReadLine();
                newAddress = Console.ReadLine();
                newCity = Console.ReadLine();
                newState = Console.ReadLine();

                confirm:
                Console.WriteLine("--------------------");
                Console.WriteLine($"Name: {newName}");
                Console.WriteLine($"Email: {newEmail}");
                Console.WriteLine($"Address: {newAddress}");
                Console.WriteLine($"City: {newCity}");
                Console.WriteLine($"State: {newState}");
                Console.WriteLine("Is this correct? [y] to confirm or [n] to reset");

                input = String.ToLower(Console.ReadLine());

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