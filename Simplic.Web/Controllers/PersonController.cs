using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Simplic.Core;

namespace Simplic.Web.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            var model = PersonRepository.GetAll();
            return View(model);
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonData personData = PersonRepository.Get(id.Value);
            if (personData == null)
            {
                return HttpNotFound();
            }
            return View(personData);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Age,Sex,Address")] PersonData personData)
        {
            if (ModelState.IsValid)
            {
                PersonRepository.Persist(personData);
                return RedirectToAction("Index");
            }

            return View(personData);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonData personData = PersonRepository.Get(id.Value);
            if (personData == null)
            {
                return HttpNotFound();
            }
            return View(personData);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Age,Sex,Address")] PersonData personData)
        {
            if (ModelState.IsValid)
            {
                PersonRepository.Persist(personData);
                return RedirectToAction("Index");
            }
            return View(personData);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonData personData = PersonRepository.Get(id.Value);
            if (personData == null)
            {
                return HttpNotFound();
            }
            return View(personData);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
