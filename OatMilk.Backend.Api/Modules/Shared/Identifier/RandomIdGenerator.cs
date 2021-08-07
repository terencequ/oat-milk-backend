using System;
using System.Text;

namespace OatMilk.Backend.Api.Modules.Shared.Identifier
{
    public static class RandomIdGenerator
    {
        private static readonly char[] Base36CharsWithoutVowels = 
            "0123456789BCDFGHJKLMNPQRSTVWXYZ"
                .ToCharArray();

        private static readonly Random Random = new Random();
        
        public static string GetBase36(int length) 
        {
            var sb = new StringBuilder(length);

            for (int i=0; i<length; i++) 
                sb.Append(Base36CharsWithoutVowels[Random.Next(31)]);

            return sb.ToString();
        }
    }
}