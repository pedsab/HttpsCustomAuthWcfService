using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;

namespace HttpsUsernameAuthWcfService
{
    public class CustomValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == "username" && password == "password")
                return;

            throw new SecurityTokenException("Invalid user");
        }
    }
}