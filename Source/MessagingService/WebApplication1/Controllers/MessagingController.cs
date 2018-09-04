using Messaging.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Messaging.Repository.DTOs;

namespace ICA1T3.Controllers
{
    public class MessagingController : ApiController
    {

        private IMessageRepository messageRepository;

        public MessagingController()
        {
            this.messageRepository = new MessageRepository();
        }

        public MessagingController(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }


        //GET: api/Messages/RECIPIENTID
        [HttpGet]
        [Route("api/Messages")]
        public IEnumerable<MessageDTO> GetMessagesByRecipID(string recipientID)
        {
            return messageRepository.GetMessagesByRecipID(recipientID);
        }

        [HttpGet]
        [Route("api/MessagesBySender")]
        public IEnumerable<MessageDTO> GetMessagesBySenderID(string senderID)
        {
            return messageRepository.GetMessagesBySenderID(senderID);
        }

        //POST: api/SendMessage
        [HttpPost]
        [Route("api/SendMessage")]
        public virtual IHttpActionResult SendMessage(SendMessageDTO sentMsgDTO) 
        {
            var v = messageRepository.SendMessage(sentMsgDTO);

            if (v != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        [Route("api/DeleteMessage")]
        public virtual IHttpActionResult DeleteMessage(MessageIdDTO messageID)
        {
            messageRepository.DeleteMessage(messageID.MessageID);
            var v = messageRepository.GetMessageByID(messageID.MessageID);
            if (v == null)
            {
                return Ok();
            }
            else { return BadRequest(); }
        }
    }
}
