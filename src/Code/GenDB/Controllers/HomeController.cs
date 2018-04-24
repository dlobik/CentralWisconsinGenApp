using GenDB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenDB.Models;
using GenDB.ViewModels;

namespace GenDB.Controllers
{
    public class HomeController : Controller
    {
        private GenContext db = new GenContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /* We can pass all of the search parameters here through the viewmodel SearchParameters.
         * Once we have them in this action, we can create DB queries based on them for each table.
         * After we create queries in this Search method, How do we pass into each individual View / Model??? (Obit, Nat, Census)
         */
        public ActionResult Search(SearchParameters searchParam)
        {
            var fName = searchParam.FirstName;
            var lName = searchParam.LastName;
            var altName = searchParam.AltName;
            var recordDate = searchParam.DateOfRecord;
            var county = searchParam.County;



            return View();
        }

        [HttpGet]
        public PartialViewResult TOSPopUp()
        {
            return PartialView();
        }

        /* Test JsonResult Method
        public JsonResult GetSearchingData(string SearchBy, string SearchValue)
        {
            List<Obit> Obits = new List<Obit>();
            if (SearchBy == "fname")
            {
                try
                {
                    string fname = SearchValue;
                    Obits = db.Obit.Where(x => x.FirstName == fname || SearchValue == null).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} Is not a First Name in DB", SearchValue);
                }
                return Json(Obits, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Obits = db.Obit.Where(x => x.LastName == SearchValue || SearchValue == null).ToList();
                return Json(Obits, JsonRequestBehavior.AllowGet);
            }

        }
        */
    }
}