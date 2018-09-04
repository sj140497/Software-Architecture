using Messaging.Repository;
using Messaging.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IMessageRepository messageRepository;

        public HomeController()
        {
            //this.messageRepository = new MessageRepository();
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:51503");
            //client.DefaultRequestHeaders.Accept.ParseAdd("application/json");

            //var message = new SendMessageDTO()
            //{
            //    Contents = "Test",
            //    SenderNo = "C1010111",
            //    Recipients = new List<string>()
            //    {
            //        "TEST1", "TEST2"
            //    }
            //};
            //var response = client.PostAsJsonAsync("api/SendMessage", message).Result;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}