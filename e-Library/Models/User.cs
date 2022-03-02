using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_Library.Models
{
    public partial class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Enter Email")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password are diffiernt")]
        public string ConfirmPassword { get; set; }
        public bool IsLogin { get; set; }

        public virtual ICollection<ReservedBook> ReservedBooks { get; set; }
    }
}