using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HttpsUsernameAuthWcfService.Contracts
{
    [DataContract]
    public class CustomerContract
    {
        [DataMember]
        public string firstname { get; set; }
        [DataMember]
        public string lastname { get; set; }
    }
}