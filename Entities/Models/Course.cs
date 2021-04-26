using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Course
    {
        [Column("CourseId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Course name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        [MinLength(0, ErrorMessage = "Name cannot be empty.")]
        public string CourseName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}