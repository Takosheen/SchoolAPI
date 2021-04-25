using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Student
    {
        [Column("UserId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Course name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string UserName { get; set; }

        [ForeignKey(nameof(Course))]
        public Guid CourseId { get; set; }

        public Course Course { get; set; }
    }
}