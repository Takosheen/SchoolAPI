using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class CourseUpdateDto
    {
        [Required(ErrorMessage = "Course name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the Name is 60 characters.")]
        public string CourseName { get; set; }
    }
}
