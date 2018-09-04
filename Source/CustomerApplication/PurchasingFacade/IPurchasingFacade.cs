using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purchasing.Facade.DTOs;

namespace Purchasing.Facade
{
    public interface IPurchasingFacade
    {
        bool Purchase(OrderingDTO order);
        IEnumerable<OrderHistoryDTO> getOrderHistory(string customerNo);
        IEnumerable<InvoiceDTO> getInvoices(string orderNo, string customerNo);
    }
}
