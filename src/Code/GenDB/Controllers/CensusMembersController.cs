using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GenDB.Business.Repository;
using GenDB.Business.Repository.EntityFramework;
using GenDB.Models;

namespace GenDB.Controllers
{
    public class CensusMemberController : Controller
    {
        private ICensusMemberRepository _repository;

        public CensusMemberController() : this(RepositoryFactory.CreateCensusMemberRepository())
        {
        }

        public CensusMemberController(ICensusMemberRepository repository)
        {
            _repository = repository;
        }

        public ActionResult All()
        {
            return View("Search", _repository.All());
        }

        // GET: Censuses
        public ActionResult Search(SearchParameters parameters)
        {
            return (View(_repository.Search(parameters)));
        }

        // GET: Censuses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CensusMember census = _repository.Get(id.Value);
            if (census == null)
            {
                return HttpNotFound();
            }
            return View(census);
        }

#if EDITABLE
    // GET: Censuses/Create
    public ActionResult Create()
    {
      return View();
    }

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
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
