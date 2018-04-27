using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GenDB.Business.Repository.EntityFramework;
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


        //List<Obit> om = new List<Obit>();
        //List<Naturalization> nm = new List<Naturalization>();
        //List<Census> cm = new List<Census>();
        //using (GenContext db = new GenContext())
        //{
        //    using (var x = db.Database.BeginTransaction())
        //    {
        //        List<Obituary> o = db.Obit.Where(cen => cen.FirstName.ToLower().Contains(searchParam.FirstName.ToLower()) || cen.LastName.ToLower().Contains(searchParam.LastName.ToLower()))
        //            .ToList();
        //    }
        //}




        /* We can pass all of the search parameters here through the viewmodel SearchParameters.
         * Once we have them in this action, we can create DB queries based on them for each table.
         * After we create queries in this Search method, How do we pass into each individual View / Model??? (Obit, Nat, Census)
         */
        public ActionResult Search(SearchParameters searchParam)
        {
          return(View(searchParam));

          //var business = new ObituaryBuisnessLogic();
          //var model = business.Search(searchParam);
          //return View(model.ToList());
        }

        [HttpGet]
        public PartialViewResult _TOSPopUp()
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