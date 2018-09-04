using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Messaging.Repository.DTOs
{
    public class SendMessageDTO { 

        public virtual string SenderNo { get; set; }
        public virtual string Contents { get; set; }
        public virtual List<string> Recipients { get; set; }    
    }
}