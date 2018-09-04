using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Facade;
using Warehouse.Facade.DTOs;

namespace Warehouse.Facade
{
    public class WarehouseFacade_test : IWarehouseFacade
    {

        private List<ProductsDTO> productTests;
        private List<ProductDetailDTO> productDetailTest;

        public WarehouseFacade_test()
        {
            productTests = new List<ProductsDTO>()
            {
                new ProductsDTO { Ean = "S023 0234 E30D", Name = "Test number 1", BrandName = "Brand 1", CategoryName = "Category 1", Price = 20.99},
                new ProductsDTO { Ean = "S023 0234 E99C", Name = "Test number 2", BrandName = "Brand 2", CategoryName = "Category 2", Price = 5.45},
                new ProductsDTO { Ean = "S021 0255 E42G", Name = "Test number 3", BrandName = "Brand 3", CategoryName = "Category 3", Price = 10.00},
                new ProductsDTO { Ean = "S024 0777 E26B", Name = "Test number 4", BrandName = "Brand 4", CategoryName = "Category 4", Price = 1.50},
            };
            productDetailTest = new List<ProductDetailDTO>()
            {
                new ProductDetailDTO { Ean = "S023 0234 E99C", Name = "Test number 2", Description = "Desription 1", BrandName = "Brand 2", CategoryName = "Category 2", StockLevel = 5, Price = 5.45 }
            };
        }

        public ProductDetailDTO getProductByEan(string Ean)
        {
            return productDetailTest.Where(x => x.Ean == Ean).FirstOrDefault();
        }

        public IEnumerable<ProductsDTO> getProducts()
        {
            return productTests;
        }

        public bool purchaseProduct(List<PurchaseProductDTO> purchaseproduct)
        {
            return true;
        }
    }
}
