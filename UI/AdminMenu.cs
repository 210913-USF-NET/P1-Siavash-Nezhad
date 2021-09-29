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
                Console.WriteLine("[x] - Sign Out");

                switch (Console.ReadLine())
                {
                    case "0":
                        break;

                    case "1":
                        ViewAllCustomers();
                        break;
                    
                    case "2":
                        Console.WriteLine("--------------------");
                        Console.WriteLine("Enter a name to search for");
                        GetCustomer(Console.ReadLine().ToString());
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
                        int availquantity = GetSingleInventory(checkstoreid, checkprodid).Quantity;
                        Console.WriteLine($"Remaining quantity is {availquantity}");
                        break;

                    case "x":
                        MenuFactory.currentUser = null;
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Please enter a proper command.");
                        break;
                }

            } while (!exit);
        }

        public void ViewAllCustomers()
        {
            List<Customer> allCustomer = _bl.GetAllCustomers();
            foreach (Customer customer in allCustomer)
            {
                Console.WriteLine(customer.ToString());
            }
        }


        public List<Models.Customer> GetCustomer(string name)
        {

            List<Models.Customer> customername = _bl.GetCustomer(name);
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
            if(acustomer != null)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine($"Customer ID: {acustomer.CustomerID}");
                Console.WriteLine($"Name: {acustomer.Name}");
                Console.WriteLine($"Email: {acustomer.Email}");
                Console.WriteLine($"Address: {acustomer.Address}");
                Console.WriteLine($"City: {acustomer.City}");
                Console.WriteLine($"State: {acustomer.State}");
            }
            else
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("No results found!");
                return null;
            }
            return new List<Models.Customer>();
        }
        public Models.Inventory GetSingleInventory(int StoreID, int ProductID)
        {
            Models.Inventory singleinventory = _bl.GetSingleInventory(StoreID,ProductID);
            return singleinventory;
        }
    }
}