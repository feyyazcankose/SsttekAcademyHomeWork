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
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.GetProducts());
        }

        public IActionResult Detail(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}