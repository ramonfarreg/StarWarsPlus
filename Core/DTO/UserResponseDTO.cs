using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.DTO
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public string Homeworld { get; set; }
        public string Gender { get; set; }
        public string Specie { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
