using System;
using Models;
using BLogic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DL;

namespace UI
{
    public class Ordering : IMenuCustomer
    {
        private IBL _bl;
        public Ordering(IBL bl)
        {
            _bl = bl;
        }
        public Customer currentUser = MenuFactory.currentUser;
        public void Start(Customer currentUser)
        {
            int tempProduct = 0;
            Models.LineItem newLineItem = new Models.LineItem();
            List<LineItem> myCart = new List<LineItem>();
            bool exit = false;
            do
            {
                Order:
                Console.WriteLine("--------------------");
                Console.WriteLine("Which location is this order for?");
                List<StoreFront> allStoreFronts = _bl.GetAllStoreFronts();
                foreach (StoreFront storefront in allStoreFronts)
                {
                    Console.WriteLine(storefront.ToString());
                }
                Console.WriteLine("[X] - Back to Returning Customer Menu");
                string userinput = Console.ReadLine().ToLower();
                if (userinput == "x")
                {
                    MenuFactory.GetMenu("customer").Start();
                }
                else
                {
                    newLineItem.StoreID = Int32.Parse(userinput);
                }
                

                Format:
                Console.WriteLine("--------------------");
                Console.WriteLine("What format should the case be?");
                Console.WriteLine("[1] - CD");
                Console.WriteLine("[2] - DVD");
                Console.WriteLine("[3] - Blu-ray");
                Console.WriteLine("[4] - 4K Blu-ray");
                Console.WriteLine("[X] - Cancel Order");

                string format = Console.ReadLine().ToLower();
                switch (format)
                {

                    case "1":
                        tempProduct = 0;
                        break;

                    case "2":
                        tempProduct = 6;
                        break;

                    case "3":
                        tempProduct = 12;
                        break;

                    case "4":
                        tempProduct = 18;
                        break;

                    case "x":
                        Console.WriteLine("Order successfully cancelled");
                        goto Order;

                    default:
                        Console.WriteLine("Please select a valid format.");
                        goto Format;
                }

                Color:
                Console.WriteLine("--------------------");
                Console.WriteLine("What color should the case be?");
                Console.WriteLine("[1] - Clear");
                Console.WriteLine("[2] - Black");
                Console.WriteLine("[X] - Cancel Order");

                format = Console.ReadLine().ToLower();
                switch (format)
                {

                    case "1":
                        break;

                    case "2":
                        tempProduct = tempProduct + 3;
                        break;

                    case "x":
                        Console.WriteLine("Order successfully cancelled");
                        goto Order;

                    default:
                        Console.WriteLine("Please select a valid color.");
                        goto Color;
                }

                DiscCap:
                Console.WriteLine("--------------------");
                Console.WriteLine("How many discs should the case hold?");
                Console.WriteLine("[1] - One");
                Console.WriteLine("[2] - Two");
                Console.WriteLine("[3] - Three");
                Console.WriteLine("[X] - Cancel Order");

                format = Console.ReadLine().ToLower();
                switch (format)
                {

                    case "1":
                        tempProduct = tempProduct + 1;
                        break;

                    case "2":
                        tempProduct = tempProduct + 2;
                        break;

                    case "3":
                        tempProduct = tempProduct + 3;
                        break;

                    case "x":
                        Console.WriteLine("Order successfully cancelled");
                        goto Order;

                    default:
                        Console.WriteLine("Please select a valid disc capacity.");
                        goto DiscCap;
                }
                newLineItem.ProductID = tempProduct;
                myCart.Add(newLineItem);
                
                Quantity:
                Console.WriteLine("--------------------");
                Console.WriteLine("How many of these cases would you like to order?");
                Console.WriteLine("Please enter a whole number between 1 and 100.");
                Console.WriteLine("Alternatively, type [X] to cancel the order");

                format = Console.ReadLine().ToLower();
                if (Int32.Parse(format) > 0 && Int32.Parse(format) < 101)
                {
                    newLineItem.Quantity = Int32.Parse(format);
                }
                else if (format == "x")
                {
                    Console.WriteLine("Order successfully cancelled");
                    goto Order;
                }
                else
                {
                    Console.WriteLine("Please select a valid quantity.");
                    goto Quantity;
                }

                Confirm:
                Product myProduct = _bl.GetProduct(tempProduct);
                Console.WriteLine("--------------------");
                Console.WriteLine($"Format: {myProduct.DiscFormat}");
                Console.WriteLine($"Disc Capacity: {myProduct.DiscCap}");
                Console.WriteLine($"Case Color: {myProduct.Color}");
                Console.WriteLine($"Quantity: {newLineItem.Quantity}");
                Console.WriteLine("Is this correct? [Y] to confirm or [N] to reset");
            
                string input = Console.ReadLine().ToLower();

                switch(input){
                    case "y":

                        // List<Customer> allCustom = _bl.GetAllCustomers();
                        // foreach (Customer customer in allCustom)
                        // {
                        //     if (newEmail == customer.Email)
                        //     {
                        //         Console.WriteLine($"An account already exists with this email. Please use another email or log in.");
                        //         break;
                        //     }
                        // }
                    break;

                    case "n":
                        goto Order;

                    default:
                        Console.WriteLine("Please enter [Y] or [N]");
                        goto Confirm;
                }
            
            newLineItem = _bl.AddLineItem(newLineItem);
            } while (!exit);
        }
        private List<StoreFront> GetAllStoreFronts()
        {
            List<StoreFront> allStoreFronts = _bl.GetAllStoreFronts();
            if (allStoreFronts.Count == 0)
            {
                Console.WriteLine("There are no stores.");
            }
            else
            {
                for (int i = 0; i < allStoreFronts.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {allStoreFronts[i].ToString()}");
                }
            }
            return allStoreFronts;
        }
    }
}
//     private List<StoreFront> GetAllStoreFronts()
//     {
//         List<StoreFront> allStoreFronts = _bl.GetAllStoreFronts();
//         if(allStoreFronts.Count == 0)
//         {
//             Console.WriteLine("There are no stores.");
//         }
//         else
//         {
//             for(int i = 0; i < allStoreFronts.Count; i++)
//             {
//                 Console.WriteLine($"[{i + 1}] {allStoreFronts[i].ToString()}");
//             }
//         }
//         return allStoreFronts;
//     }
// }
//     public void ViewAllProducts()
//     {
//         List<Product> allProducts = _bl.GetAllProducts();
//         // foreach (Product product in allProducts)
//         // {
//         //     Console.WriteLine(product.ToString());
//         // }
//     }
// }