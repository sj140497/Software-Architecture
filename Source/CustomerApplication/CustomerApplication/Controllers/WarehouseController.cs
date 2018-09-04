using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Warehouse.Facade;
using Warehouse.Facade.DTOs;
using Purchasing.Facade;
using Purchasing.Facade.DTOs;

namespace CustomerApplication.Controllers
{
    public class WarehouseController : Controller
    {

        private IWarehouseFacade warehouseFacade;
        private IWarehouseFacade warehouseFacadeTest;
        private IPurchasingFacade purchasingFacade;

        private IMapper mapper;
        private MapperConfiguration MapConfig;

        public WarehouseController()
        {
            this.warehouseFacade = new WarehouseFacade();
            this.purchasingFacade = new PurchasingFacade();
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductsDTO, ViewModels.ProductsVM>();
                cfg.CreateMap<ProductDetailDTO, ViewModels.ProductDetailVM>();
                cfg.CreateMap<OrderHistoryDTO, ViewModels.OrderHistoryVM>();
                cfg.CreateMap<OrdersDTO, ViewModels.InvoiceOrderVM>();
                cfg.CreateMap<OrderedItemsDTO, ViewModels.OrderedItemsVM>();
                cfg.CreateMap<OrderAddressDTO, ViewModels.OrderAddressVM>();
                cfg.CreateMap<InvoiceDTO, ViewModels.InvoiceVM>();
            });
            mapper = mapConfig.CreateMapper();
        }

        public WarehouseController(IWarehouseFacade warehouseFacadeTest, IPurchasingFacade purchasingFacadeTest)
        {
            this.warehouseFacade = warehouseFacadeTest;
            this.purchasingFacade = purchasingFacadeTest;
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductsDTO, ViewModels.ProductsVM>();
                cfg.CreateMap<ProductDetailDTO, ViewModels.ProductDetailVM>();
                cfg.CreateMap<OrderHistoryDTO, ViewModels.OrderHistoryVM>();
                cfg.CreateMap<OrdersDTO, ViewModels.InvoiceOrderVM>();
                cfg.CreateMap<OrderedItemsDTO, ViewModels.OrderedItemsVM>();
                cfg.CreateMap<OrderAddressDTO, ViewModels.OrderAddressVM>();
                cfg.CreateMap<InvoiceDTO, ViewModels.InvoiceVM>();
            });
            mapper = mapConfig.CreateMapper();
        }


        public ActionResult Index()
        {
            return View(warehouseFacade.getProducts().Select(p => mapper.Map<ProductsDTO, ViewModels.ProductsVM>(p)).ToList());
        }

        public ActionResult Details(string Ean)
        {
            return View(mapper.Map<ProductDetailDTO, ViewModels.ProductDetailVM>(warehouseFacade.getProductByEan(Ean)));
        }

        public ActionResult Invoices(string orderID)
        {
            var v = purchasingFacade.getInvoices(orderID, User.Identity.Name);
            if (v != null)
            {
                return View(mapper.Map<IEnumerable<InvoiceDTO>, IEnumerable<ViewModels.InvoiceVM>>(v));
            }
            return RedirectToAction("OrderHistory");
        }

        public ActionResult purchasingInformation(string Ean)
        {
            ViewBag.Ean = Ean;
            ViewModels.OrderVM vm = new ViewModels.OrderVM();
            return View(vm);
        }

        [HttpPost]
        public ActionResult purchasingInformation([Bind(Include = "CustomerNo,BillingAddress,ShippingAddress,purchaseAmount,Ean")] ViewModels.OrderVM order)
        {
            if (ModelState.IsValid)
            {
                var item = warehouseFacade.getProductByEan(order.Ean);

                var v = new OrderingDTO()
                {
                    CustomerNo = order.CustomerNo,
                    BillingAddress = new OrderAddressDTO()
                    {
                        Address1 = order.BillingAddress.Address1,
                        Address2 = order.BillingAddress.Address2,
                        Address3 = order.BillingAddress.Address3,
                        City = order.BillingAddress.City,
                        Country = order.BillingAddress.Country,
                        County = order.BillingAddress.County,
                        PostCode = order.BillingAddress.PostCode
                    },

                    ShippingAddress = new OrderAddressDTO()
                    {
                        Address1 = order.ShippingAddress.Address1,
                        Address2 = order.ShippingAddress.Address2,
                        Address3 = order.ShippingAddress.Address3,
                        City = order.ShippingAddress.City,
                        Country = order.ShippingAddress.Country,
                        County = order.ShippingAddress.County,
                        PostCode = order.ShippingAddress.PostCode
                    },
                    OrderedItems = new List<OrderedItemsDTO>()
                    {
                        new OrderedItemsDTO()
                        {
                            ItemEAN = order.Ean,
                            ItemDesc = item.Description,
                            ItemName = item.Name,
                            ItemQuanity = order.purchaseAmount,
                            ItemUnitPrice = item.Price
                        }
                    }
                };

                purchasingFacade.Purchase(v);

                List<PurchaseProductDTO> warehouseOrderedItems = new List<PurchaseProductDTO>()
                {
                    new PurchaseProductDTO()
                    {
                        Ean = order.Ean,
                        StockToRemove = order.purchaseAmount
                    }
                };

                warehouseFacade.purchaseProduct(warehouseOrderedItems);

                return RedirectToAction("Index");

            }
            return View(order);
        }

        public ActionResult OrderHistory(string userName)
        {
            var v = purchasingFacade.getOrderHistory(userName);
            if (v != null)
            {
                var orders = (mapper.Map<IEnumerable<OrderHistoryDTO>, IEnumerable<ViewModels.OrderHistoryVM>>(v));

                foreach (var o in orders)
                {
                    foreach (var i in o.OrderedItems)
                    {
                        if (i != o.OrderedItems.Last())
                        {
                            o.OrderedItemsString += i.ItemName + ", ";
                        }
                        else
                        {
                            o.OrderedItemsString += i.ItemName;
                        }
                    }
                }
                return View(orders);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}





