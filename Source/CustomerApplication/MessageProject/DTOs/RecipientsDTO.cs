using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Facade.DTOs
{
    public class RecipientsDTO
    {
        public virtual int Id { get; set; }
        public virtual MessagesDTO Message { get; set; }
        public virtual string RecipientNo { get; set; }
    }
}
