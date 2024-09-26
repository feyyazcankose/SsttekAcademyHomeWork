using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SsttekAcademyHomeWork.Models.Repositories;
using SsttekAcademyHomeWork.Models.Services;

namespace SsttekAcademyHomeWork.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService productService = new ProductService();
        public IActionResult Index()
        {
            var products = productService.GetProducts();

            return View(products);
        }

        public IActionResult Detail(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}