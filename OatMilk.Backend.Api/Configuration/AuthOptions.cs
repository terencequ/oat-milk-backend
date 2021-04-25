using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Configuration
{
    public class AuthOptions
    {
        public const string Auth = "Auth";

        public string UserTokenSecret { get; set; }
    }
}
