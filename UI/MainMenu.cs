using System;
using Models;
using BL;
using DL;
using System.Collections.Generic;

namespace UI
{
    public class MainMenu : IMenu
    {
        public void Start()
        {
            bool exit = false;
            string input = "";
            do
            {
                Console.WriteLine("Welcome to Case Sensitive!");
                Console.WriteLine("Please choose an option or type 'x' to exit.");
                Console.WriteLine("[0] New Account");
                Console.WriteLine("[1] Log In");
                Console.WriteLine("[x] Exit");

                input = Console.ReadLine();

                switch (input)
                {


                    case "admin":
                        Console.WriteLine("Welcome Admin!");
                        // MenuFactory.GetMenu("admin").Start();
                    break;

                    case "0":
                        Console.WriteLine("Let's create you a new account:");
                        // MenuFactory.GetMenu("new-customer").Start();
                    break;
                    
                    case "1":
                        // MenuFactory.GetMenu("customer").Start();
                    break;

                    case "x":
                        Console.WriteLine("Thank you, please come again!");
                        exit = true;
                    break;

                    default:
                        Console.WriteLine("Please enter a proper command.");
                        break;
                }

            } while (!exit);

        }
    }
}