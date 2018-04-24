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
  public class CensusController : Controller
  {
    private ICensusRepository _repository;
        private GenContext db = new GenContext();

    public CensusController():this(RepositoryFactory.CreateCensusRepository())
    {
    }

    public CensusController(ICensusRepository repository)
    {
      _repository = repository;
    }

    public ActionResult All()
    {
            return View(db.Census.ToList());
    }
        // GET: Censuses
        public ActionResult Search(SearchParameters parameters)
    {

            return View(db.Census.ToList());
            //var results = _repository.Search(parameters);
            ////if (results.Any()) {
            //  return View(results);
            ////}
            ////return RedirectToAction();
        }

    // GET: Censuses/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Census census = _repository.Get(id.Value);
      if (census == null) {
        return HttpNotFound();
      }
      return View(census);
    }

    // GET: Censuses/Create
    public ActionResult Create()
    {
      return View();
    }

#if EDITABLE
    // POST: Censuses/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "ID,FirstName,MiddleName,LastName,Age,DateOfRecord,Page,Town")] Census census)
    {
      if (ModelState.IsValid) {
        db.Census.Add(census);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(census);
    }

    // GET: Censuses/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Census census = db.Census.Find(id);
      if (census == null) {
        return HttpNotFound();
      }
      return View(census);
    }

    // POST: Censuses/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "ID,FirstName,MiddleName,LastName,Age,DateOfRecord,Page,Town")] Census census)
    {
      if (ModelState.IsValid) {
        db.Entry(census).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(census);
    }

    // GET: Censuses/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Census census = db.Census.Find(id);
      if (census == null) {
        return HttpNotFound();
      }
      return View(census);
    }

    // POST: Censuses/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Census census = db.Census.Find(id);
      db.Census.Remove(census);
      db.SaveChanges();
      return RedirectToAction("Index");
    }
#endif

    protected override void Dispose(bool disposing)
    {
      if (disposing) {
        _repository.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
