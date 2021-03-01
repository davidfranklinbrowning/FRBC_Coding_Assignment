using FRBC_Coding_Assignment.Services;
using FRBC_Coding_Assignment.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace FRBC_Coding_Assignment
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        private static IServiceProvider serviceProvider;

        public static void Main()
        {
            RegisterServices();
            IServiceScope scope = serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<ConsoleApp>().Run();
            DisposeServices();

        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IStringCleanerService, StringCleanerService>();
            services.AddSingleton<IPorterStemmingService, PorterStemmingService>();
            services.AddSingleton<ConsoleApp>();
            serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (serviceProvider == null)
            {
                return;
            }
            if (serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}