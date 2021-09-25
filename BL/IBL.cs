using Models;
using System.Collections.Generic;

namespace BL
{
    public interface IBL
    {
        // Stores [Add Store, Get Stores]
        StoreFront AddStoreFront(StoreFront store);
        List<StoreFront> GetAllStoreFronts();

        // Products [Add Product, Get Products]
        Product AddProduct(Product product);
        List<Product> GetAllProducts();
        
        // Customers [Add Customer, Get Customers/Customer, Update Customer]
        Customer AddCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        Customer GetCustomer(int customerID);
        Customer UpdateCustomer(Customer customer);
    }
}