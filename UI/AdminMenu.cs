using System;
using Models;
using BLogic;
using System.Collections.Generic;

namespace UI
{
    public class AdminMenu : IMenu
    {
        private IBL _bl;
        private AdminService _adminService;

        public AdminMenu(IBL bl, AdminService adminService)
        {
            _bl = bl;
            _adminService = adminService;
        }

        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Please select an option.");
                Console.WriteLine("[0] - Browse a Store's Inventory");
                Console.WriteLine("[1] - Browse All Customers");
                Console.WriteLine("[2] - Search for a Customer");
                Console.WriteLine("[3] - View Item Inventory");
                Console.WriteLine("[X] - Sign Out");

                switch (Console.ReadLine().ToLower())
                {
                    case "0":
                        Console.WriteLine("--------------------");
                        Console.WriteLine("Enter the Store ID to check inventory for");
                        int StoreID = Int32.Parse(Console.ReadLine());
                        List<Inventory> storeInventory = GetInventory(StoreID);
                        if (storeInventory != null)
                        {
                            foreach (Inventory inventory in storeInventory)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(inventory.ToString());
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------");
                            Console.WriteLine("No such store found!");
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        break;

                    case "1":
                        ViewAllCustomers();
                        break;
                    
                    case "2":
                        Console.WriteLine("--------------------");
                        Console.WriteLine("Enter a name to search for");
                        string userInput = Console.ReadLine().ToLower();
                        List<Customer> customername = GetCustomer(userInput);
                        Models.Customer acustomer = new Models.Customer();
                        foreach (Models.Customer customer in customername)
                        {
                            acustomer.CustomerID = customer.CustomerID;
                            acustomer.Name = customer.Name;
                            acustomer.Email = customer.Email;
                            acustomer.Address = customer.Address;
                            acustomer.City = customer.City;
                            acustomer.State = customer.State;
                        }
                        if (acustomer.Name == null)
                        {   
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------");
                            Console.WriteLine("No such user found!");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        }
                        else
                        {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("User found!");
                                Console.WriteLine($"Customer ID: {acustomer.CustomerID}");
                                Console.WriteLine($"Customer Name: {acustomer.Name}");
                                Console.WriteLine($"Customer Email: {acustomer.Email}");
                                Console.WriteLine($"Customer Address: {acustomer.Address}");
                                Console.WriteLine($"Customer City: {acustomer.City}");
                                Console.WriteLine($"Customer State: {acustomer.State}");
                                Console.ForegroundColor = ConsoleColor.Blue;
                        }
                            break;
                        


                    case "3":
                        Console.WriteLine("--------------------");
                        Console.WriteLine("Enter the Store ID to check inventory for");
                        int checkstoreid = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("--------------------");
                        Console.WriteLine("Enter the Product ID to check inventory for");
                        int checkprodid = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("--------------------");
                        Console.WriteLine("Checking............");
                        Console.WriteLine("--------------------");
                        Inventory SingleInventory = GetSingleInventory(checkstoreid, checkprodid);
                        if (SingleInventory == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------");
                            Console.WriteLine("No such Store or Product found!");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Remaining quantity is {SingleInventory.Quantity}");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        }

                    case "x":
                        MenuFactory.currentUser = null;
                        exit = true;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a proper command.");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                }

            } while (!exit);
        }

        public void ViewAllCustomers()
        {
            List<Customer> allCustomer = _bl.GetAllCustomers();
            foreach (Customer customer in allCustomer)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(customer.ToString());
                Console.ForegroundColor = ConsoleColor.Blue;
            }
        }


        public List<Models.Customer> GetCustomer(string name)
        {
            List<Models.Customer> customername = _bl.GetCustomer(name);
            // Models.Customer acustomer = new Models.Customer();
            // foreach (Models.Customer customer in customername)
            // {
            //     acustomer.CustomerID = customer.CustomerID;
            //     acustomer.Name = customer.Name;
            //     acustomer.Email = customer.Email;
            //     acustomer.Address = customer.Address;
            //     acustomer.City = customer.City;
            //     acustomer.State = customer.State;
            // }
            // if(acustomer != null)
            // {
                return customername;
            
            // else(acustomer == null)
            // {
            //     return null;
            // }
        }
        public Models.Inventory GetSingleInventory(int StoreID, int ProductID)
        {
            if(StoreID < 4 && ProductID < 25)
            {
                Models.Inventory singleinventory = _bl.GetSingleInventory(StoreID,ProductID);
                return singleinventory;
            }
            else
            {
                return null;
            }

        }
        public List<Models.Inventory> GetInventory(int StoreID)
        {
            if(StoreID < 4)
            {
                List<Models.Inventory> storeinventory = _bl.GetInventory(StoreID);
                return storeinventory;
            }
            else
            {
                return null;
            }
        }
    }
}