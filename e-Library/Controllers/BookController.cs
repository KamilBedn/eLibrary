using e_Library.DAL;
using e_Library.Models;
using e_Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_Library.Controllers
{
    public class BookController : Controller
    {
        private readonly eLibraryDbContext _dbContext = new eLibraryDbContext();

        public ActionResult Index()
        {
            try
            {
                return View(_dbContext.Books.ToList());
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult Details(int id)
        {
            return View(_dbContext.Books.FirstOrDefault(x => x.BookId == id));
        }


        public ActionResult Create()
        {
            return View(new Book());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            return View(_dbContext.Books.FirstOrDefault(x => x.BookId == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book bookEdit)
        {
            Book book = _dbContext.Books.FirstOrDefault(x => x.BookId == id);
            book.Title = bookEdit.Title;
            book.Author = bookEdit.Author;
            book.PublicationData = bookEdit.PublicationData;
            book.Description = bookEdit.Description;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Reservation(int id)
        {
            return View(_dbContext.Books.FirstOrDefault(x => x.BookId == id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reservation(int id, User model)
        {
            Book book = _dbContext.Books.FirstOrDefault(x => x.BookId == id);
            User user = _dbContext.Users.FirstOrDefault(x => x.IsLogin == true);
            if (user.IsLogin == true)
            {
                _dbContext.ReservedBooks.Add(new ReservedBook { ReservedData = DateTime.Now, BookId = book.BookId, UserId = user.UserId });
                book.IsReserved = true;
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "ReservedBook");
            }

            return RedirectToAction("Index", "Book");
        }

        public ActionResult CancelReservation(int id)
        {
            return View(_dbContext.Books.FirstOrDefault(x => x.BookId == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CancelReservation(int id, ReservedBook reservedBook)
        {
            var canceledReservation = _dbContext.ReservedBooks.FirstOrDefault(x => x.BookId == id);
            var book = _dbContext.Books.FirstOrDefault(x => x.IsReserved == true);
            var user = _dbContext.Users.FirstOrDefault(x => x.IsLogin == true);
            if (canceledReservation.UserId == user.UserId)
            { 
                _dbContext.ReservedBooks.Remove(canceledReservation);
                book.IsReserved = false;
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Book");
            }
            return RedirectToAction("Index", "Book");
        }
    }
}
