using System.Collections.Generic;
using System.Linq;

namespace GTA.Models
{
    public class Animal
    {
        public Animal()
        {
            AnimalProperties = new List<AnimalProperty>();
        }

        public long AnimalId { get; set; }
        public string Name { get; set; }
        public ICollection<AnimalProperty> AnimalProperties { get; set; }

        public void AddProperties(params Property[] props)
        {
            foreach (var prop in props)
            {
                AnimalProperties.Add(new AnimalProperty { AnimalId = AnimalId, PropertyId = prop.PropertyId });
            }
        }

        public bool HasProperty(Property property)
        {
            return AnimalProperties.Any(p => p.PropertyId == property.PropertyId);
        }
    }
}
