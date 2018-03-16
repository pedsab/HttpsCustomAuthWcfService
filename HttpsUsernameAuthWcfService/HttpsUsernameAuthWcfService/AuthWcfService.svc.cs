using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HttpsUsernameAuthWcfService
{
    public class AuthWcfService : IAuthWcfService
    {
        public string SayHello(string name)
        {
            return $"Hello, {name}";
        }
    }
}
