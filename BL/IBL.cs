using Models;
using System.Collections.Generic;

namespace BLogic
{
    public interface IBL
    {
        // Stores [Add Store, Get Stores]
        StoreFront AddStoreFront(StoreFront store);
        List<StoreFront> GetAllStoreFronts();

        // Products [Add Product, Get Products]
        Product GetProduct(int ProductID);
        List<Product> GetAllProducts();
        
        // Customers [Add Customer, Get Customers/Customer, Update Customer]
        Customer AddCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        Customer GetCustomer(int CustomerID);
        Customer UpdateCustomer(Customer customer);

        // Inventories
        List<Inventory> GetInventory(int StoreID);
        Inventory AddInventory(Inventory inventory);
        LineItem AddLineItem(LineItem lineitem);

        Order AddOrder(Customer cust);
    }
}