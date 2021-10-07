using System;
using Models;
using BLogic;
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
                Console.WriteLine("--------------------");
                Console.WriteLine("Welcome to Case Sensitive!");
                Console.WriteLine("Please choose an option or type 'x' to exit.");
                Console.WriteLine("[0] - New Account");
                Console.WriteLine("[1] - Log In");
                Console.WriteLine("[X] - Exit");

                input = Console.ReadLine().ToLower();

                switch (input)
                {


                    case "shrek":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("--------------------");
                        Console.WriteLine("What are ya doin' in my swamp?!");
                        MenuFactory.GetMenu("admin").Start();
                        Console.ForegroundColor = ConsoleColor.White;
                    break;

                    case "0":
                        Console.WriteLine("--------------------");
                        Console.WriteLine("Let's create you a newclear account:");
                        MenuFactory.GetMenu("new-customer").Start();
                    break;
                    
                    case "1":
                        MenuFactory.GetMenu("customer").Start();
                    break;

                    case "x":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("--------------------");
                        Console.WriteLine("Thank you, please come again!");
                        Console.ForegroundColor = ConsoleColor.White;
                        exit = true;
                    break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------");
                        Console.WriteLine("Please enter a valid command.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }

            } while (!exit);

        }
    }
}