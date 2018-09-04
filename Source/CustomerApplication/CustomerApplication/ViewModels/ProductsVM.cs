using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerApplication.ViewModels
{
    public class ProductsVM
    {
        public virtual string Ean { get; set; }
        public virtual string Name { get; set; }
        [Display(Name = "Brand Name")]
        public virtual string BrandName { get; set; }
        [Display(Name = "Category Name")]
        public virtual string CategoryName { get; set; }
        public virtual double Price { get; set; }

    }
}