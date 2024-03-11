using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsValidation.Models;
using ProductsValidation.Services;
using static ProductsValidation.Models.Product;

namespace ProductsValidation.Controllers
{

    public class ProductsController:Controller
    {
        private List<Product> myProducts;

        public ProductsController(Data data)
        {
            myProducts = data.Products;
        }
        private void InitializeTypes()
        {
            ViewBag.Types = new List<Category>() { Category.Toy, Category.Technique, Category.Clothes, Category.Transport };
        }

        public IActionResult Index(int filterId, string filtername)
        {
            return View(myProducts);
        }

        public IActionResult View(int id)
        {
            Product prod = myProducts.Find(prod => prod.Id == id);
            if (prod != null)
            {
                return View(prod);
            }

            return View("NotExists");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            InitializeTypes();
            Product prod = myProducts.Find(prod => prod.Id == id);
            if (prod != null)
            {
                return View(prod);
            }              

            return View("NotExists");
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            InitializeTypes();
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            myProducts[myProducts.FindIndex(prod => prod.Id == product.Id)] = product;
            return View("View", product);
        }

        [HttpGet]
        public IActionResult EditCategory(Product.Category category)
        {
            var ProductListByCategory = myProducts.Where(c => c.Type == category).ToList();

            return View(ProductListByCategory);
        }

        [HttpPost]
        public IActionResult EditCategory(List<Product> products)
        {
            for (int i = 0; i < products.Count(); i++)
            {
                myProducts[myProducts.FindIndex(p => p.Id == products.ElementAt(i).Id)] = products.ElementAt(i);
            }

            return RedirectToAction("Index", myProducts);
        }


        [HttpPost]
        public IActionResult Create(Product product)
        {
            InitializeTypes();
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            myProducts.Add(product);
            return View("View", product);
        }

        public IActionResult Create()
        {
            InitializeTypes();
            return View(new Product() { Id = myProducts.Last().Id + 1 });
        }

        public IActionResult Delete(int id)
        {
            myProducts.Remove(myProducts.Find(product => product.Id == id));
            return View("Index", myProducts);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
