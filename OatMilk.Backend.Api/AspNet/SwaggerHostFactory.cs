using Microsoft.Extensions.Hosting;

namespace OatMilk.Backend.Api.AspNet
{
    public class SwaggerHostFactory
    {
        public static IHost CreateHost()
        {
            return Program.CreateHostBuilder(new string[0]).Build();
        }
    }
}