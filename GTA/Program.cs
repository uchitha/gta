using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GTA
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        private static ILogger<Program> _logger;

        static void Main(string[] args)
        {
            Startup();
            Seeder.Seed();

           _logger.LogInformation("Animals are now created. Press 'A' to start, any other key to exist");

            var key = Console.ReadKey();
            Console.Clear();
            if (key.Key == ConsoleKey.A)
            {
                Play();
            }

            Console.ReadLine();
        }

        private static void Play()
        {
            var game = _serviceProvider.GetService<IGame>();
            game.Instruct();
        }

        private static void Startup()
        {
            var services = new ServiceCollection();
            var start = new Startup();
            start.ConfigureServices(services);

            _serviceProvider = services.BuildServiceProvider();

            _serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            _logger = _serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
        }

       
    }
}
