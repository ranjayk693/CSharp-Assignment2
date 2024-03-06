using System;
using System.Collections.Generic;
using System.Linq;


//class of Product
class Product
{
    //setting the product property
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string Type { get; set; }

    //assigning items in constructor
    public Product(string name, double price, int quantity, string type){
        Name = name;
        Price = price;
        Quantity = quantity;
        Type = type;
    }
}
class Program
{
    static void Main(string[] args)
    {
        //creating list of items product
        List<Product> products = new List<Product>
        {
            new Product("lettuce", 10.5, 50, "Leafy green"),
            new Product("cabbage", 20, 100, "Cruciferous"),
            new Product("pumpkin", 30, 30, "Marrow"),
            new Product("cauliflower", 10, 25, "Cruciferous"),
            new Product("zucchini", 20.5, 50, "Marrow"),
            new Product("yam", 30, 50, "Root"),
            new Product("spinach", 10, 100, "Leafy green"),
            new Product("broccoli", 20.2, 75, "Cruciferous"),
            new Product("garlic", 30, 20, "Leafy green"),
            new Product("silverbeet", 10, 50, "Marrow")
        };

        // Print total number of item prduct and count of the product aslo
        Console.WriteLine("Total number of products: " + products.Count);

        // Add a new product potato and print  products with count
        products.Add(new Product("Potato", 10, 50, "Root"));
        PrintProducts(products);

        // Print products of type Leafy green
        var leafyGreens = products.Where(item => item.Type == "Leafy green");
        Console.WriteLine("\nProduct type Leafy green is:");
        foreach (var item in leafyGreens){
            //printing all the items in the console
            Console.WriteLine($"{item.Name}, {item.Price} RS, {item.Quantity}, {item.Type}");
        }

        // Remove garlic and print no. of product left.
        products.RemoveAll(item => item.Name == "garlic");
        Console.WriteLine("\nTotal number of items left after removing garlic: " + products.Count);

        // Add 50 cabbages and print the no. of cabbage
        Product cabbage = products.FirstOrDefault(item => item.Name == "cabbage");
        if (cabbage != null){
            cabbage.Quantity += 50;   //add more 50 cabbage to the existing count of cabbage
            Console.WriteLine("\nFinal quantity of cabbage in the inventory is: " + cabbage.Quantity);
        }

        // Calculate total price for the given purchases
        double totalPrice = CalculateTotalPrice(products, "lettuce", 1) +CalculateTotalPrice(products, "zucchini", 2) + CalculateTotalPrice(products, "broccoli", 1);
        Console.WriteLine("\nTotal price for the purchases is: " + totalPrice + " RS");
    }

    //function to print the list item
    static void PrintProducts(List<Product> products)
    {
        Console.WriteLine("\nList of all products:");
        foreach (var item in products)
        {
            Console.WriteLine($"{item.Name}, {item.Price} RS, {item.Quantity}, {item.Type}");
        }
        Console.WriteLine("Total number of products: " + products.Count);
    }

    //function to calculate the total price
    static double CalculateTotalPrice(List<Product> products, string productName, int quantity)
    {
        Product product = products.FirstOrDefault(item => item.Name == productName);
        if (product != null)
        {
            return product.Price * quantity;
        }
        return 0;
    }
}

