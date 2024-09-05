using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;

namespace StudentViewTemplateDemo.Models
{
    public class Student
    {
        public int Id { get; set; }

        [StringLength(30, ErrorMessage = "Name can't be longer than 30 characters.")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(6, 30)]
        public int Age { get; set; }
        public Address Address { get; set; }
    }
}