using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.DTO
{
    public class UserUpdateRequestDTO : UserRequestDTO
    {
        [Required]
        public int Id { get; set; }
     
    }
}
