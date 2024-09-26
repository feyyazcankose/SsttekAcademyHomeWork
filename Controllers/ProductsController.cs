using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SsttekAcademyHomeWork.Models;

namespace SsttekAcademyHomeWork.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = new List<Product>(){
                new Product(){Id = 1, Name = "Product 1", Description = "Description 1", Price = 100},
                new Product(){Id = 2, Name = "Product 2", Description = "Description 2", Price = 200},
                new Product(){Id = 3, Name = "Product 3", Description = "Description 3", Price = 300},
                new Product(){Id = 4, Name = "Product 4", Description = "Description 4", Price = 400},
                new Product(){Id = 5, Name = "Product 5", Description = "Description 5", Price = 500},
            };

            return View(products);
        }

        public IActionResult Detail(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}