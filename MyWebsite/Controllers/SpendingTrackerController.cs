using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using MyWebsite.Models;

using MyWebsite.Controllers;
using MyWebsite.BusinessLogic;
using static MyWebsite.DataAccess;
using static MyWebsite.BusinessLogic.SpenderLogic;

namespace MyWebsite.Scripts
{
    public class SpendingTrackerController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Home()
        {
            // Redirects
            if (!User.Identity.IsAuthenticated)
            {
                LoginRedirectModel model = new LoginRedirectModel(true);
                return RedirectToAction("Projects", "Home", model);
            }
            string id = GetIdUsingName(User.Identity.Name);
            if (!HasSpenderRegistered(id))
            {
                return RedirectToAction("Index", "SpendingTracker");
            }
                

            SpenderStatModel statModel;


            if (HasSpenderRegistered(id))
            {
                statModel = new SpenderStatModel(id);
            }
            else
            {
                statModel = null;
            }

            return View(statModel);
        }
        
        // GET: Apps
        [HttpGet]
        public ActionResult Index()
        {
            // Redirect to login if not signed in
            if (!User.Identity.IsAuthenticated)
            {
                LoginRedirectModel model = new LoginRedirectModel(true);
                return RedirectToAction("Projects", "Home", model);
            }
            if (HasSpenderRegistered(GetIdUsingName(User.Identity.Name))){
                return RedirectToAction("Home", "SpendingTracker");
            }

            ViewBag.Name = User.Identity.Name;
            
            return View();
        }

        // Return user creation form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SpenderModels inModel)
        {
            if (ModelState.IsValid)
            {
                string name = User.Identity.Name;
                string id = DataAccess.GetIdUsingName(name);

                SpenderModels model = new SpenderModels(id, inModel.Nickname, name);
                SpenderLogic.CreateSpender(model);

                ViewBag.SpenderRegistered = SpenderLogic.HasSpenderRegistered(id);
            }
            return RedirectToAction("Home","SpendingTracker");

        }

        public ActionResult AddSpending(bool success = false)
        {
            // Redirects
            if (!User.Identity.IsAuthenticated)
            {
                LoginRedirectModel model = new LoginRedirectModel(true);
                return RedirectToAction("Projects", "Home", model);
            }
            string id = GetIdUsingName(User.Identity.Name);
            if (!HasSpenderRegistered(id))
            {
                return RedirectToAction("Index", "SpendingTracker");
            }

            if (!SpenderHasACategory(id))
            {
                return RedirectToAction("AddSpendingCategory", "SpendingTracker",
                    new {hasCategories = false});
            }

            ViewBag.SpendingCategories = GetCategories(GetIdUsingName(User.Identity.Name));

            ViewBag.Success = success;
            return View();
        }

        // Add spending
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSpending(UserSpendingModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = GetIdUsingName(User.Identity.Name);
                AddSpendingToDb(model);
                
            }

            // Redirect to normal spending method with success flag
            return AddSpending(ModelState.IsValid);
        }

        [HttpGet]
        public ActionResult AddSpendingCategory(bool success = false)
        {
            // Redirects
            if (!User.Identity.IsAuthenticated)
            {
                LoginRedirectModel model = new LoginRedirectModel(true);
                return RedirectToAction("Projects", "Home", model);
            }
            string id = GetIdUsingName(User.Identity.Name);
            if (!HasSpenderRegistered(id))
            {
                return RedirectToAction("Index", "SpendingTracker");
            }

            ViewBag.Unique = true;
            ViewBag.Success = success;
            
            // Attempting to see if a url parameter was passed
            ViewBag.hasCategories = true;
            StringValues requestVar;
            // If the url parameter exists
            if (Request.Query.TryGetValue("hasCategories", out requestVar))
            {
                ViewBag.hasCategories = bool.Parse(requestVar.ToString());
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSpendingCategory(SpendingCategoryModel model)
        {
            // Is the category a new category
            bool unique = true;
            
            if (ModelState.IsValid)
            {
                List<string> categories = GetCategories(GetIdUsingName(User.Identity.Name));

                
                foreach (string category in categories)
                {
                    if (category == model.Category)
                    {
                        unique = false;
                    }
                }

                if (unique)
                {
                    model.Id = GetIdUsingName(User.Identity.Name);
                    AddCategory(model);
                }
                
                ViewBag.Unique = unique;
                ViewBag.Success = unique;

                ViewBag.hasCategories = true;


            }
            else
            {
                // Don't raise any flags and let normal error reporting take over
                ViewBag.Unique = true;
                ViewBag.Success = false;
            }
            
            
            

            return View();
        }
    }
}