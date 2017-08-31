using System;
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
            SetUpInfrastructure();
           _logger.LogInformation("Press any key to start, 'N' to exist");

            var key = Console.ReadKey();
            Console.Clear();
            if (key.Key != ConsoleKey.N)
            {
                Play();
            }

            Console.ReadLine();
        }

        private static void SetUpInfrastructure()
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

        private static void Play()
        {
            var game = _serviceProvider.GetService<IGame>();
            game.Instruct();
            game.StartPlay();
        }

    }
}
