using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerApplication.Controllers;
using System.Web.Mvc;
using Warehouse.Facade;
using Warehouse.Facade.DTOs;
using Purchasing.Facade;
using Purchasing.Facade.DTOs;
using CustomerApplication.ViewModels;

namespace UnitTesting
{
    [TestFixture]
    public class WarehouseTester
    {
        [TestCase]
        public void WarehouseIndexTest()
        {
            WarehouseFacade_test warehouseFacadeTest = new WarehouseFacade_test();
            PurchasingFacade_test purchasingFacadeTest = new PurchasingFacade_test();
            WarehouseController warehouseController = new WarehouseController(warehouseFacadeTest, purchasingFacadeTest);

            var actual = (warehouseController.Index() as ViewResult).ViewData.Model;
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(List<ProductsVM>), actual);
            Assert.IsTrue(((List<ProductsVM>)actual).Count() > 0);
        }

        [TestCase]
        public void WarehouseDetailsTest()
        {
            WarehouseFacade_test warehouseFacadeTest = new WarehouseFacade_test();
            PurchasingFacade_test purchasingFacadeTest = new PurchasingFacade_test();
            WarehouseController warehouseController = new WarehouseController(warehouseFacadeTest, purchasingFacadeTest);

            var actual = (warehouseController.Details("S023 0234 E99C") as ViewResult).ViewData.Model;
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(ProductDetailVM), actual);
        }

        [Ignore("wont create DTO in method")]
        [TestCase]
        public void PurchasingTest()
        {
            WarehouseFacade_test warehouseFacadeTest = new WarehouseFacade_test();
            PurchasingFacade_test purchasingFacadeTest = new PurchasingFacade_test();
            WarehouseController warehouseController = new WarehouseController(warehouseFacadeTest, purchasingFacadeTest);

            var order = new OrderVM()
            {
                CustomerNo = "C00000001",
                BillingAddress = new OrderAddressDTO()
                {
                    Address1 = "Test Address 1",
                    Address2 = "Test Address 2",
                    Address3 = "Test Address 3",
                    City = "Test City",
                    Country = "Test Country",
                    County = "Test County",
                    PostCode = "Test PostCode"
                },

                ShippingAddress = new OrderAddressDTO()
                {
                    Address1 = "Test Address 1",
                    Address2 = "Test Address 2",
                    Address3 = "Test Address 3",
                    City = "Test City",
                    Country = "Test Country",
                    County = "Test County",
                    PostCode = "Test PostCode"
                },
                OrderedItems = new List<OrderedItemsDTO>()
                {
                    new OrderedItemsDTO()
                    {
                        ItemEAN = "S023 0234 E30D",
                        ItemDesc = "Test Desc",
                        ItemName = "Test number 1",
                        ItemQuanity = 5,
                        ItemUnitPrice = 10.50
                    }
                }
            };

            var result = (warehouseController.purchasingInformation(order) as ViewResult).ViewData.Model;

            Assert.IsInstanceOf(typeof(RedirectToRouteResult), result);
        }

        [TestCase]
        public void OrderHistoryTest()
        {
            WarehouseFacade_test warehouseFacadeTest = new WarehouseFacade_test();
            PurchasingFacade_test purchasingFacadeTest = new PurchasingFacade_test();
            WarehouseController warehouseController = new WarehouseController(warehouseFacadeTest, purchasingFacadeTest);

            var actual = (warehouseController.OrderHistory("P44_54") as ViewResult).ViewData.Model;
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(List<OrderHistoryVM>), actual);
            Assert.IsTrue(((List<OrderHistoryVM>)actual).Count() > 0);
        }
    }
}
        
