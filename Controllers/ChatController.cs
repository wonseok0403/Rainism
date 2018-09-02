using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rainism.Controllers
{
    public class ChatController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChatRoom(){
            String tokenString = HttpContext.Session.GetString("Login");
            if (tokenString == null)
            {
                ModelState.AddModelError("Error", "Check Login");
                ViewBag.Message = "Please login first!";
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                return View();
            }
        }
    }
}
