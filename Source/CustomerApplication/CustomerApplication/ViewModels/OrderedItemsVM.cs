using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerApplication.ViewModels
{
    public class OrderedItemsVM
    {
        public string ItemEAN { get; set; }
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public int ItemQuantity { get; set; }
        public double ItemUnitPrice { get; set; }
    }
}