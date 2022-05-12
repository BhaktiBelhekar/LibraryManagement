
using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext _context = null;
        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.AddBook.ToListAsync());
        }
        public async Task<IActionResult> Filter(string name)
        {
            var allBooks = from b in _context.AddBook select b;

            if (!string.IsNullOrEmpty(name))
            {
                var allBook = allBooks.Where(n => n.BookName.ToLower().Contains(name.ToLower()));

                // var filteredResultNew = allBooks.Where(n => string.Equals(n.BookName, searchString, StringComparison.CurrentCultureIgnoreCase));

                return View(await allBook.ToListAsync());
            }

            return View(await allBooks.ToListAsync());
        }

       [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.AddBook.Where(x => x.BookNo == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(AddBooks Model)
        {
            var data = _context.AddBook.Where(x => x.BookNo == Model.BookNo).FirstOrDefault();
            if (data != null)
            {
                data.BookNo = Model.BookNo;
                data.BookName = Model.BookName;
                data.BookCategory = Model.BookCategory;
                data.Author = Model.Author;
                data.Publication = Model.Publication;
                data.Price = Model.Price;
                data.Quantity = Model.Quantity;
                data.AvailableQuantity = Model.AvailableQuantity;

                //_context.SaveChanges();
                _context.SaveChanges();
                TempData["AlertMessage"] = "Changes Saved Successfully";
            }



            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            var data = _context.AddBook.Where(x => x.BookNo == id).FirstOrDefault();
            _context.AddBook.Remove(data);
            _context.SaveChanges();
           // ViewBag.Messsage = "Record Delete Successfully";
            TempData["AlertMessage"] = "Record Delete Successfully";
            return RedirectToAction("index");
        }
        public IActionResult Details(int id)
        {
            Models.AddBooks emp = _context.AddBook.Where(x => x.BookNo == id).Single();
            return View(emp);

        }
    }
}
