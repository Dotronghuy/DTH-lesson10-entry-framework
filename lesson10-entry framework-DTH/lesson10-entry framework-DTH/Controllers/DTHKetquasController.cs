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
    public class DTHKetquasController : Controller
    {
        private DTHQLSVEntities2 db = new DTHQLSVEntities2();

        // GET: DTHKetquas
        public ActionResult DTHIndex()
        {
            var ketquas = db.Ketquas.Include(k => k.Monhoc).Include(k => k.SinhVien);
            return View(ketquas.ToList());
        }

        // GET: DTHKetquas/Details
        public ActionResult DTHDetails(int? MaSV, int? MaMH)
        {
            if (MaSV == null || MaMH == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ketqua ketqua = db.Ketquas.Find(MaSV, MaMH);
            if (ketqua == null)
            {
                return HttpNotFound();
            }
            return View(ketqua);
        }

        // GET: DTHKetquas/Create
        public ActionResult DTHCreate()
        {
            ViewBag.MaMH = new SelectList(db.Monhocs, "MaMH", "TenMH");
            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "HoSV");
            return View();
        }

        // POST: DTHKetquas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DTHCreate([Bind(Include = "MaSV,MaMH,Diem")] Ketqua ketqua)
        {
            if (ModelState.IsValid)
            {
                db.Ketquas.Add(ketqua);
                db.SaveChanges();
                return RedirectToAction("DTHIndex");
            }

            ViewBag.MaMH = new SelectList(db.Monhocs, "MaMH", "TenMH", ketqua.MaMH);
            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "HoSV", ketqua.MaSV);
            return View(ketqua);
        }

        // GET: DTHKetquas/Edit
        public ActionResult DTHEdit(int? MaSV, int? MaMH)
        {
            if (MaSV == null || MaMH == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ketqua ketqua = db.Ketquas.Find(MaSV, MaMH);
            if (ketqua == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMH = new SelectList(db.Monhocs, "MaMH", "TenMH", ketqua.MaMH);
            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "HoSV", ketqua.MaSV);
            return View(ketqua);
        }

        // POST: DTHKetquas/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DTHEdit([Bind(Include = "MaSV,MaMH,Diem")] Ketqua ketqua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ketqua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DTHIndex");
            }
            ViewBag.MaMH = new SelectList(db.Monhocs, "MaMH", "TenMH", ketqua.MaMH);
            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "HoSV", ketqua.MaSV);
            return View(ketqua);
        }

        // GET: DTHKetquas/Delete
        public ActionResult DTHDelete(int? MaSV, int? MaMH)
        {
            if (MaSV == null || MaMH == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ketqua ketqua = db.Ketquas.Find(MaSV, MaMH);
            if (ketqua == null)
            {
                return HttpNotFound();
            }
            return View(ketqua);
        }

        // POST: DTHKetquas/Delete
        [HttpPost, ActionName("DTHDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int MaSV, int MaMH)
        {
            Ketqua ketqua = db.Ketquas.Find(MaSV, MaMH);
            db.Ketquas.Remove(ketqua);
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
