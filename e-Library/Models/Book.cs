using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_Library.Models
{
    public partial class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required(ErrorMessage = "Enter the title of the book")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Introduce the author of the book")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Enter the publication data of the book")]
        [DisplayName("Publication Data")]
        public DateTime PublicationData { get; set; }
        public string Description { get; set; }
        [DefaultValue(false)]
        public bool IsReserved { get; set; }
        [Required]
        public virtual ReservedBook ReservedBook { get; set; }
    }
}