using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentViewTemplateDemo.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "City can't be longer than 30 characters.")]
        public string City { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "State can't be longer than 30 characters.")]
        public string State { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Country can't be longer than 30 characters.")]

        public string Country { get; set; }
    }
}