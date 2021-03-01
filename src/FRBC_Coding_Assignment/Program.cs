using FRBC_Coding_Assignment.Algorithms;
using FRBC_Coding_Assignment.Algorithms.Interfaces;
using FRBC_Coding_Assignment.Configurations;
using FRBC_Coding_Assignment.Services;
using FRBC_Coding_Assignment.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace FRBC_Coding_Assignment
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        private static IServiceProvider serviceProvider;
        public static IConfigurationRoot configuration;

        public static void Main()
        {
            RegisterServices();
            IServiceScope scope = serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<ConsoleApp>().Run();
            DisposeServices();

        }

        private static void RegisterServices()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("AppSettings.json", false)
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton(configuration);
            services
                .Configure<OccurrenceConfiguration>(configuration.GetSection("OccurrenceConfiguration"))
                .AddSingleton(sp => sp.GetRequiredService<IOptions<OccurrenceConfiguration>>().Value);
            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IStringCleanerService, StringCleanerService>();
            services.AddSingleton<IStopWordService, StopWordService>();
            services.AddSingleton<IPorterStemmingService, PorterStemmingService>();
            services.AddSingleton<IPorterStemmer, PorterStemmer>();
            services.AddSingleton<IWordOccurrenceService, WordOccurrenceService>();
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