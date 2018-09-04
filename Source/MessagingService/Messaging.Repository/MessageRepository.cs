using AutoMapper;
using Messaging.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Repository
{
    public class MessageRepository : IMessageRepository, IDisposable
    {
        private Model.Messagedb context;
        private IMapper mapper;
        private MapperConfiguration mapConfig;

        public MessageRepository()
        {
            context = new Model.Messagedb();
        var mapConfig = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Model.Messages, DTOs.MessageDTO>();
                cfg.CreateMap<DTOs.MessageDTO, Model.Messages>();
                cfg.CreateMap<DTOs.RecipientDTO, Model.Recipients>();
            });
            mapper = mapConfig.CreateMapper();

        }

        public void DeleteMessage(int messageID)
        {
            context.Recipients.RemoveRange(context.Recipients.Where(r => r.MessageId == messageID));

            var message = context.Messages.Find(messageID);
            context.Messages.Remove(message);
            save();
        }


        public IEnumerable<DTOs.MessageDTO> GetMessages()
        {
            return context.Messages.AsEnumerable().Select(x => mapper.Map<Model.Messages, DTOs.MessageDTO>(x)).ToList();
        } 

        public IEnumerable<DTOs.MessageDTO> GetMessagesByRecipID(string recipientID)
        {
            var message = context.Recipients.Where(x => x.RecipientNo == recipientID).Select(x => x.Message).ToList();
            return mapper.Map<IEnumerable<Model.Messages>, IEnumerable<DTOs.MessageDTO>>(message);
        } 

        public IEnumerable<DTOs.MessageDTO> GetMessagesBySenderID(string senderID)
        {
            var message = context.Messages.Where(x => x.SenderNo == senderID).ToList();
            return mapper.Map<IEnumerable<Model.Messages>, IEnumerable<DTOs.MessageDTO>>(message);
        }

        public DTOs.MessageDTO GetMessageByID(int id)
        {
            return mapper.Map<Model.Messages, DTOs.MessageDTO>(context.Messages.Find(id));
        }

        public void save()
        {
            context.SaveChanges();
        } 

        public DTOs.MessageDTO SendMessage(DTOs.SendMessageDTO sentMessage)
        {
            Model.Messages newMessage = new Model.Messages()
            {
                SenderNo = sentMessage.SenderNo,
                Contents = sentMessage.Contents
            };

            context.Messages.Add(newMessage);

            foreach(var recipient in sentMessage.Recipients)
            {
                Model.Recipients newRecipient = new Model.Recipients()
                {
                    Message = newMessage,
                    RecipientNo = recipient
                };
                context.Recipients.Add(newRecipient);
            }
            save();
            var messageReturn = mapper.Map<Model.Messages, DTOs.MessageDTO>(newMessage);
            return messageReturn;
        }

        public bool isMessagePresent(int id)
        {
            var msg = context.Messages.Where(x => x.Id == id);
            if (msg != null) {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
