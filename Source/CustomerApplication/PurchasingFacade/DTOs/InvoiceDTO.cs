using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Facade.DTOs
{
    public class InvoiceDTO
    {
        public virtual string InvoiceNo { get; set; }
        public virtual DateTime InvoiceDate { get; set; }
        public bool SentToCustomer { get; set; }
        public IEnumerable<OrdersDTO> OrderList { get; set; } //OrderList.FirstOrDefault().CustomerNo (to find customer)
    }
}
