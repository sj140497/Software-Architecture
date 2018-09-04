using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Facade.DTOs
{
    public class OrderAddressDTO
    {
        public virtual string Address1 { get; set; }
        public virtual string Address2 { get; set; }
        public virtual string Address3 { get; set; }
        public virtual string City { get; set; }
        public virtual string Country { get; set; }
        public virtual string County { get; set; }
        public virtual string PostCode { get; set; }
    }
}
