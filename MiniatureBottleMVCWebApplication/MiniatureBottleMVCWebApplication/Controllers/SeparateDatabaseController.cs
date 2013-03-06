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
            Bottle Bottle = db.Bottles.Find(id);
            if (Bottle == null)
            {
                return HttpNotFound();
            }
            return View(Bottle);
        }

        //
        // GET: /SeparateDatabase/Create

        public ActionResult Create()
        {            
            return View();
        }

        //
        // POST: /SeparateDatabase/Create

        [HttpPost]
        public ActionResult Create(Bottle Bottle)
        {
            if (ModelState.IsValid)
            {                                
                db.Bottles.Add(Bottle);
                db.SaveChanges();                                
                return RedirectToAction("Index");
            }
            return View(Bottle);
        }

        //
        // GET: /SeparateDatabase/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Bottle Bottle = db.Bottles.Find(id);
            if (Bottle == null)
            {
                return HttpNotFound();
            }
            ViewBag.BottleImageId = new SelectList(db.BottleImages, "BottleImageId", "BottleImageId", Bottle.BottleImageId);
            ViewBag.BottleDetailId = new SelectList(db.BottleDetails, "Id", "Shell", Bottle.BottleDetailId);
            ViewBag.BottleDrinkDetailId = new SelectList(db.BottleDrinkDetails, "Id", "AlcoholType", Bottle.BottleDrinkDetailId);
            ViewBag.BottleOriginId = new SelectList(db.BottleOrigins, "Id", "Manufacturer", Bottle.BottleOriginId);
            return View(Bottle);
        }

        //
        // POST: /SeparateDatabase/Edit/5

        [HttpPost]
        public ActionResult Edit(Bottle Bottle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Bottle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BottleImageId = new SelectList(db.BottleImages, "BottleImageId", "BottleImageId", Bottle.BottleImageId);
            ViewBag.BottleDetailId = new SelectList(db.BottleDetails, "Id", "Shell", Bottle.BottleDetailId);
            ViewBag.BottleDrinkDetailId = new SelectList(db.BottleDrinkDetails, "Id", "AlcoholType", Bottle.BottleDrinkDetailId);
            ViewBag.BottleOriginId = new SelectList(db.BottleOrigins, "Id", "Manufacturer", Bottle.BottleOriginId);
            return View(Bottle);
        }

        //
        // GET: /SeparateDatabase/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Bottle Bottle = db.Bottles.Find(id);
            if (Bottle == null)
            {
                return HttpNotFound();
            }
            return View(Bottle);
        }

        //
        // POST: /SeparateDatabase/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Bottle Bottle = db.Bottles.Find(id);
            db.Bottles.Remove(Bottle);
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