using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LibraryCRUD.Models;
using LibraryCRUD.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryCRUD.Controllers
{
    public class BooksController : Controller
    {
        private readonly DataContext _context;
        public BooksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(_context.Book.OrderBy(x => x.Title).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Book.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        public ActionResult Edit(int id)
        {
            Book book = _context.Book.Find(id);
            if (book == null)
            {
                return StatusCode(500);
            }

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(book).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        public ActionResult Delete(int id)
        {
            Book book = _context.Book.Find(id);
            _context.Book.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
