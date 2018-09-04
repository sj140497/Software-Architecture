using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerApplication.ViewModels
{
    public class InvoiceOrderVM
    {
        public string PurchaseOrderNo { get; set; }
        public string CustomerNo { get; set; }
        public int OrderStatusNo { get; set; }
        public string OrderStatusDescription { get; set; }
        public IEnumerable<OrderedItemsVM> OrderedItems { get; set; }
        public OrderAddressVM BillingAddress { get; set; }
        public OrderAddressVM ShippingAddress { get; set; }
        public string InvoiceNo { get; set; }
    }
}