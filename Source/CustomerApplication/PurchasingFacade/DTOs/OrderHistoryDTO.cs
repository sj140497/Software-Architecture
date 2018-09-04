using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Facade.DTOs
{
    public class OrderHistoryDTO
    {
        public string PurchaseOrderNo { get; set; }
        public string CustomerNo { get; set; }
        public string OrderStatusDescription { get; set; }
        public List<OrderedItemsDTO> OrderedItems { get; set; }
        public OrderAddressDTO BillingAddress { get; set; }
        public OrderAddressDTO ShippingAddress { get; set; }
    }
}
