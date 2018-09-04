using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Message.Facade.DTOs;
using System.Net.Http;
using System.Configuration;
using System.Diagnostics;

namespace Message.Facade
{
    public class MessageFacade : IMessageFacade
    {

        protected HttpClient client;
        public bool IsConnected { get; set; }

        public MessageFacade()
        {
            client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri("http://thamco-messagingservice.azurewebsites.net/");
                IsConnected = true;
            }
            catch (Exception ex)
            {
                IsConnected = false;
            }
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        public MessageFacade(string address)
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
        public IEnumerable<MessagesDTO> getMessages(string recipientID)
        {
            if (IsConnected)
            {
                try
                {
                    string apiString = String.Format("api/Messages?recipientID={0}", recipientID);
                    HttpResponseMessage response = client.GetAsync(apiString).Result;
                    if (response.IsSuccessStatusCode)
                        return response.Content.ReadAsAsync<IEnumerable<MessagesDTO>>().Result;
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
        public bool deleteMessage(MessageIdDTO messageID)
        {
            if (IsConnected)
            {
                try
                {                     
                    var response = client.PostAsJsonAsync("api/DeleteMessage/", messageID).Result;
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
    }
}
