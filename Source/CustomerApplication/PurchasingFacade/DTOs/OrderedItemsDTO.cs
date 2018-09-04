using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Facade.DTOs
{
    public class OrderedItemsDTO
    {
        public virtual string ItemEAN { get; set; }
        public virtual string ItemName { get; set; }
        public virtual string ItemDesc { get; set; }
        public virtual int ItemQuanity { get; set; }
        public virtual double ItemUnitPrice { get; set; }
    }
}
