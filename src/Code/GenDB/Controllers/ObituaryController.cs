using System;
using System.Collections;
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
using PagedList;

namespace GenDB.Controllers
{
  public class ObituaryController : Controller
  {
    private GenContext db = new GenContext();

    ///// <summary>
    ///// Returns / displays all obituaries in the systme.
    ///// </summary>
    ///// <returns></returns>
    public ActionResult All()
    {
      return View(db.Obit.ToList());
    }

    // GET: Obits
    public ActionResult Search(SearchParameters parameters)
    {
            return View(db.Obit.ToList());

            //return (View((IEnumerable<Obit>) null));
            //Obit[] results = null;
            //if (parameters == null) results = db.Obit.ToArray();
            //else {
            //  var query = db.Obit.AsQueryable();

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

    // GET: Obits/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Obit obit = db.Obit.Find(id);
      if (obit == null) {
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
      if (ModelState.IsValid) {
        db.Obit.Add(obit);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(obit);
    }

    // GET: Obits/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Obit obit = db.Obit.Find(id);
      if (obit == null) {
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
      if (ModelState.IsValid) {
        db.Entry(obit).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(obit);
    }

    // GET: Obits/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Obit obit = db.Obit.Find(id);
      if (obit == null) {
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
      if (disposing) {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
