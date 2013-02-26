using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniatureBottleMVCWebApplication.Models;

namespace MiniatureBottleMVCWebApplication.Controllers
{
    public class SeparateDatabaseController : Controller
    {
        private MiniatureBottleContext db = new MiniatureBottleContext();

        //
        // GET: /SeparateDatabase/

        public ActionResult Index()
        {
            var bottles = db.Bottles.Include(b => b.BottleImage).Include(b => b.BottleDetail).Include(b => b.BottleDrinkDetail).Include(b => b.BottleOrigin);
            return View(bottles.ToList());
        }

        //
        // GET: /SeparateDatabase/Details/5

        public ActionResult Details(int id = 0)
        {
            BottleAdd bottleadd = db.Bottles.Find(id);
            if (bottleadd == null)
            {
                return HttpNotFound();
            }
            return View(bottleadd);
        }

        //
        // GET: /SeparateDatabase/Create

        public ActionResult Create()
        {
            ViewBag.BottleImageId = new SelectList(db.BottleImages, "BottleImageId", "BottleImageId");
            ViewBag.BottleDetailId = new SelectList(db.BottleDetails, "Id", "Shell");
            ViewBag.BottleDrinkDetailId = new SelectList(db.BottleDrinkDetails, "Id", "AlcoholType");
            ViewBag.BottleOriginId = new SelectList(db.BottleOrigins, "Id", "Manufacturer");
            return View();
        }

        //
        // POST: /SeparateDatabase/Create

        [HttpPost]
        public ActionResult Create(BottleAdd bottleadd)
        {
            if (ModelState.IsValid)
            {
                db.Bottles.Add(bottleadd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BottleImageId = new SelectList(db.BottleImages, "BottleImageId", "BottleImageId", bottleadd.BottleImageId);
            ViewBag.BottleDetailId = new SelectList(db.BottleDetails, "Id", "Shell", bottleadd.BottleDetailId);
            ViewBag.BottleDrinkDetailId = new SelectList(db.BottleDrinkDetails, "Id", "AlcoholType", bottleadd.BottleDrinkDetailId);
            ViewBag.BottleOriginId = new SelectList(db.BottleOrigins, "Id", "Manufacturer", bottleadd.BottleOriginId);
            return View(bottleadd);
        }

        //
        // GET: /SeparateDatabase/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BottleAdd bottleadd = db.Bottles.Find(id);
            if (bottleadd == null)
            {
                return HttpNotFound();
            }
            ViewBag.BottleImageId = new SelectList(db.BottleImages, "BottleImageId", "BottleImageId", bottleadd.BottleImageId);
            ViewBag.BottleDetailId = new SelectList(db.BottleDetails, "Id", "Shell", bottleadd.BottleDetailId);
            ViewBag.BottleDrinkDetailId = new SelectList(db.BottleDrinkDetails, "Id", "AlcoholType", bottleadd.BottleDrinkDetailId);
            ViewBag.BottleOriginId = new SelectList(db.BottleOrigins, "Id", "Manufacturer", bottleadd.BottleOriginId);
            return View(bottleadd);
        }

        //
        // POST: /SeparateDatabase/Edit/5

        [HttpPost]
        public ActionResult Edit(BottleAdd bottleadd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bottleadd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BottleImageId = new SelectList(db.BottleImages, "BottleImageId", "BottleImageId", bottleadd.BottleImageId);
            ViewBag.BottleDetailId = new SelectList(db.BottleDetails, "Id", "Shell", bottleadd.BottleDetailId);
            ViewBag.BottleDrinkDetailId = new SelectList(db.BottleDrinkDetails, "Id", "AlcoholType", bottleadd.BottleDrinkDetailId);
            ViewBag.BottleOriginId = new SelectList(db.BottleOrigins, "Id", "Manufacturer", bottleadd.BottleOriginId);
            return View(bottleadd);
        }

        //
        // GET: /SeparateDatabase/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BottleAdd bottleadd = db.Bottles.Find(id);
            if (bottleadd == null)
            {
                return HttpNotFound();
            }
            return View(bottleadd);
        }

        //
        // POST: /SeparateDatabase/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            BottleAdd bottleadd = db.Bottles.Find(id);
            db.Bottles.Remove(bottleadd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}