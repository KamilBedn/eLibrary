using e_Library.DAL;
using e_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_Library.Controllers
{
    public class BookController : Controller
    {
        private readonly eLibraryDbContext _dbContext = new eLibraryDbContext();
        private static IList<Book> books = new List<Book>()
        {
            new Book() { BookId = 0, Title = "Pan Tadeusz", Author = "Adam Mickiewicz", PublicationData = DateTime.Parse("25.03.2014"), Description = "Gatunek: Poezja epicka", IsReserved = false },
            new Book() { BookId = 1, Title = "Ogniem i mieczem", Author = "Henryk Sienkiewicz", PublicationData = DateTime.Parse("01.07.2016"), Description = "Gatunek: Powieść historyczna", IsReserved = false },
            new Book() { BookId = 2, Title = "W pustyni i w puszczy", Author = "Henryk Sienkiewicz", PublicationData = DateTime.Parse("14.01.2008"), Description = "Gatunek: Powieść przygodowa", IsReserved = true },
            new Book() { BookId = 3, Title = "Kamizelka", Author = "Bolesław Prus", PublicationData = DateTime.Parse("30.11.2011"), Description = "Gatunek: Fikcja", IsReserved = false },
        };

        public ActionResult Index()
        {
            foreach(var book in books)
                _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            return View(books);
        }

        public ActionResult Details(int id)
        {
            return View(books.FirstOrDefault(x => x.BookId == id));
        }


        public ActionResult Create()
        {
            return View(new Book());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            book.BookId = books.Count + 1;
            books.Add(book);
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            return View(books.FirstOrDefault(x => x.BookId == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book bookEdit)
        {
            Book book = books.FirstOrDefault(x => x.BookId == id);
            book.Title = bookEdit.Title;
            book.Author = bookEdit.Author;
            book.PublicationData = bookEdit.PublicationData;
            book.Description = bookEdit.Description;

            return RedirectToAction("Index");
        }

        public ActionResult Reservation(int id)
        {
            return View(books.FirstOrDefault(x => x.BookId == id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reservation(int id, Book reservedBook)
        {
            Book book = books.FirstOrDefault(x => x.BookId == id);
            book.IsReserved = true;
            for (int i = 0; i < books.Count; i++)
            {
                new ReservedBook() { ReservedBookId = i, ReservedData = DateTime.Now, BookId = book.BookId };
            }

            return RedirectToAction("Index", "ReservedBook");
        }

        public ActionResult CancelReservation(int id)
        {
            return View(books.FirstOrDefault(x => x.BookId == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CancelReservation(int id, ReservedBook cancelReservedBook)
        {
            Book book = books.FirstOrDefault(x => x.BookId == id);
            book.IsReserved = false;
            

            return RedirectToAction("Index");
        }
    }
}
