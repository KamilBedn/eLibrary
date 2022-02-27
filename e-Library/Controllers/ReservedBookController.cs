using e_Library.DAL;
using e_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_Library.Controllers
{
    public class ReservedBookController : Controller
    {
        private readonly eLibraryDbContext _dbContext = new eLibraryDbContext();

        public ActionResult Index()
        {
            return View(_dbContext.Reserved);   
        }
    }
}
