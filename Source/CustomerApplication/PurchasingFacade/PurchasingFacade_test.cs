using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purchasing.Facade.DTOs;

namespace Purchasing.Facade
{
    public class PurchasingFacade_test : IPurchasingFacade
    {
        private List<OrderedItemsDTO> testOrderedItems;
        private List<OrderAddressDTO> testOrderAddress;
        private List<OrdersDTO> testOrders;
        private List<InvoiceDTO> testInvoices;
        private List<OrderHistoryDTO> testOrderHistory;

        public PurchasingFacade_test()
        {
            testOrderAddress = new List<OrderAddressDTO>()
            {
                new OrderAddressDTO() { Address1 = "TestAddress1", Address2 = "TestAddress2", Address3 = "TestAddress3", City = "TestCity", Country = "TestCountry", County = "TestCounty", PostCode = "TestPostCode" },
                new OrderAddressDTO() { Address1 = "TestAddress1", Address2 = "TestAddress2", Address3 = "TestAddress3", City = "TestCity", Country = "TestCountry", County = "", PostCode = "TestPostCode" },
                new OrderAddressDTO() { Address1 = "TestAddress1A", Address2 = "TestAddress2A", Address3 = "TestAddress3A", City = "TestCityA", Country = "TestCountryA", County = "TestCountyA", PostCode = "TestPostCodeA" },
                new OrderAddressDTO() { Address1 = "TestAddress1B", Address2 = "TestAddress2B", Address3 = "TestAddress3B", City = "TestCityB", Country = "TestCountryB", County = "TestCountyB", PostCode = "TestPostCodeB" },
            };

            testOrderedItems = new List<OrderedItemsDTO>()
            {
                new OrderedItemsDTO() { ItemEAN = "TestCRNA", ItemDesc = "TestDescA", ItemName = "TestNameA", ItemQuanity = 10, ItemUnitPrice = 10.29 },
                new OrderedItemsDTO() { ItemEAN = "TestCRNB", ItemDesc = "TestDescB", ItemName = "TestNameB", ItemQuanity = 1, ItemUnitPrice = 1.29 },
                new OrderedItemsDTO() { ItemEAN = "TestCRNC", ItemDesc = "TestDescC", ItemName = "TestNameC", ItemQuanity = 5, ItemUnitPrice = 5.99 },
                new OrderedItemsDTO() { ItemEAN = "TestCRND", ItemDesc = "TestDescD", ItemName = "TestNameD", ItemQuanity = 2, ItemUnitPrice = 2.00 },
            };

            testOrders = new List<OrdersDTO>()
            {
                new OrdersDTO() { CustomerNo = "P44_54", BillingAddress = testOrderAddress[0], ShippingAddress = testOrderAddress[0], OrderedItems = new List<OrderedItemsDTO>() { testOrderedItems[0], testOrderedItems[1]} },
                new OrdersDTO() { CustomerNo = "P86_44", BillingAddress = testOrderAddress[1], ShippingAddress = testOrderAddress[2], OrderedItems = new List<OrderedItemsDTO>() { testOrderedItems[2], testOrderedItems[3]} }
            };

            testInvoices = new List<InvoiceDTO>()
            {
                new InvoiceDTO() { InvoiceNo = "I00000001", OrderList = new List<OrdersDTO>() { testOrders[0] }, SentToCustomer = true, InvoiceDate = new DateTime(2017, 01, 02, 10, 20, 0) },
                new InvoiceDTO() { InvoiceNo = "I00000002", OrderList = new List<OrdersDTO>() { testOrders[1] }, SentToCustomer = false, InvoiceDate = new DateTime(2017, 01, 20, 10, 20, 0) },
            };

            testOrderHistory = new List<OrderHistoryDTO>()
            {
                new OrderHistoryDTO() { PurchaseOrderNo = "P00000001", CustomerNo = "P44_54", OrderStatusDescription = "Complete", OrderedItems = new List<OrderedItemsDTO>() { testOrderedItems[0] }, BillingAddress = testOrderAddress[0], ShippingAddress = testOrderAddress[0] }
            };
        }


        public IEnumerable<InvoiceDTO> getInvoices(string orderNo, string customerNo)
        {
            return testInvoices.Where(x => x.OrderList.Any(o => o.PurchaseOrderNo == orderNo));
        }

        public IEnumerable<OrderHistoryDTO> getOrderHistory(string customerNo)
        {
            return testOrderHistory.Where(x => x.CustomerNo == customerNo);
        }

        public bool Purchase(OrderingDTO order)
        {
            var v = new OrdersDTO() { CustomerNo = order.CustomerNo, BillingAddress = order.BillingAddress, ShippingAddress = order.ShippingAddress, OrderedItems = order.OrderedItems };
            testOrders.Add(v);
            return true;
        }
    }
}
