using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerApplication.ViewModels
{
    public class InvoiceVM
    {
        public virtual string InvoiceNo { get; set; }
        public virtual DateTime InvoiceDate { get; set; }
        public bool SentToCustomer { get; set; }
        public IEnumerable<OrderHistoryVM> OrderList { get; set; }
    }
}