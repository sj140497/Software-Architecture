using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Message.Facade.DTOs;

namespace Message.Facade
{
    public class MessageFacade_test : IMessageFacade
    {
        private List<MessagesDTO> testMessages;
        private List<RecipientsDTO> testRecipients;

        public MessageFacade_test()
        {
            testMessages = new List<MessagesDTO>()
            {
                new MessagesDTO { Id = 0, SenderNo = "P44_54", Contents = "Message 1" },
                new MessagesDTO { Id = 1, SenderNo = "P44_54", Contents = "Message 2" },
                new MessagesDTO { Id = 2, SenderNo = "P86_44", Contents = "Message 3" }
            };

            testRecipients = new List<RecipientsDTO>()
            {
                new RecipientsDTO {Id = 0, Message = testMessages[0], RecipientNo = "P44_54" },
                new RecipientsDTO {Id = 1, Message = testMessages[1], RecipientNo = "P44_54" },
                new RecipientsDTO {Id = 2, Message = testMessages[2], RecipientNo = "P86_44" }
            };
        }

        public IEnumerable<MessagesDTO> getMessages(string recipientID)
        {
            return testRecipients.Where(x => x.RecipientNo == recipientID).Select(x => x.Message);
        }

        public bool deleteMessage(MessageIdDTO messageID)
        {
            return true;
        }
    }
}

