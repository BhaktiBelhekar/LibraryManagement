using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    public class ReturnBookController : Controller
    {
        private ApplicationDbContext _context = null;
        public ReturnBookController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var std = _context.ReturnBook.Select(s => new Return_Books
            {
                id = s.id,
                Student_Id = s.Student_Id,
                BookNo = s.BookNo,
                BookName = s.BookName,
                Return_Date = s.Return_Date,
                Fine = s.Fine

            }).ToList();
            return View(std);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Return_Books user)
        {
            _context.ReturnBook.Add(user);
            //_context.SaveChanges();
            _context.SaveChanges();
            TempData["AlertMessage"] = "Book Returned Successfully";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.ReturnBook.Where(x => x.id== id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Return_Books Model)
        {
            var data = _context.ReturnBook.Where(x => x.id== Model.id).FirstOrDefault();
            if (data != null)
            {
                data.id = Model.id;
                data.Student_Id = Model.Student_Id;
                data.BookNo = Model.BookNo;
                data.BookName = Model.BookName;
                data.Return_Date = Model.Return_Date;
                data.Fine = Model.Fine;
                TempData["AlertMessage"] = "Changes Saved Successfully";


                //_context.SaveChanges();
                _context.SaveChanges();
            }



            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            var data = _context.ReturnBook.Where(x => x.id == id).FirstOrDefault();
            _context.ReturnBook.Remove(data);
            _context.SaveChanges();
            // ViewBag.Messsage = "Record Delete Successfully";
            TempData["AlertMessage"] = "Record Deleted Successfully";
            return RedirectToAction("index");
        }

        public IActionResult Details(int id)
        {
            Models.Return_Books emp = _context.ReturnBook.Where(x => x.id == id).Single();
            return View(emp);

        }
        public IActionResult IncreaseCount(int id)
        {

            var bookRet = _context.ReturnBook.Where(x => x.id == id).FirstOrDefault();
            try
            {
                var books = (from b in _context.AddBook where b.BookNo.Equals(bookRet.BookNo) select b).First();

                if (books.AvailableQuantity > 0)
                {
                    books.AvailableQuantity = books.AvailableQuantity + 1;
                    var data1 = (from b in _context.IssueBook where b.BookNo.Equals(bookRet.BookNo) select b).First();
                    _context.IssueBook.Remove(data1);
                    _context.SaveChanges();
                    TempData["AlertMessage"] = "Book Qunatity Updated Successfully";
                }
                else
                {
                    TempData["msg"] = "Invalid Operation";
                }
            }
            catch (Exception e)
            {
                TempData["msg"] = "Invalid Operation";
            }

            return RedirectToAction("index");
        }

        public IActionResult CalFine(int id)
        {
            try
            {
                var bookRet = _context.ReturnBook.Where(x => x.id == id).FirstOrDefault();
                var books = (from b in _context.IssueBook where b.BookNo.Equals(bookRet.BookNo) select b).First();
                var dueDate = books.DueDate;
                var returnDate = bookRet.Return_Date;
                double totalfine = (returnDate - dueDate).TotalDays * 10;
                bookRet.Fine = Convert.ToInt32(totalfine);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                TempData["msg"] = "Invalid Operation";
            }
            return RedirectToAction("index");
        }


    }
}
