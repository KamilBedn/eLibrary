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
        private static IList<ReservedBook> reservedBooks = new List<ReservedBook>();

        public ActionResult Index()
        {
            return View(reservedBooks);   
        }
    }
}
