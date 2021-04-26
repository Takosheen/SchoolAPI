using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class UserCreationDto
    {
        [Required(ErrorMessage = "User name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the Name is 5 characters.")]
        public string UserName { get; set; }
    }
}
