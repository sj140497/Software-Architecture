using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Facade.DTOs
{
    public class UserDTO
    {
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual Boolean RememberMe { get; set; }
    }
}
