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
    public class DevicesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: /Devices/
        public ActionResult Index(string Manufacturer,string SerialNumber)
        {
            var MList = new List<string>();
            var devices = from m in db.Devices select m;
            /*
            var Query = from d in db.Devices
                           orderby d.DeviceManufacturer
                           select d.DeviceManufacturer;

            MList.AddRange(Query.Distinct());
            ViewBag.Manufacturer = new SelectList(MList);
            ViewBag.SerialNumber = SerialNumber;
            var devices = from m in db.Devices select m;
            if(!String.IsNullOrEmpty(SerialNumber))
            {
                devices = devices.Where(x => x.DeviceSerialNumber.Equals(SerialNumber));
            }
            if(!String.IsNullOrEmpty(Manufacturer))
            {
                devices = devices.Where(x => x.DeviceManufacturer.Equals(Manufacturer));
            }*/
            return View(devices);
        }

        public ActionResult My()
        {
            
            var devices = from m in db.Devices
                          where m.DeviceUser.Equals(HttpContext.User.Identity.Name)
                          select m;

            return View(devices);
        }

        // GET: /Devices/Details/5
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

        // GET: /Devices/Create
        public ActionResult Create()
        {
            var MList = new List<string>();
            var Query = from d in db.Dictionaries
                           orderby d.DeviceManufacturer
                           select d.DeviceManufacturer;
            MList.AddRange(Query.Distinct());
            var NList = new List<string>();
            Query = from d in db.Dictionaries
                    orderby d.DeviceName
                    select d.DeviceName;
            NList.AddRange(Query.Distinct());
            ViewBag.Manufacturers = new SelectList(MList);
            ViewBag.Names = new SelectList(NList);
            return View();
        }

        // POST: /Devices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeviceId,DeviceDictionaryId,Batch,DeviceSerialNumber")] Device device, [Bind(Include = "DeviceDictionaryId,DeviceManufacturer,DeviceName")] DeviceDictionary dictionary)
        {
            if (ModelState.IsValid)
            {
                db.Devices.Add(device);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(device);
        }

        // GET: /Devices/Edit/5
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
            ViewBag.id = HttpContext.User.Identity.Name;
            return View(device);
        }

        // POST: /Devices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DeviceId,DeviceManufacturer,DeviceName,DeviceSerialNumber,DeviceUser")] Device device)
        {
            if (ModelState.IsValid)
            {
                db.Entry(device).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(device);
        }

        // GET: /Devices/Delete/5
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

        // POST: /Devices/Delete/5
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
