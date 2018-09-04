using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Message.Facade;
using Message.Facade.DTOs;
using CustomerApplication.Controllers;
using System.Web.Mvc;
using CustomerApplication.ViewModels;

namespace UnitTesting
{
    [TestFixture]
    public class MessageTester
    {

        [TestCase]
        public void MessageIndexTest()
        {
            MessageFacade_test messageFacade = new MessageFacade_test();
            MessageController messageController = new MessageController(messageFacade);

            var actual = (messageController.Index("C00000001") as ViewResult).ViewData.Model;
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(List<MessagesVM>), actual);
        }

        [TestCase]
        public void MessageDeleteTest()
        {
            MessageFacade_test messageFacade = new MessageFacade_test();
            MessageController messageController = new MessageController(messageFacade);

            var actual = (messageController.deleteMessage(2));
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(RedirectToRouteResult), actual);
        }
    }
}
