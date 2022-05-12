using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    public class LibrarianController : Controller
    {
        private ApplicationDbContext _context = null;
        public LibrarianController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var std = _context.AddBook.Select(s => new AddBooks
             {

                 BookNo=s.BookNo,
                 BookName=s.BookName,
                 BookCategory=s.BookCategory,
                 Author=s.Author,
                 Publication=s.Publication,
                 Price=s.Price,
                 Quantity=s.Quantity,
                 AvailableQuantity=s.AvailableQuantity,
                 
             }).ToList();
             return View(std);
           
        }
        [HttpGet]
       public  ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AddBooks user)
        {
            _context.AddBook.Add(user);
            //_context.SaveChanges();
            _context.SaveChanges();
            TempData["AlertMessage"] = "Record Added Successfully";
            return View();
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
                TempData["AlertMessage"] = "Changes saved successfully";
            }



            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            var data = _context.AddBook.Where(x => x.BookNo == id).FirstOrDefault();
            _context.AddBook.Remove(data);
            _context.SaveChanges();
            //ViewBag.Messsage = "Record Delete Successfully";
            TempData["AlertMessage"] = "Record deleted successfully";
            return RedirectToAction("index");
        }
        public IActionResult Details(int id)
        {
            Models.AddBooks emp = _context.AddBook.Where(x => x.BookNo == id).Single();
            return View(emp);

        }
    }
}
