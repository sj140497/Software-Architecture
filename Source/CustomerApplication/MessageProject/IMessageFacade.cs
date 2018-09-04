using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Facade
{
    public interface IMessageFacade
    {
        IEnumerable<DTOs.MessagesDTO> getMessages(string recipientID);
        bool deleteMessage(DTOs.MessageIdDTO messageID);
    }
}
