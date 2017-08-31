using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace GTA
{
    public class Game : IGame
    {
        private readonly ILogger<Game> _logger;
        private readonly GameContext _db;

        public Game(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Game>();
            _logger.LogInformation("Let's Play");

            _db = new GameContext();
        }

        public void Instruct()
        {
            _logger.LogInformation("Please guess any animal out of the list I have");

            var i = 1;
            foreach (var animal in _db.Animals)
            {
                _logger.LogInformation($"({i}) {animal.Name}");
                i++;
            }

            _logger.LogInformation("I will ask some questions now, please reply with (Y) for yes and (N) for no. Good Luck!");
        }
        
        public void 

    }

    public interface IGame
    {
        void Instruct();
    }
}
