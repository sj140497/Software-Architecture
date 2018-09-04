using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Facade.DTOs
{
    public class MessagesDTO
    {
        public virtual int Id { get; set; }
        public virtual string SenderNo { get; set; }
        public virtual string Contents { get; set; }
    }
}
