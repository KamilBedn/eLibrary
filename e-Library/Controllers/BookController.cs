using e_Library.DAL;
using e_Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
                return View(_dbContext.Books.Where(x => x.IsReserved == false));
            }
            catch (InvalidOperationException ex)
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

            return RedirectToAction("Index");
        }

        public ActionResult Reservation(int id)
        {
            return View(_dbContext.Books.FirstOrDefault(x => x.BookId == id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reservation(int id, ReservedBook reservedBook)
        {
            Book book = _dbContext.Books.FirstOrDefault(x => x.BookId == id);
            book.IsReserved = true;
            if (book.IsReserved == true)
                _dbContext.Reserved.Add(reservedBook);
            return RedirectToAction("Index", "ReservedBook");
        }

        public ActionResult CancelReservation(int id)
        {
            return View(_dbContext.Books.FirstOrDefault(x => x.BookId == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CancelReservation(int id, ReservedBook cancelReservedBook)
        {
            Book book = _dbContext.Books.FirstOrDefault(x => x.BookId == id);
            book.IsReserved = false;
            if(book.IsReserved == false)
                _dbContext.Reserved.Remove(cancelReservedBook);
            return RedirectToAction("Index");
        }
    }
}
