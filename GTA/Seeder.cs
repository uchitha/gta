using GTA.Models;

namespace GTA
{
    public static class Seeder
    {
        public static void Seed(GameContext db)
        {
            CreateAnimals(db);
            db.SaveChanges();
            
        }

        private static void CreateAnimals(GameContext db)
        {
            var cow = new Animal { Name = "cow" };
            var dog = new Animal {Name = "dog"};
            var shark = new Animal { Name = "shark" };
            var eagle = new Animal { Name = "eagle" };
            var lion = new Animal { Name = "lion" };
            db.AddAnimals(cow, dog, shark, eagle, lion);
            db.SaveChanges();

            var mamalProperty = new Property("Mamal", "Is it a mamal?");
            var birdProperty = new Property("Bird", "Is it a bird?");
            var fishProperty = new Property("Fish", "Is it a fish?");
            var domesticProperty = new Property("Domestic", "Is it a domestic animal?");
            var farmProperty = new Property("Farm", "Is it a farm animal?");
            var wildProperty = new Property("Wild", "Is it a wild animal?");
            db.AddProperties(mamalProperty, birdProperty, fishProperty, domesticProperty, farmProperty, wildProperty);
            db.SaveChanges();

            cow.AddProperties(mamalProperty, farmProperty);
            dog.AddProperties(mamalProperty, domesticProperty);
            shark.AddProperties(fishProperty, wildProperty);
            eagle.AddProperties(birdProperty, wildProperty);
            lion.AddProperties(mamalProperty, wildProperty);
            //db.AddAnimalProperties(mamalProperty, birdProperty, fishProperty, domesticProperty, farmProperty, wildProperty);
            db.SaveChanges();

            
        }


    }
}
