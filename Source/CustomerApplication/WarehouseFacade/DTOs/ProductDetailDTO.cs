using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.Facade.DTOs
{
    public class ProductDetailDTO
    {
        public virtual string Ean { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string BrandName { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual int StockLevel { get; set; } //should only be able to see if customer
        public virtual double Price { get; set; }
    }
}