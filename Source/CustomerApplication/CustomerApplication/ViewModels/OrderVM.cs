using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Purchasing.Facade.DTOs;
using System.ComponentModel.DataAnnotations;

namespace CustomerApplication.ViewModels
{
    public class OrderVM
    {
        public string Ean { get; set; }

        [Display(Name = "Purchase Amount")]
        public int purchaseAmount { get; set; }
        [StringLength(9)] 
        [Required]
        public virtual string CustomerNo { get; set; }
        public virtual List<OrderedItemsDTO> OrderedItems { get; set; }
        [Required]
        public virtual OrderAddressDTO BillingAddress { get; set; }
        [Required]
        public virtual OrderAddressDTO ShippingAddress { get; set; }
    }
}