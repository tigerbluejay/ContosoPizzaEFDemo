using ContosoPizzaEFDemo.Data;
using ContosoPizzaEFDemo.Models;

using ContosoPizzaContext context = new ContosoPizzaContext();

////// TO ADD PRODUCTS TO THE DB
//////Product veggieSpecial = new Product()
//////{
//////    Name = "Veggie Special Pizza",
//////    Price = 9.99M
//////};

//////context.Products.Add(veggieSpecial);

//////Product deluxeMeat = new Product()
//////{
//////    Name = "Deluxe Meat Pizza",
//////    Price = 12.99M
//////};

//////context.Add(deluxeMeat);

//////context.SaveChanges();

//// TO READ PRODUCTS FROM THE DB: USE FLUENT API SYNTAX OR LINQ SYNTAX
//var products = context.Products
//                .Where(p => p.Price > 10.00M)
//                .OrderBy(p => p.Name);
var products = from product in context.Products
               where product.Price > 10.00M
               orderby product.Name
               select product;

foreach (Product p in products)
{
    Console.WriteLine($"Id: {p.Id}");
    Console.WriteLine($"Name: {p.Name}");
    Console.WriteLine($"Price: {p.Price}");
    Console.WriteLine(new string('-', 20));
}

/// TO UPDATE PRODUCTS IN THE DB:

var veggieSpecial = context.Products
        .Where(p => p.Name == "Veggie Special Pizza")
        .FirstOrDefault();

if (veggieSpecial is Product)
{
    veggieSpecial.Price = 10.99M;
}

context.SaveChanges();

/// TO DELETE FROM THE DATABASE

var veggieSpecialDel = context.Products
        .Where(p => p.Name == "Veggie Special Pizza")
        .FirstOrDefault();

if (veggieSpecialDel is Product)
{
    context.Remove(veggieSpecialDel);
}

context.SaveChanges();