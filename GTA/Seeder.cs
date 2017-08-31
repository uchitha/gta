using System;
using System.Collections.Generic;
using System.Text;

namespace GTA
{
    public static class Seeder
    {
        public static void Seed()
        {
            using (var db = new GameContext())
            {
                CreateAnimals(db);
                db.SaveChanges();
            }
        }

        private static void CreateAnimals(GameContext db)
        {
            var cow = new Animal { Name = "cow" };
            var dog = new Animal {Name = "dog"};
            var shark = new Animal { Name = "shark" };
            var eagle = new Animal { Name = "eagle" };
            var lion = new Animal { Name = "lion" };

            var mamalProperty = new AnimalProperty("Mamal", "Is it a mamal?", "Yes");
            var birdProperty = new AnimalProperty("Bird", "Is it a bird?", "Yes");
            var fishProperty = new AnimalProperty("Fish", "Is it a fish?", "Yes");
            var domesticProperty = new AnimalProperty("Domestic", "Is it a domestic animal?", "Yes");
            var farmProperty = new AnimalProperty("Farm", "Is it a farm animal?", "Yes");
            var wildProperty = new AnimalProperty("Wild", "Is it a wild animal?", "Yes");

            cow.AddProperties(mamalProperty,farmProperty);
            dog.AddProperties(mamalProperty,domesticProperty);
            shark.AddProperties(fishProperty,wildProperty);
            eagle.AddProperties(birdProperty,wildProperty);
            lion.AddProperties(mamalProperty,wildProperty);

            db.AddAnimals(cow,dog,shark,eagle,lion);

        }


    }
}
