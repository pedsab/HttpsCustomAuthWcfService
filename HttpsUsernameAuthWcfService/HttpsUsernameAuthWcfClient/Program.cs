using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

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
                // endereço onde o .wcf está publicado
                var endpointAddress = new EndpointAddress("https://notprdspo0002.l3.corp/AuthWcfService/AuthWcfService.svc/AuthWcfService");

                var binding = new WSHttpBinding();
                binding.Security.Mode = SecurityMode.TransportWithMessageCredential;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;

                channelFactory = new ChannelFactory<IAuthWcfService>(binding, endpointAddress);

                // usuario e senha que serão validados pelo CustomValidator
                channelFactory.Credentials.UserName.UserName = "username";
                channelFactory.Credentials.UserName.Password = "password";

                var channel = channelFactory.CreateChannel();

                Console.WriteLine("Calling SayHello operation...");

                // chamada do método
                string result = channel.SayHello("Pedro");

                Console.WriteLine($"SayHello operation result: {result}");
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
