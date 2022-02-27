using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace e_Library.Models
{
    public partial class ReservedBook
    {
        [Key]
        public int ReservedBookId { get; set; }
        public DateTime ReservedData { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}