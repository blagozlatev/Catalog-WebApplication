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
                List<Bottle> bottles = context.Bottles.ToList();
                string strReturn = string.Empty;
                foreach (Bottle b in bottles)
                {
                    strReturn += Bottle.Serialize(b);
                }
                return strReturn;
            }
            else
            {
                Bottle b = context.Bottles.Find(id);
                return Bottle.Serialize(b);
            }            
        }

        //
        // POST: /Serialized/

        [HttpPost]
        public string Post()
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
            }            
            return b.ToString();
        }


        //
        // POST: /Serialized/PostImage/id

        [HttpPost]
        public ActionResult PostImage(int id = 0)
        {            
            if (id == 0)
            {
                return new HttpNotFoundResult();
            }
            byte[] imageBytes;
            Stream s = Request.InputStream;
            StreamReader streamReader = new StreamReader(s);
            string strInputStream = streamReader.ReadToEnd();
            imageBytes = Convert.FromBase64String(strInputStream);
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
            byte[] imageBytes;            
            imageBytes = context.BottleImages.Find(id).BottleImg.ToArray();
            return File(imageBytes, "image/jpeg");
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
