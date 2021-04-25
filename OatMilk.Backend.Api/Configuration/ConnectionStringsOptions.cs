using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Configuration
{
    public class ConnectionStringsOptions
    {
        public const string ConnectionStrings = "ConnectionStrings";
        public string MainDatabase { get; set; }
    }
}
