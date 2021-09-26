using System.Collections.Generic;
using Models;


namespace DL
{
    public interface IRepo
    {
        // Stores [Add Store, Get Stores]
        StoreFront AddStoreFront(StoreFront store);
        List<StoreFront> GetAllStoreFronts();
        StoreFront GetStoreFront(int StoreID);

        // Products [Add Product, Get Products]
        Product AddProduct(Product product);
        List<Product> GetAllProducts();

        // Customers [Add Customer, Get All Customers, Get Specific Customer, Update Customer]
        Customer AddCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        Customer GetCustomer(int CustomerID);
        Customer UpdateCustomer(Customer customer);

        // Inventory
        Inventory AddInventory(Inventory inventory);
        List<Inventory> GetInventory(int InventoryID);
    }
}