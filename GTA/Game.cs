using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Linq;
using GTA.Models;

namespace GTA
{
    /// <summary>
    /// Main gaming engine
    /// </summary>
    public class Game : IGame
    {
        private readonly ILogger<Game> _logger;

        private List<Animal> _animals;
        private List<Property> _questions;
        //private AnimalNode _root;
        private bool _gameWon = false;

        public Game(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Game>();
            _logger.LogInformation("Let's Play");
        
            using (var db = new GameContext())
            {
                Seeder.Seed(db);
                _animals = db.Set<Animal>().ToList();
                _questions = db.Set<Property>().ToList();
            }
        }

        //private void BuildAnimalTree(List<Animal> animals)
        //{
        //    _root = new AnimalNode();
        //    foreach (var question in _questions) 
        //    {
        //        _root.Question = question;
        //    }
        //}

        public void Instruct()
        {
            _logger.LogInformation("Please guess any animal out of the list I have");

            var i = 1;
            foreach (var animal in _animals)
            {
                _logger.LogInformation($"({i}) {animal.Name}");
                i++;
            }

            _logger.LogInformation("I will ask some questions now, please reply with (Y) for yes and (N) for no. Good Luck!");
        }
        
        public void StartPlay()
        {
            _logger.LogInformation("Press (Y) for yes and (N) for No");
            AskQuestions(_questions, _animals);
        }

        public void AskQuestions(List<Property> questions, List<Animal> animals)
        {
            try
            {
                foreach (var currentQuestion in questions)
                {
                    if (_gameWon) return; //exit condition

                    var foundAnimals = AskQuestion(currentQuestion, animals);

                    if (foundAnimals.Count() == 0) _logger.LogError("I'm sorry I lost. Please help me by adding the animal");

                    if (foundAnimals.Count() == 1)
                    {
                        _logger.LogInformation("###################################");
                        _logger.LogInformation($"YIPEE...You guessed the {foundAnimals.First().Name}");
                        _logger.LogInformation("###################################");
                        _gameWon = true;
                        return;
                    }

                    //More than 1 animal found, let's keep asking relevant questions
                    var remainingAnimals = foundAnimals.ToList();
                    var remainingQuestionIds = foundAnimals.SelectMany(a => a.AnimalProperties).Select(ap => ap.PropertyId).Distinct();
                    var remainingQuestions = questions.Where(q => q.PropertyId != currentQuestion.PropertyId && remainingQuestionIds.Contains(q.PropertyId)).ToList();
                    AskQuestions(remainingQuestions, remainingAnimals);
                }
                throw new AnimalNotFoundException();
            }
            catch (AnimalNotFoundException)
            {
                _logger.LogError("I'm sorry I lost. Please help me by adding the animal");
            }
        }

        private IEnumerable<Animal> AskQuestion(Property question, List<Animal> remainingAnimals)
        {
            _logger.LogInformation($"{question.Question}");
            var keyinfo = Console.ReadKey();
            question.Answer = keyinfo.Key == ConsoleKey.Y;

            return FindAnimals(question, remainingAnimals);
        }

        private IEnumerable<Animal> FindAnimals(Property answeredQuestion, List<Animal> remainingAnimals)
        {
            return answeredQuestion.Answer ?
                remainingAnimals.Where(a => a.HasProperty(answeredQuestion)) :
                remainingAnimals.Where(a => !a.HasProperty(answeredQuestion));
        }

    }

    /// <summary>
    /// Marker interface for DI
    /// </summary>
    public interface IGame
    {
        void Instruct();
        void StartPlay();
    }
}
