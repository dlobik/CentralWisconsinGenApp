using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GenDB.Business;
using GenDB.Models;
using PagedList;

namespace GenDB.Controllers
{
  public class ObituaryController : Controller
  {
    private ObituaryBusinessLogic _service;

    public ObituaryController()
    {
      _service = new ObituaryBusinessLogic();
    }

    /// <summary>
    /// Returns / displays all obituaries in the systme.
    /// </summary>
    /// <returns></returns>
    public ActionResult All()
    {
      return View("Search", _service.All().ToList());
    }

    // GET: Obits
    public ActionResult Search(SearchParameters parameters)
    {
      var results = _service.Search(parameters);
      // Do some additional conversion / of the data to a local UI model, etc.
      return View(results);
    }

    public ActionResult Webtext(int id)
    {
      var wt = _service.Get(id);
      return PartialView("_WTPopup", wt);
    }

    // GET: Obits/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Obit obit = _service.Get(id.GetValueOrDefault());
      if (obit == null) {
        return HttpNotFound();
      }
      return View(obit);
    }

#if EDITABLE
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
#endif

    protected override void Dispose(bool disposing)
    {
      if (disposing) {
        _service.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
