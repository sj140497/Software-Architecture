using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profile.Facade.DTOs;
using System.Web.Security;

namespace Profile.Facade
{
    public class ProfileFacade : IProfileFacade
    {
        private List<CustomerProfile> userProfiles;

        public ProfileFacade()
        {
            userProfiles = new List<CustomerProfile>()
            {
                new CustomerProfile { UserName = "User1", PasswordHash = SHA1.Encode("Password1"), FirstName = "Sean", LastName = "Johnson", Information = "information 2354fdg ew34", Verified = true },
                new CustomerProfile { UserName = "User2", PasswordHash = SHA1.Encode("Password2"), FirstName = "Darien", LastName = "LISP", Information = "Loves AI more than anything", Verified = false },
                new CustomerProfile { UserName = "C00000001", PasswordHash = SHA1.Encode("pw123"), FirstName = "Order", LastName = "Test", Information = "Verified User", Verified = true },
                new CustomerProfile { UserName = "C00000002", PasswordHash = SHA1.Encode("pw123"), FirstName = "Order", LastName = "Test", Information = "Unverified User", Verified = false },
            };
        }

        public CustomerProfile getCustomerProfile(string userName)
        {
            var v = userProfiles.Where(x => x.UserName == userName).FirstOrDefault();
            return v;
        }

        public bool editProfile(CustomerProfile edit)
        {
            return true;
        }

        public bool registerCustomer(CustomerLoginDTO user)
        {
            CustomerProfile newCustomer = new CustomerProfile() { UserName = user.UserName, PasswordHash = SHA1.Encode(user.Password), Verified = false };
            userProfiles.Add(newCustomer);
            var v = userProfiles.Where(x => x.UserName == user.UserName);
            if (v != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool loginAuth(UserDTO user)
        {
            FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
            return true;
        }
    }
}
