using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DAL.Model
{
    public class Homeworld
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; } 
    }
}
