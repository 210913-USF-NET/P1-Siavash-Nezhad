using System.Collections.Generic;
using Models;


namespace DL
{
    public interface IRepo
    {
        List<StoreFront> GetAllStoreFronts();
        Product GetProduct(int ProductID);
        Product GetProduct(string DiscFormat, int DiscCap, string Color);
        List<Product> GetAllProducts();
        Customer AddCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        List<Models.Customer> GetCustomer(string name);
        Customer UpdateCustomer(Customer customer);
        List<Inventory> GetInventory(int StoreID);
        Inventory GetSingleInventory(int StoreID, int ProductID);
        LineItem AddLineItem(LineItem lineitem);
        Order AddOrder(Customer cust);
        void UpdateStock(int storeToUpdate, Models.LineItem orderedProduct);
    }
}