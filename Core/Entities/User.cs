using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public Homeworld Homeworld { get; set; }
        public char Gender { get; set; }
        public Specie Specie { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }

    }
}
