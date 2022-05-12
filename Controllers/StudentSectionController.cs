using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    public class StudentSectionController : Controller
    {
        private ApplicationDbContext _context = null;
        public StudentSectionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ShowDetails(string BookCategory)
        {
            var s = (from x in _context.AddBook
                    where x.BookCategory == BookCategory
                    select x).ToList();
           

            return View(s);
        }
        public IActionResult Index1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ShowMyBooks(string student_id)
        {
            var s = (from x in _context.IssueBook
                     where x.Student_Id == student_id
                     select x).ToList();


            return View(s);
        }




    }
}
