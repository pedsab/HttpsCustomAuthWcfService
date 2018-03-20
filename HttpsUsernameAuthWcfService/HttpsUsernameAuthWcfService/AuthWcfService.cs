using HttpsUsernameAuthWcfService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HttpsUsernameAuthWcfService
{
    [ServiceContract]
    public interface IAuthWcfService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/SayHello")]
        string SayHello(CustomerContract customer);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Hi/{firstname}")]
        string Hi(string firstname);
    }
}
