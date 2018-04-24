using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GenDB.DAL;
using GenDB.Models;
using GenDB.ViewModels;

namespace GenDB.Controllers
{
    public class NaturalizationController : Controller
    {
        private GenContext db = new GenContext();


        public ActionResult All()
        {
            return View(db.Naturalization.ToList());
        }

        // GET: Naturalizations
        public ActionResult Search(SearchParameters parameters)
        {


            return View(db.Naturalization.ToList());



            //return (View((IEnumerable<Naturalization>)null));
            //Naturalization[] results = null;
            //if (parameters == null) results = db.Naturalization.ToArray();
            //else {
            //  var query = db.Naturalization.AsQueryable();

            //  // WATCH OUT FOR SQL INJECTION
            //  if (!String.IsNullOrWhiteSpace(parameters.FirstName)) {
            //    query = query.Where(p => String.Equals(p.FirstName, parameters.FirstName, StringComparison.OrdinalIgnoreCase));
            //  }
            //  if (!String.IsNullOrWhiteSpace(parameters.LastName)) {
            //    query = query.Where(p => String.Equals(p.LastName, parameters.LastName, StringComparison.OrdinalIgnoreCase));
            //  }
            //  results = query.ToArray();
            //}
            //return View(results);
        }

        // GET: Naturalizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Naturalization naturalization = db.Naturalization.Find(id);
            if (naturalization == null)
            {
                return HttpNotFound();
            }
            return View(naturalization);
        }

        // GET: Naturalizations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Naturalizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,MiddleName,LastName,DOB,Age,DateOfRecord,Location,CountryOfOrigin,Series,Box,Folder,VolNumber,PageCertNumber,DateOfEntry,PortOfEntry")] Naturalization naturalization)
        {
            if (ModelState.IsValid)
            {
                db.Naturalization.Add(naturalization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(naturalization);
        }

        // GET: Naturalizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Naturalization naturalization = db.Naturalization.Find(id);
            if (naturalization == null)
            {
                return HttpNotFound();
            }
            return View(naturalization);
        }

        // POST: Naturalizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,MiddleName,LastName,DOB,Age,DateOfRecord,Location,CountryOfOrigin,Series,Box,Folder,VolNumber,PageCertNumber,DateOfEntry,PortOfEntry")] Naturalization naturalization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(naturalization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(naturalization);
        }

        // GET: Naturalizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Naturalization naturalization = db.Naturalization.Find(id);
            if (naturalization == null)
            {
                return HttpNotFound();
            }
            return View(naturalization);
        }

        // POST: Naturalizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Naturalization naturalization = db.Naturalization.Find(id);
            db.Naturalization.Remove(naturalization);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
