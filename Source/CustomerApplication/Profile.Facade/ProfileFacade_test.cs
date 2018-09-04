using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profile.Facade.DTOs;

namespace Profile.Facade
{
    public class ProfileFacade_test : IProfileFacade
    {
        private List<CustomerProfile> userProfiles;

        public ProfileFacade_test()
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
            return true;
        }

        public bool loginAuth(UserDTO user)
        {
            return true;
        }
    }
}
