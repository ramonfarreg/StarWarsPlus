using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.DTO
{
    public class UserRequestDTO
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required]
        public int Height { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Homeworld { get; set; }

        [RegularExpression("male|female", ErrorMessage = "The Gender value must be 'male' or 'female'")]
        [Required(AllowEmptyStrings = false)]
        public string Gender { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Specie { get; set; }
    }
}
