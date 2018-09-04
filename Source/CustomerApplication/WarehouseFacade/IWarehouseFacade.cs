using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Facade
{
    public interface IWarehouseFacade
    {
        IEnumerable<DTOs.ProductsDTO> getProducts();
        DTOs.ProductDetailDTO getProductByEan(string Ean);
        bool purchaseProduct(List<DTOs.PurchaseProductDTO> purchaseproduct);
    }
}
