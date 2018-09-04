using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.Facade.DTOs
{
    public class ProductsDTO
    {
        public string Ean { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public double Price { get; set; }
    }
}