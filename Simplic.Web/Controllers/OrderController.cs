using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Simplic.Core;
using Simplic.Core.Entities;

namespace Simplic.Web.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            var orders = OrderRepository.GetAll();
            return View(orders);
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderData order = OrderRepository.Get(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            ViewBag.PersonID = new SelectList(PersonRepository.GetAll(), "Id", "FirstName");
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Description,PersonID")] OrderData order)
        {
            if (ModelState.IsValid)
            {
                OrderRepository.Persist(order);
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(PersonRepository.GetAll(), "Id", "FirstName", order.PersonID);
            return View(order);
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderData order = OrderRepository.Get(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID = new SelectList(PersonRepository.GetAll(), "Id", "FirstName", order.PersonID);
            return View(order);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Description,PersonID")] OrderData order)
        {
            if (ModelState.IsValid)
            {
                OrderRepository.Persist(order);
                return RedirectToAction("Index");
            }
            ViewBag.PersonID = new SelectList(PersonRepository.GetAll(), "Id", "FirstName", order.PersonID);
            return View(order);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderData order = OrderRepository.Get(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
