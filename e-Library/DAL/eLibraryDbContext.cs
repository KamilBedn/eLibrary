using e_Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace e_Library.DAL
{
    public partial class eLibraryDbContext : DbContext
    {
        public eLibraryDbContext() : base("eLibraryDbContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ReservedBook> Reserved { get; set; }
    }
}