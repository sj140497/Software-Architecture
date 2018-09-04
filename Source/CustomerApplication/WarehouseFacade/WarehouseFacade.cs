using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Facade.DTOs;

namespace Warehouse.Facade
{
    public class WarehouseFacade : IWarehouseFacade
    {
        protected HttpClient client;
        public bool IsConnected { get; set; }

        public WarehouseFacade()
        {
            client = new HttpClient();
            try
            {
            //ConfigurationManager.AppSettings
                client.BaseAddress = new Uri("http://thamcowarehouseservice.azurewebsites.net/");
                IsConnected = true;
            }
            catch (Exception ex)
            {
                IsConnected = false;
            }
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        public WarehouseFacade(string address)
        {
            client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(address);
                IsConnected = true;
            }
            catch(Exception ex)
            {
                IsConnected = false;
            }
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        public IEnumerable<ProductsDTO> getProducts() //Needs filtering to be figured out
        {
            if (IsConnected)
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync("api/StoreProducts").Result;
                    if (response.IsSuccessStatusCode)
                        return response.Content.ReadAsAsync<IEnumerable<ProductsDTO>>().Result;
                    else
                        Debug.WriteLine("Index received a bad response from the web service.");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception thrown: " + ex.Message);
                }
            }
            return null;
        }

        public ProductDetailDTO getProductByEan(string Ean)
        {
            if (IsConnected)
            {
                try
                {
                    string apiString = String.Format("api/StoreProductDetails?Ean={0}", Ean);
                    HttpResponseMessage response = client.GetAsync(apiString).Result;
                    if (response.IsSuccessStatusCode)
                        return response.Content.ReadAsAsync<ProductDetailDTO>().Result;
                    else
                        Debug.WriteLine("Index received a bad response from the web service.");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception thrown: " + ex.Message);
                }
            }
            return null;
        }

        //No Http response
        public bool purchaseProduct(List<PurchaseProductDTO> purchaseProduct)
        {
            if (IsConnected)
            {
                try
                {
                    var reponse = client.PostAsJsonAsync("api/RemoveStock", purchaseProduct).Result;
                    if (reponse.IsSuccessStatusCode)
                        return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception thrown: " + ex.Message);
                }
            }
            return false;
        }
    }
}
