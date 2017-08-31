using System.Collections.Generic;

namespace GTA.Models
{
    public class Property
    {
        public Property()
        {
            AnimalProperties = new List<AnimalProperty>();
        }

        public Property(string name, string question)
        {
            Name = name;
            Question = question;
            AnimalProperties = new List<AnimalProperty>();
        }

        public long PropertyId { get; set; }

        public string Name { get; set; }

        public bool Answer { get; set; }

        public string Question { get; set; }

        public virtual ICollection<AnimalProperty> AnimalProperties { get; set; }
    }
}
