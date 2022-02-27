using e_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_Library.Controllers
{
    public class LogInController : Controller
    {
        private static IList<User> users = new List<User>()
        {
            new User() {UserId = 1, FirstName = "Adam", LastName = "Kowalski", Email = "kowalski@wp.pl", Password = "kamizelka", ConfirmPassword ="kamizelka"},
            new User() {UserId = 1, FirstName = "Adam", LastName = "Kowalski", Email = "kowalski@wp.pl", Password = "kamizelka", ConfirmPassword ="kamizelka"}
        };
    
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Book");
        }

        public ActionResult Create()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            user.UserId = users.Count() + 1;
            users.Add(user);
            return RedirectToAction("Index");
        }
    }
}
