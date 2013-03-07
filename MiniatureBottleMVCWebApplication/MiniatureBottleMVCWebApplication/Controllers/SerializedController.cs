using MiniatureBottleMVCWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniatureBottleMVCWebApplication.Controllers
{
    public class SerializedController : Controller
    {
        private MiniatureBottleContext context = new MiniatureBottleContext();

        //
        // GET: /Serialized/        

        public string Index(int id = 0)
        {
            if (id == 0)
            {
                //List<Bottle> bottles = context.Bottles.ToList();
                string strReturn = string.Empty;
                //foreach (Bottle b in bottles)
                {
                    //strReturn += Bottle.Serialize(b);
                }
                return strReturn;
            }
            else
            {
                //Bottle b = context.Bottles.Find(id);
                //return Bottle.Serialize(b);
            }
            return string.Empty;
        }

        //
        // POST: /Serialized/

        [HttpPost]
        public ActionResult Post()
        {
            Stream s = Request.InputStream;
            StreamReader sr = new StreamReader(s);
            Bottle b = new Bottle();
            while (!sr.EndOfStream)
            {
                string bottle = sr.ReadLine();
                b = Bottle.Deserialize(bottle);
                if (b != null)
                {
                    context.Bottles.Add(b);
                    context.SaveChanges();
                }
                return Content("0");
            }            
            return Content("1");
        }


        //
        // POST: /Serialized/PostImage/id

        [HttpGet]
        public ActionResult GetBottle(int id = 0)
        {
            if (id == 0)
            {
                return new HttpNotFoundResult();
            }
            Bottle b = context.Bottles.Find(id);            
            return Content(b.ToString());
        }

        [HttpPost]
        public ActionResult PostImage(int id = 0)
        {
            if (id == 0)
            {
                return new HttpNotFoundResult();
            }
            Stream s = Request.InputStream;
            StreamReader streamReader = new StreamReader(s);
            string strInputStream = streamReader.ReadToEnd();
            byte[] imageBytes = Convert.FromBase64String(strInputStream);
            context.BottleImages.Add(
                new BottleImage
                {
                    BottleImageId = id,
                    BottleImg = imageBytes
                });
            context.SaveChanges();
            return File(imageBytes, "image/jpeg");
        }

        //
        // GET: /Serialized/GetImage/id
        [HttpGet]
        public ActionResult GetImage(int id = 0)
        {
            if (id == 0)
            {
                return new HttpNotFoundResult();
            }            
            var img_id = (from b
                         in context.Bottles
                         where b.Id == id
                         select
                         new { b.BottleImageId }).Single();
            BottleImage bi= context.BottleImages.Find(img_id.BottleImageId);            
            return File(bi.BottleImg, "image/" + bi.contentType);            
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }


    }
}
