using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsValidation.Models;

namespace ProductsValidation.Services
{
    public class Data
    {
        public List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Type = Product.Category.Toy, Name = "Toy1", Description = "Toy1 Description", Price = 10 },
            new Product { Id = 2, Type = Product.Category.Technique, Name = "Technique1", Description = "Technique1 Description", Price = 100 },
            new Product { Id = 3, Type = Product.Category.Clothes, Name = "Clothes1", Description = "Clothes1 Description", Price = 50 },
            new Product { Id = 4, Type = Product.Category.Transport, Name = "Transport1", Description = "Transport1 Description", Price = 200 },
            new Product { Id = 5, Type = Product.Category.Toy, Name = "Toy2", Description = "Toy2 Description", Price = 20 },
            new Product { Id = 6, Type = Product.Category.Technique, Name = "Technique2", Description = "Technique2 Description", Price = 150 },
            new Product { Id = 7, Type = Product.Category.Clothes, Name = "Clothes2", Description = "Clothes2 Description", Price = 70 },
            new Product { Id = 8, Type = Product.Category.Transport, Name = "Transport2", Description = "Transport2 Description", Price = 250 },
            new Product { Id = 9, Type = Product.Category.Toy, Name = "Toy3", Description = "Toy3 Description for Toy3", Price = 30 },
            new Product { Id = 10, Type = Product.Category.Technique, Name = "Technique3", Description = "Technique3 Description", Price = 120 }
        };

        public List<User> Users = new List<User>
        {
            new User() {Id = 1, Name = "UserAdmin", Email = "admin@gmail.com", Role = "admin"},
            new User() {Id = 2, Name = "Guest", Email = "guest@gmail.com", Role = "guest"},
            new User() {Id = 3, Name = "User", Email = "user1@gmail.com", Role = "user"},
            new User() {Id = 4, Name = "User2", Email = "user2@gmail.com", Role = "user"},
        };
    }
}
