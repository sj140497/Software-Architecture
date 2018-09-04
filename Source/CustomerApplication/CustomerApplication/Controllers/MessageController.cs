using AutoMapper;
using Message.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Message.Facade.DTOs;

namespace CustomerApplication.Controllers
{
    public class MessageController : Controller
    {
        private IMessageFacade messageFacade;

        private IMapper mapper;
        private MapperConfiguration MapConfig;

        public MessageController()
        {
            this.messageFacade = new MessageFacade();
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MessagesDTO, ViewModels.MessagesVM>();
            });
            mapper = mapConfig.CreateMapper();
        }

        public MessageController(IMessageFacade messageFacade)
        {
            this.messageFacade = messageFacade;
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MessagesDTO, ViewModels.MessagesVM>();
            });
            mapper = mapConfig.CreateMapper();
        }


        // GET: Message
        public ActionResult Index(string recipientID)
        {
            var v = messageFacade.getMessages(recipientID).Select(m => mapper.Map<MessagesDTO, ViewModels.MessagesVM>(m)).ToList();
            if (v != null)
            {
                return View(v);
            }
            return RedirectToAction("Index", "Home");
            }


        public ActionResult deleteMessage(int id)
        {
            MessageIdDTO messageID = new MessageIdDTO()
            {
                MessageID = id
            };
            messageFacade.deleteMessage(messageID);

            return RedirectToAction("Index");
        }
            

        }

    }
