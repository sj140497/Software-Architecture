using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerApplication.ViewModels
{
    public class MessagesVM
    {
        public virtual int Id { get; set; }
        [Display(Name = "Sender Number")]
        public virtual string SenderNo { get; set; }
        public virtual string Contents { get; set; }
    }
}