using e_Library.DAL;
using e_Library.Models;
using e_Library.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace e_Library.Controllers
{
    public class AccountController : Controller
    {
        private readonly eLibraryDbContext _dbContext = new eLibraryDbContext();

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            var result = _dbContext.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            result.IsLogin = true;
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Book");
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            var user = new User { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email, Password = model.Password, ConfirmPassword = model.ConfirmPassword };
            _dbContext.Users.Add(user);
            user.IsLogin = true;
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Book");
        }

        public ActionResult LogOut()
        {
            var result = _dbContext.Users.FirstOrDefault(x => x.IsLogin == true);
            if (result.IsLogin == true)
            {
                result.IsLogin = false;
                _dbContext.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            return RedirectToAction("Login", "Account");
        }
    }
}