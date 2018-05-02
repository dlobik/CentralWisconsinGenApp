using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GenDB.Business.Repository.EntityFramework;
using GenDB.Models;
using GenDB.Business.Repository;

namespace GenDB.Controllers
{
    public class HomeController : Controller
    {
        private GenContext db = new GenContext();

        public ActionResult Index()
        {
            ViewBag.Counties = new SelectList(db.County, "ID", "Name");

            return View();
        }

        public ActionResult Search(SearchParameters searchParam)
        {
          return(View(searchParam));

        }

        [HttpGet]
        public PartialViewResult _TOSPopUp()
        {
            return PartialView();
        }
    }
}