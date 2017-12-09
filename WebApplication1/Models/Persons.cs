using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    [Serializable]
    public class Persons
    {
        [Required(ErrorMessage = "The FirstName attribute is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The SurName attribute is required")]
        public string SurName { get; set; }
        [Required(ErrorMessage = "The Email attribute is required")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Phone attribute is required")]
        public int? Phone { get; set; }
        [Required(ErrorMessage = "The BirthDay attribute is required")]
        public string BirthDay { get; set; }
        [Required(ErrorMessage = "The SerialNumber attribute is required")]
        public int SerialNumber { get; set; }

    }
}
