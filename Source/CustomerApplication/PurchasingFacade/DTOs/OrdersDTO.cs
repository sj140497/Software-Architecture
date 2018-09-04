using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Facade.DTOs
{
    public class OrdersDTO
    {
        public string PurchaseOrderNo { get; set; }
        public string CustomerNo { get; set; }
        public int OrderStatusNo { get; set; }
        public string OrderStatusDescription { get; set; }
        public IEnumerable<OrderedItemsDTO> OrderedItems { get; set; }
        public OrderAddressDTO BillingAddress { get; set; }
        public OrderAddressDTO ShippingAddress { get; set; }
        public string InvoiceNo { get; set; }
    }
}
