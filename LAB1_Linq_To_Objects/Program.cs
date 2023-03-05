using LAB1_Linq_To_Objects.Classes;
using LAB1_Linq_To_Objects.Enums;
using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace LAB1_Linq_To_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            Startup startup = new Startup();
            startup.ConfigureServices(services);

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<Runner>().Run();
        }
    }
}