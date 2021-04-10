using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Configuration
{
    public class AuthOptions
    {
        public readonly static string Auth = "Auth";

        public string UserTokenSecret { get; set; }
    }
}
