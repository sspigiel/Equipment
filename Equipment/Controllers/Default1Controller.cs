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
    public class Default1Controller : Controller
    {
        private MyDbContext db = new MyDbContext();
        
        // GET: /Default1/
        public ActionResult Index()
        {
            var devices = db.Devices.Include(d => d.DeviceDictionary);
            return View(devices.ToList());
        }

        // GET: /Default1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = db.Devices.Find(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        // GET: /Default1/Create
        public ActionResult Create()
        {
            var Ids = db.Dictionaries
                .Select(s => new
                {
                    DeviceDictionaryId = s.DeviceDictionaryId,
                    Description = s.DeviceManufacturer+" "+s.DeviceName
                })
                .ToList();
            ViewBag.DeviceDictionaryId = new SelectList(Ids, "DeviceDictionaryId", "Description");
            return View();
        }

        // POST: /Default1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DeviceId,DeviceSerialNumber,DeviceUser,DeviceDictionaryId,Batch")] Device device)
        {
            if (ModelState.IsValid)
            {
                db.Devices.Add(device);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeviceDictionaryId = new SelectList(db.Dictionaries, "DeviceDictionaryId", "DeviceManufacturer", device.DeviceDictionaryId);
            return View(device);
        }

        // GET: /Default1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = db.Devices.Find(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeviceDictionaryId = new SelectList(db.Dictionaries, "DeviceDictionaryId", "DeviceManufacturer", device.DeviceDictionaryId);
            return View(device);
        }

        // POST: /Default1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DeviceId,DeviceSerialNumber,DeviceUser,DeviceDictionaryId,Batch")] Device device)
        {
            if (ModelState.IsValid)
            {
                db.Entry(device).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeviceDictionaryId = new SelectList(db.Dictionaries, "DeviceDictionaryId", "DeviceManufacturer", device.DeviceDictionaryId);
            return View(device);
        }

        // GET: /Default1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = db.Devices.Find(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        // POST: /Default1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Device device = db.Devices.Find(id);
            db.Devices.Remove(device);
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
