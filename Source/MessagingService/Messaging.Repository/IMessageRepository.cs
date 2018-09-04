using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Messaging.Repository
{
    public interface IMessageRepository : IDisposable
    {
        IEnumerable<DTOs.MessageDTO> GetMessages();
        IEnumerable<DTOs.MessageDTO> GetMessagesByRecipID(string recipientID);
        DTOs.MessageDTO GetMessageByID(int id);
        DTOs.MessageDTO SendMessage(DTOs.SendMessageDTO sentMessage);
        void DeleteMessage(int messageID);
        IEnumerable<DTOs.MessageDTO> GetMessagesBySenderID(string senderID);
        void save();
    }
}
