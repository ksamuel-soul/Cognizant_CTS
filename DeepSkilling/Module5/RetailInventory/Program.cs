/*
using RetailInventory.Data;
using RetailInventory.Models;

using var context = new AppDbContext();

Console.WriteLine("Adding Initial Data...");

if (!context.Categories.Any())
{
    var electronics = new Category
    {
        Name = "Electronics"
    };

    var groceries = new Category
    {
        Name = "Groceries"
    };

    await context.Categories.AddRangeAsync(electronics, groceries);

    var laptop = new Product
    {
        Name = "Laptop",
        Price = 75000,
        Category = electronics
    };

    var riceBag = new Product
    {
        Name = "Rice Bag",
        Price = 1200,
        Category = groceries
    };

    await context.Products.AddRangeAsync(laptop, riceBag);

    await context.SaveChangesAsync();

    Console.WriteLine("Data inserted successfully.");
}
else
{
    Console.WriteLine("Data already exists.");
}
*/

/*
using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

using var context = new AppDbContext();

Console.WriteLine("All Products\n");

var products = await context.Products.ToListAsync();

foreach (var product in products)
{
    Console.WriteLine($"{product.Id} {product.Name} ₹{product.Price}");
}

Console.WriteLine();

var found = await context.Products.FindAsync(1);

Console.WriteLine($"Find By Id : {found?.Name}");

Console.WriteLine();

var expensive = await context.Products
    .FirstOrDefaultAsync(p => p.Price > 50000);

Console.WriteLine($"Expensive Product : {expensive?.Name}");
*/


using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

using var context = new AppDbContext();

var laptop = await context.Products
    .FirstOrDefaultAsync(p => p.Name == "Laptop");

if (laptop != null)
{
    laptop.Price = 70000;

    await context.SaveChangesAsync();

    Console.WriteLine("Laptop price updated.");
}

var rice = await context.Products
    .FirstOrDefaultAsync(p => p.Name == "Rice Bag");

if (rice != null)
{
    context.Products.Remove(rice);

    await context.SaveChangesAsync();

    Console.WriteLine("Rice Bag deleted.");
}