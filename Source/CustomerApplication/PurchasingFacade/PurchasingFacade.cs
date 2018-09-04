using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Purchasing.Facade.DTOs;
using System.Diagnostics;

namespace Purchasing.Facade
{
    public class PurchasingFacade : IPurchasingFacade
    {
        protected HttpClient client;
        public bool IsConnected { get; set; }

        public PurchasingFacade()
        {
            client = new HttpClient();
            try
            {
                //ConfigurationManager.AppSettings
                client.BaseAddress = new Uri("http://thamco-purchasingservice.azurewebsites.net/");
                IsConnected = true;
            }
            catch (Exception ex)
            {
                IsConnected = false;
            }
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        public PurchasingFacade(string address)
        {
            client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(address);
                IsConnected = true;
            }
            catch (Exception ex)
            {
                IsConnected = false;
            }
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        public bool Purchase(OrderingDTO order)
        {
            if (IsConnected)
            {
                try
                {
                    HttpResponseMessage response = client.PostAsJsonAsync("api/Orders/New", order).Result;
                    if (response.IsSuccessStatusCode)
                        return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception thrown: " + ex.Message);
                }
            }
            return false;
        }

        public IEnumerable<OrderHistoryDTO> getOrderHistory(string customerNo)
        {
            if (IsConnected)
            {
                try
                {
                    string apiString = String.Format("api/Orders?customerNo={0}", customerNo);
                    HttpResponseMessage response = client.GetAsync(apiString).Result;
                    if (response.IsSuccessStatusCode)
                        return response.Content.ReadAsAsync<IEnumerable<OrderHistoryDTO>>().Result;
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

        public IEnumerable<InvoiceDTO> getInvoices(string orderNo, string customerNo)
        {
            if (IsConnected)
            {
                try
                {
                    string apiString = String.Format("api/Invoices?orderNo={0}&customerNo={1}", orderNo, customerNo);
                    HttpResponseMessage response = client.GetAsync(apiString).Result;
                    if (response.IsSuccessStatusCode)
                        return response.Content.ReadAsAsync<IEnumerable<InvoiceDTO>>().Result;
                    else
                        Debug.WriteLine("Index received a bad response from the web service.");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception thrown " + ex.Message);
                }
            }
            return null;
        }
    }
}
