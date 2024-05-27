using Microsoft.Extensions.Hosting;

namespace Adres.API
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder<Startup>(args)
                .Build()
                .Run();
        }
    }
}