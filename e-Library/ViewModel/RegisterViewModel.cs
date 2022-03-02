using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_Library.ViewModel
{
    public class RegisterViewModel
    {
        [Display(Name = " First Name")]
        public string FirstName { get; set; }
        [Display(Name = " Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [Display( Name = "E-mail")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = " Password ")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password ")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password are different")]
        public string ConfirmPassword { get; set; }
    }
}