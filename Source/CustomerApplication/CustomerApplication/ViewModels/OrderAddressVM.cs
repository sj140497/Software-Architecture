using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerApplication.ViewModels
{
    public class OrderAddressVM
    {
        [StringLength(30)]
        [Required]
        public virtual string Address1 { get; set; }
        [StringLength(30)]
        [Required]
        public virtual string Address2 { get; set; }
        public virtual string Address3 { get; set; }
        public virtual string City { get; set; }
        [StringLength(30)]
        [Required]
        public virtual string Country { get; set; }
        public virtual string County { get; set; }
        [StringLength(30)]
        [DataType(DataType.PostalCode)]
        [Required]
        public virtual string PostCode { get; set; }
    }
}