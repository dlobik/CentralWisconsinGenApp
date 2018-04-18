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
using PagedList;

namespace GenDB.Controllers
{
    public class ObitsController : Controller
    {
        private GenContext db = new GenContext();

        // GET: Obits
        public ActionResult Index(string option, string search, int? pageNumber)
        {
            //if a user choose the radio button option as Obits
            if (option == "Fname")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(db.Obit.Where(x => x.FirstName == search || search == null).ToList().ToPagedList(pageNumber ?? 1, 3));
            }
            else if (option == "Lname")
            {
                return View(db.Obit.Where(x => x.LastName == search || search == null).ToList().ToPagedList(pageNumber ?? 1, 3));
            }
            else
            {
                return View(db.Obit.Where(x => x.AltName.StartsWith(search) || search == null).ToList().ToPagedList(pageNumber ?? 1,3));
            }

            //return View(db.Obit.ToList());
        }

        // GET: Obits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obit obit = db.Obit.Find(id);
            if (obit == null)
            {
                return HttpNotFound();
            }
            return View(obit);
        }

        // GET: Obits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Obits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,MiddleName,LastName,AltName,DateOfRecord,BirthDate,Age,WebText")] Obit obit)
        {
            if (ModelState.IsValid)
            {
                db.Obit.Add(obit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obit);
        }

        // GET: Obits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obit obit = db.Obit.Find(id);
            if (obit == null)
            {
                return HttpNotFound();
            }
            return View(obit);
        }

        // POST: Obits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,MiddleName,LastName,AltName,DateOfRecord,BirthDate,Age,WebText")] Obit obit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obit);
        }

        // GET: Obits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obit obit = db.Obit.Find(id);
            if (obit == null)
            {
                return HttpNotFound();
            }
            return View(obit);
        }

        // POST: Obits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Obit obit = db.Obit.Find(id);
            db.Obit.Remove(obit);
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
