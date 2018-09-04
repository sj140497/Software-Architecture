using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerApplication.ViewModels
{
    public class ProductDetailVM
    {
        public virtual string Ean { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        [Display(Name = "Brand Name")]
        public virtual string BrandName { get; set; }
        [Display(Name = "Category Name")]
        public virtual string CategoryName { get; set; }
        [Display(Name = "Stock Level")]
        public virtual int StockLevel { get; set; } 
        public virtual double Price { get; set; }
        [Display(Name = "Purchase Amount")]
        public virtual string PurchaseAmount { get; set; }
    }
}