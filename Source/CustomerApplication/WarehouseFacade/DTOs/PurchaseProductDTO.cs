using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Facade.DTOs
{
    public class PurchaseProductDTO
    {
        public virtual string Ean { get; set; }
        public virtual int StockToRemove { get; set; }
    }
}
