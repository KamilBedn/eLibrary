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
        public int BookId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}