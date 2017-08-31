using System;
using System.Collections.Generic;
using System.Text;

namespace GTA
{
    public class AnimalProperty
    {
        public AnimalProperty(string name, string question, string answer)
        {
            Name = name;
            Question = question;
            Answer = answer;
        }

        public long AnimalPropertyId { get; set; }

        public string Name { get; set; }

        public string Answer { get; set; }

        public string Question { get; set; }
    }
}
