using Microsoft.AspNetCore.Mvc;
using MVCViewsDemo.Models;

namespace MVCViewsDemo.Controllers;

public class ProductsController : Controller
{
    private static readonly List<Product> _products = new()
    {
        new Product
        {
            Id = 1,
            Name = "Laptop Pro 15",
            Description = "High-performance laptop with 16GB RAM and 512GB SSD",
            Price = 1299.99m,
            Category = "Electronics",
            Stock = 25,
            ImageUrl = "",
            IsAvailable = true,
            CreatedAt = DateTime.Now.AddDays(-30)
        },
        new Product
        {
            Id = 2,
            Name = "Wireless Mouse",
            Description = "Ergonomic wireless mouse with long battery life",
            Price = 29.99m,
            Category = "Electronics",
            Stock = 150,
            ImageUrl = "",
            IsAvailable = true,
            CreatedAt = DateTime.Now.AddDays(-15)
        },
        new Product
        {
            Id = 3,
            Name = "Office Chair",
            Description = "Comfortable ergonomic office chair with lumbar support",
            Price = 349.99m,
            Category = "Furniture",
            Stock = 40,
            ImageUrl = "",
            IsAvailable = true,
            CreatedAt = DateTime.Now.AddDays(-7)
        },
        new Product
        {
            Id = 4,
            Name = "Standing Desk",
            Description = "Electric height-adjustable standing desk",
            Price = 599.99m,
            Category = "Furniture",
            Stock = 15,
            ImageUrl = "",
            IsAvailable = true,
            CreatedAt = DateTime.Now.AddDays(-3)
        },
        new Product
        {
            Id = 5,
            Name = "Mechanical Keyboard",
            Description = "RGB mechanical keyboard with Cherry MX switches",
            Price = 149.99m,
            Category = "Electronics",
            Stock = 0,
            ImageUrl = "",
            IsAvailable = false,
            CreatedAt = DateTime.Now.AddDays(-60)
        },
        new Product
        {
            Id = 6,
            Name = "Monitor 27\"",
            Description = "4K Ultra HD monitor with HDR support",
            Price = 449.99m,
            Category = "Electronics",
            Stock = 30,
            ImageUrl = "",
            IsAvailable = true,
            CreatedAt = DateTime.Now.AddDays(-10)
        },
        new Product
        {
            Id = 7,
            Name = "Desk Lamp",
            Description = "LED desk lamp with adjustable brightness",
            Price = 39.99m,
            Category = "Furniture",
            Stock = 80,
            ImageUrl = "",
            IsAvailable = true,
            CreatedAt = DateTime.Now.AddDays(-5)
        },
        new Product
        {
            Id = 8,
            Name = "Webcam HD",
            Description = "1080p webcam with built-in microphone",
            Price = 79.99m,
            Category = "Electronics",
            Stock = 55,
            ImageUrl = "",
            IsAvailable = true,
            CreatedAt = DateTime.Now.AddDays(-20)
        }
    };

    public IActionResult Index()
    {
        ViewData["Title"] = "Products";
        ViewBag.Categories = _products.Select(p => p.Category).Distinct().ToList();
        return View(_products);
    }

    public IActionResult Details(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        ViewData["Title"] = product.Name;
        return View(product);
    }

    public IActionResult ByCategory(string category)
    {
        var filteredProducts = string.IsNullOrEmpty(category)
            ? _products
            : _products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();

        ViewData["Title"] = string.IsNullOrEmpty(category) ? "All Products" : $"{category} Products";
        ViewBag.Categories = _products.Select(p => p.Category).Distinct().ToList();
        ViewBag.CurrentCategory = category;

        return View("Index", filteredProducts);
    }
}
