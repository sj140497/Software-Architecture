using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Facade.DTOs
{
    public class OrderingDTO
    {
        public virtual string CustomerNo { get; set; }
        public virtual List<OrderedItemsDTO> OrderedItems { get; set; }
        public virtual OrderAddressDTO BillingAddress { get; set; }
        public virtual OrderAddressDTO ShippingAddress { get; set; }
    }
}
