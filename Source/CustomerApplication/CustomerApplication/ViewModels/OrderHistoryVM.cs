using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Purchasing.Facade.DTOs;
using System.ComponentModel.DataAnnotations;

namespace CustomerApplication.ViewModels
{
    public class OrderHistoryVM
    {
        [Display(Name = "Order Number")]
        public string PurchaseOrderNo { get; set; }
        public string CustomerNo { get; set; }
        [Display(Name = "Order Status")]
        public string OrderStatusDescription { get; set; }
        [Display(Name = "Purchased Items")]
        public string OrderedItemsString { get; set; }
        public OrderAddressDTO BillingAddress { get; set; }
        public OrderAddressDTO ShippingAddress { get; set; }
        public List<OrderedItemsDTO> OrderedItems { get; set; }
    }
}