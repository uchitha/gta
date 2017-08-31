using System;
using System.Collections.Generic;
using System.Text;

namespace GTA.Models
{
    public class AnimalProperty
    {
        public long AnimalId { get; set; }
        public long PropertyId { get; set; }

        public Animal Animal { get; set; }
        public Property Property { get; set; }
    }
}
