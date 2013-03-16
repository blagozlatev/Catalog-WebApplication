using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniatureBottleMVCWebApplication.Models;
using MiniatureBottleMVCWebApplication;
using System.IO;
using System.Drawing;

namespace MiniatureBottleMVCWebApplication.Controllers
{
    public class DatabaseController : Controller
    {
        private MiniatureBottleContext db = new MiniatureBottleContext();

        //
        // GET: /Database/

        public ActionResult Index()
        {            
            List<Bottle> bottles = (from bottle
                          in db.Bottles
                          select bottle).ToList();
            return View(bottles);
        }

        //
        // GET: /Database/Details/5

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
        // GET: /Database/Create

        public ActionResult Create()
        {            
            return View();
        }

        //
        // POST: /Database/Create

        [HttpPost]
        public ActionResult Create(Bottle Bottle, HttpPostedFileBase BtlImg)
        {
            if (ModelState.IsValid)
            {
                if (BtlImg != null && BtlImg.ContentLength > 0)
                {                    
                    int length = BtlImg.ContentLength;
                    byte[] tempArray = new byte[length];
                    BtlImg.InputStream.Read(tempArray, 0, length);
                    Bitmap bmp = ImageFunctions.resizeImage
                        (new Bitmap(BtlImg.InputStream),
                        new Size() { Height = 800, Width = 800});
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        tempArray = ms.ToArray();
                    }
                    Bottle.BottleImage.BottleImg = tempArray;                
                }
                db.Bottles.Add(Bottle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Bottle);
        }

        //
        // GET: /Database/Edit/5

        public ActionResult Edit(int id = 0)
        {            
            Bottle Bottle = db.Bottles.Find(id);
            if (Bottle == null)
            {
                return HttpNotFound();
            }
            return View(Bottle);
        }

        //
        // GET: /Database/Delete/5

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
        // POST: /Database/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Bottle Bottle = db.Bottles.Find(id);
            db.Bottles.Remove(Bottle);

            BottleDetail BDRem = db.BottleDetails.Find(Bottle.BottleDetailId);
            if (BDRem != null)
            {
                db.BottleDetails.Remove(BDRem);
            }

            BottleDrinkDetail BDDRem = db.BottleDrinkDetails.Find(Bottle.BottleDrinkDetailId);

            if (BDDRem != null)
            {
                db.BottleDrinkDetails.Remove(BDDRem);
            }

            BottleImage BIRem = db.BottleImages.Find(Bottle.BottleImageId);
            if (BIRem != null)
            {
                db.BottleImages.Remove(BIRem);
            }
            
            BottleOrigin BORem = db.BottleOrigins.Find(Bottle.BottleOriginId);
            if (BORem != null)
            {
                db.BottleOrigins.Remove(BORem);
            }

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