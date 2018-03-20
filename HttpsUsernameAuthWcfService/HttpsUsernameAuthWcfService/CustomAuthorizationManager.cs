using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

namespace HttpsUsernameAuthWcfService
{
    public class CustomAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            var authorizationHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];

            if ((authorizationHeader != null) && (authorizationHeader != string.Empty))
            {
                var credentials = System.Text.ASCIIEncoding.ASCII
                    .GetString(Convert.FromBase64String(authorizationHeader.Substring(6)))
                    .Split(':');

                var user = new
                {
                    Name = credentials[0],
                    Password = credentials[1]
                };

                if ((user.Name == "username" && user.Password == "password"))
                {
                    return true;
                }
                else
                {
                    WebOperationContext.Current.OutgoingResponse.Headers.Add("WWW-Authenticate: Basic realm=\"AuthWcfService\"");
                    throw new WebFaultException(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.Headers.Add("WWW-Authenticate: Basic realm=\"AuthWcfService\"");
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }
        }
    }
}