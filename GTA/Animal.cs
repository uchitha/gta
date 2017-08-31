using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTA
{
    public class Animal
    {
        public Animal()
        {
            Properties = new List<AnimalProperty>();
        }

        public long AnimalId { get; set; }
        public string Name { get; set; }
        public List<AnimalProperty> Properties { get; set; }

        public void AddProperties(params AnimalProperty[] props)
        {
            Properties.AddRange(props.ToList());
        }
    }
}
