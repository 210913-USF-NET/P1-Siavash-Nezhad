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

        public static Customer currentUser;

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
                        currentUser = customer;
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
                Console.WriteLine($"\nWelcome {currentUser.Name}!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("0- View Past Orders");
                Console.WriteLine("1- Change Default Store");
                Console.WriteLine("x- Exit");
                Console.Write("Input: ");

                switch (Console.ReadLine())
                {
                    case "0": 
                        // View Past Orders
                        Console.WriteLine("Not yet implemented.");
                        break; 

                    // case "1": 
                    //     // Change Default Store
                    //     List<StoreFront> allRestos = _bl.GetAllStoreFronts();
                    //     if (allRestos.Count == 0)
                    //     {
                    //         Console.WriteLine("There are no stores.");
                    //         break;
                    //     }
                    //     getStore: 
                    //     for (int i = 0; i < allRestos.Count; i++) 
                    //     {
                    //         Console.WriteLine($"[{i}] {allRestos[i].Name}");
                    //     }
                        
                    //     Console.Write("Which store would you like to set? ");
                    //     input = Console.ReadLine();
                    //     parseSuccess = int.TryParse(input, out parsedInput);
                    //     if (parseSuccess && parsedInput >= 0 && parsedInput < allRestos.Count)
                    //     {
                    //         custo.StoreFrontID = parsedInput;
                    //         Console.WriteLine($"Storefront changed to {allRestos[parsedInput].Name}");
                    //     }
                    //     else
                    //     {
                    //         Console.WriteLine("Invalid input, please try again.");
                    //         goto getStore;
                    //     }


                        // update customer!
                        // currentUser.hasDefaultStore = 1;
                        // _bl.UpdateCustomer(currentUser);

                        break;


                        // update customer!
                        _bl.UpdateCustomer(currentUser);

                        break;

                    case "x": 
                        exit = true;
                        break;
                }
            } while(!exit);
        }
    }
}