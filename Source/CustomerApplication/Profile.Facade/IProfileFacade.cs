using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profile.Facade.DTOs;


namespace Profile.Facade
{
    public interface IProfileFacade
    {
        CustomerProfile getCustomerProfile(string userName);
        bool registerCustomer(CustomerLoginDTO user);
        bool editProfile(CustomerProfile edit);
        bool loginAuth(UserDTO user);
    }
}
