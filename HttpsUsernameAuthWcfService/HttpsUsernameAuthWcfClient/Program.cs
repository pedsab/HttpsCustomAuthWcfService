using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

using HttpsUsernameAuthWcfService;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HttpsUsernameAuthWcfClient
{
    class Program
    {
        static void Main(string[] args)
        {

            ChannelFactory<IAuthWcfService> channelFactory = null;

            try
            {
                var baseAddress = "https://notprdspo0002.l3.corp/AuthWcfService/AuthWcfService.svc";

                var client = new WebClient();
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;

                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential("username", "password");

                JObject data = new JObject();
                data["firstname"] = "pedro";
                data["lastname"] = "sabino";

                var msg_sayhello = client.UploadString(baseAddress + "/SayHello", JsonConvert.SerializeObject(data));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                if (channelFactory != null)
                    channelFactory.Abort();
            }
        }
    }
}
