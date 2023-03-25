using Newtonsoft.Json;
using Oop;
using System.Security.Cryptography;
using Formatting = Newtonsoft.Json.Formatting;

internal class Program
{
    private static void Main(string[] args)
    {
        // Init readonly properties via the constructor
        var pdt = new Product(10, 100);
        Console.WriteLine(pdt);

        pdt.Discount = 10;
        Console.WriteLine(pdt);

        // Init readonly properties via the constructor
        // and init non-readonly via initializer
        pdt = new Product(11, 200)
        {
            Discount = 55,
            IsSold = false
        };
        Console.WriteLine(pdt);

        var sc = new ShoppingCart
        {
            Products = new List<Product>
            {
                new Product(10, 100) { Discount = 10 },
                new Product(11, 200) { Discount = 15 },
                new Product(12, 150) { Discount = 18 }
            }
        };
        Console.WriteLine(sc);

        // JSON serialization is simpler than writing a complex ToString() method
        var jsonString = JsonConvert.SerializeObject(sc, Formatting.Indented);
        Console.WriteLine(jsonString);

        // Get a specific product from the shopping cart
        Console.WriteLine(sc.GetProduct(0));

        // Use of indexer as an alternative to GetProduct()
        Console.WriteLine(sc[0]);
    }
}
