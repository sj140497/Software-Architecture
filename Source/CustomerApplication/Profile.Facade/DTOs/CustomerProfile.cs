using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Profile.Facade.DTOs
{
    public class CustomerProfile
    {
        public virtual string UserName { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Information { get; set; }
        public virtual bool Verified { get; set; }
    }
}