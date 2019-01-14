using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.Models;

namespace MyWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
        
        public ActionResult Resume()
        {
            ViewBag.Message = "My résumé";

            return View();
        }

        public ActionResult Projects(LoginRedirectModel model = null)
        {
            ViewBag.Message = "My projects";

            // Handle if there was no redirection
            if (model == null)
            {
                model = new LoginRedirectModel(false);
            }

            return View(model);
        }
    }
}