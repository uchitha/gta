using System;
using System.Collections.Generic;
using System.Text;

namespace GTA.Models
{
    public class AnimalNode
    {
        public Property Question { get; set; }

        public Property NextQuestionYes { get; set; } //Left node

        public Property NexyQuestionNo { get; set; } //Right Node

        public Animal GuessedAnimal { get; set; } //Leaf
    }
}
