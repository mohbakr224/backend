using Assignment_11.Models;

namespace Assignment_11.Repositry
{
    public class ProductsRepo
    {
     List<Products> products = new List<Products>
{
    new Products { id = 1, name = "Wireless Mouse", price = 19.99, isFavorite = true,  available = true },
    new Products { id = 2, name = "Mechanical Keyboard", price = 59.99, isFavorite = false, available = true },
    new Products { id = 3, name = "27-inch Monitor", price = 249.99, isFavorite = true,  available = true },
    new Products { id = 4, name = "USB-C Hub", price = 29.99, isFavorite = false, available = false },
    new Products { id = 5, name = "Laptop Stand", price = 34.50, isFavorite = true,  available = true },
    new Products { id = 6, name = "Bluetooth Speaker", price = 79.99, isFavorite = false, available = true },
    new Products { id = 7, name = "Gaming Headset", price = 89.99, isFavorite = true,  available = false },
    new Products { id = 8, name = "External SSD 1TB", price = 119.99, isFavorite = false, available = true },
    new Products { id = 9, name = "Webcam HD", price = 49.99, isFavorite = true,  available = true },
    new Products { id = 10, name = "Wireless Charger", price = 24.99, isFavorite = false, available = true },
    new Products { id = 11, name = "Smart Watch", price = 199.99, isFavorite = true,  available = false },
    new Products { id = 12, name = "Portable Power Bank", price = 44.99, isFavorite = false, available = true }
};

        public List<Products> FetchProducts()
        {
            return products;

        }
    }

}
