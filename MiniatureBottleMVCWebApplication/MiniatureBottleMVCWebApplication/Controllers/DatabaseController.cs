using System.Data;
using System.Linq;
using System.Web.Mvc;
using MiniatureBottleMVCWebApplication.Models;

namespace MiniatureBottleMVCWebApplication.Controllers
{
    public class DatabaseController : Controller
    {
        private MiniatureBottleContext db = new MiniatureBottleContext();

        //
        // GET: /Database/

        public ActionResult Index()
        {
            return View(db.Bottles.ToList());
        }

        //
        // GET: /Database/Details/5

        public ActionResult Details(int id = 0)
        {
            Bottle bottle = db.Bottles.Find(id);
            if (bottle == null)
            {
                return HttpNotFound();
            }
            return View(bottle);
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
        public ActionResult Create(Bottle bottle)
        {
            if (ModelState.IsValid)
            {
                db.Bottles.Add(bottle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bottle);
        }

        //
        // GET: /Database/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Bottle bottle = db.Bottles.Find(id);
            if (bottle == null)
            {
                return HttpNotFound();
            }
            return View(bottle);
        }

        //
        // POST: /Database/Edit/5

        [HttpPost]
        public ActionResult Edit(Bottle bottle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bottle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bottle);
        }

        //
        // GET: /Database/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Bottle bottle = db.Bottles.Find(id);
            if (bottle == null)
            {
                return HttpNotFound();
            }
            return View(bottle);
        }

        //
        // POST: /Database/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Bottle bottle = db.Bottles.Find(id);
            db.Bottles.Remove(bottle);
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