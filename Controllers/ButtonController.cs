using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    public class ButtonController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }
        public IActionResult StudentTabs()
        {
            return View();
        }
    }
}
