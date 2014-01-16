using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Equipment.Models;

namespace Equipment.Controllers
{
    public class DeviceDictionaryController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: /DeviceDictionary/
        public ActionResult Index()
        {
            return View(db.Dictionaries.ToList());
        }

        // GET: /DeviceDictionary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceDictionary devicedictionary = db.Dictionaries.Find(id);
            if (devicedictionary == null)
            {
                return HttpNotFound();
            }
            return View(devicedictionary);
        }

        // GET: /DeviceDictionary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /DeviceDictionary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DeviceDictionaryId,DeviceManufacturer,DeviceName")] DeviceDictionary devicedictionary)
        {
            if (ModelState.IsValid)
            {
                db.Dictionaries.Add(devicedictionary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(devicedictionary);
        }

        // GET: /DeviceDictionary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceDictionary devicedictionary = db.Dictionaries.Find(id);
            if (devicedictionary == null)
            {
                return HttpNotFound();
            }
            return View(devicedictionary);
        }

        // POST: /DeviceDictionary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DeviceDictionaryId,DeviceManufacturer,DeviceName")] DeviceDictionary devicedictionary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(devicedictionary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(devicedictionary);
        }

        // GET: /DeviceDictionary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceDictionary devicedictionary = db.Dictionaries.Find(id);
            if (devicedictionary == null)
            {
                return HttpNotFound();
            }
            return View(devicedictionary);
        }

        // POST: /DeviceDictionary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeviceDictionary devicedictionary = db.Dictionaries.Find(id);
            db.Dictionaries.Remove(devicedictionary);
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
