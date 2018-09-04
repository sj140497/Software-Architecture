using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Model
{
    public class Recipients
    {
        public virtual Messages Message { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public virtual int Id { get; set; }
        [ForeignKey("Message")]
        public virtual int MessageId { get; set; }
        public virtual string RecipientNo { get; set; }
    }
}
