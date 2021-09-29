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
            Order thisOrder = _bl.AddOrder(MenuFactory.currentUser);
            bool exit = false;
            do
            {
                Order:
                Console.WriteLine("--------------------");
                Console.WriteLine("Please enter the StoreID of your preferred store location.");
                List<StoreFront> allStoreFronts = _bl.GetAllStoreFronts();
                foreach (StoreFront storefront in allStoreFronts)
                {
                    Console.WriteLine(storefront.ToString());
                }
                Console.WriteLine("[X] - Back to Returning Customer Menu");
                string userinput = Console.ReadLine().ToLower();
                if (userinput == "x")
                {
                    MenuFactory.currentUser = null;
                    break;
                    // MenuFactory.GetMenu("customer").Start();
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please select a valid format.");
                        Console.ForegroundColor = ConsoleColor.White;
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please select a valid color.");
                        Console.ForegroundColor = ConsoleColor.White;
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please select a valid disc capacity.");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto DiscCap;
                }
                newLineItem.ProductID = tempProduct;
                List<LineItem> myCart = new List<LineItem>();
                myCart.Add(newLineItem);

            Quantity:
                Inventory storeInventory = _bl.GetSingleInventory(newLineItem.StoreID,newLineItem.ProductID);
                Console.WriteLine("--------------------");
                Console.WriteLine("How many of these cases would you like to order?");
                Console.WriteLine("Please enter a whole number between 1 and 100.");
                Console.WriteLine("Alternatively, type [X] to cancel the order");

                format = Console.ReadLine().ToLower();
                if (format == "x")
                {
                    Console.WriteLine("Order successfully cancelled");
                    goto Order;
                }
                else if (Int32.Parse(format) > 0 && Int32.Parse(format) < 101)
                {
                    if (Int32.Parse(format) > storeInventory.Quantity)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, we do not have sufficient stock.");
                        Console.WriteLine($"Your selected store only has {storeInventory.Quantity} of your specified cases.");
                        Console.WriteLine("Please select a lower quantity or cancel the order.");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto Quantity;
                    }
                    else
                        newLineItem.Quantity = Int32.Parse(format);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please select a valid quantity.");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto Quantity;
                }

                Confirm:
                Product myProduct = _bl.GetProduct(tempProduct);
                decimal LineItemPrice = myProduct.Price*newLineItem.Quantity;
                Console.WriteLine("--------------------");
                Console.WriteLine($"Format: {myProduct.DiscFormat}");
                Console.WriteLine($"Disc Capacity: {myProduct.DiscCap}");
                Console.WriteLine($"Case Color: {myProduct.Color}");
                Console.WriteLine($"Quantity: {newLineItem.Quantity}");
                Console.WriteLine($"Subtotal: ${LineItemPrice}");
                Console.WriteLine("Is this correct? [Y] to confirm or [N] to reset");
            
                string input = Console.ReadLine().ToLower();

                switch(input){
                    case "y":
                        newLineItem.OrderID = thisOrder.OrderID;
                        newLineItem = _bl.AddLineItem(newLineItem);
                        Console.WriteLine("Would you like to add more to your order?");
                        Console.WriteLine("[Y] to add more or [N] to finalize purchases");
                        string input2 = Console.ReadLine().ToLower();
                        OrderMore:
                        if(input2 == "y")
                        {
                            goto Order;
                        }
                        else if (input2 == "n")
                        {
                            _bl.UpdateStock(newLineItem.StoreID,newLineItem);
                            MenuFactory.currentUser = null;
                            MenuFactory.GetMenu("customer").Start();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter [Y] or [N]");
                            Console.ForegroundColor = ConsoleColor.White;
                            goto OrderMore;
                        }break;

                    case "n":
                        goto Order;

                    default:
                        Console.WriteLine("Please enter [Y] or [N]");
                        goto Confirm;
                }
            } while (!exit && MenuFactory.currentUser != null);
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