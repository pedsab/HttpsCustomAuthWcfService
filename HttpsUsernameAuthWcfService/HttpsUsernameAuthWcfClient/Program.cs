using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using HttpsUsernameAuthWcfService;

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

                /*******************/

                var customer = new Customer
                {
                    firstname = "pedro",
                    lastname = "sabino"
                };

                var serializer = new JavaScriptSerializer();
                var data = serializer.Serialize(customer);

                var responseText = client.UploadString(baseAddress + "/SayHello", data);

                var msg_sayhello = serializer.Deserialize<string>(responseText);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                if (channelFactory != null)
                    channelFactory.Abort();
            }
        }

    }

    class Customer
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
    }
}
