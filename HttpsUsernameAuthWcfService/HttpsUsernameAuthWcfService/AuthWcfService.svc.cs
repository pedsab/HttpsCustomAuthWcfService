using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HttpsUsernameAuthWcfService.Contracts;

namespace HttpsUsernameAuthWcfService
{
    public class AuthWcfService : IAuthWcfService
    {
        public string Hi(string firstname)
        {
            return $"Hello, {firstname}";
        }

        public string SayHello(CustomerContract customer)
        {
            return $"Hello, {customer.firstname} {customer.lastname}";
        }
    }
}
