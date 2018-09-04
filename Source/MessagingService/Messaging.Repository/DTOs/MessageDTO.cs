using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Repository.DTOs
{
    public class MessageDTO
    {
        public virtual int Id { get; set; }
        public virtual string SenderNo { get; set; }
        public virtual string Contents { get; set; }
        public virtual List<string> Recipients { get; set; }
    }
}
