using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lesson10_entry_framework_DTH.Models;

namespace lesson10_entry_framework_DTH.Controllers
{
    public class DTHMonhocsController : Controller
    {
        private DTHQLSVEntities2 db = new DTHQLSVEntities2();

        // GET: DTHMonhocs
        public ActionResult DTHIndex()
        {
            return View(db.Monhocs.ToList());
        }

        // GET: DTHMonhocs/Details/5
        public ActionResult DTHDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monhoc monhoc = db.Monhocs.Find(id);
            if (monhoc == null)
            {
                return HttpNotFound();
            }
            return View(monhoc);
        }

        // GET: DTHMonhocs/Create
        public ActionResult DTHCreate()
        {
            return View();
        }

        // POST: DTHMonhocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DTHCreate([Bind(Include = "MaMH,TenMH,Sotiet")] Monhoc monhoc)
        {
            if (ModelState.IsValid)
            {
                db.Monhocs.Add(monhoc);
                db.SaveChanges();
                return RedirectToAction("DTHIndex");
            }

            return View(monhoc);
        }

        // GET: DTHMonhocs/Edit/5
        public ActionResult DTHEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monhoc monhoc = db.Monhocs.Find(id);
            if (monhoc == null)
            {
                return HttpNotFound();
            }
            return View(monhoc);
        }

        // POST: DTHMonhocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DTHEdit([Bind(Include = "MaMH,TenMH,Sotiet")] Monhoc monhoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monhoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DTHIndex");
            }
            return View(monhoc);
        }

        // GET: DTHMonhocs/Delete/5
        public ActionResult DTHDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monhoc monhoc = db.Monhocs.Find(id);
            if (monhoc == null)
            {
                return HttpNotFound();
            }
            return View(monhoc);
        }

        // POST: DTHMonhocs/Delete/5
        [HttpPost, ActionName("DTHDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Monhoc monhoc = db.Monhocs.Find(id);
            db.Monhocs.Remove(monhoc);
            db.SaveChanges();
            return RedirectToAction("DTHIndex");
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
