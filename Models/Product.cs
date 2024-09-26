using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SsttekAcademyHomeWork.Models
{
    public class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}