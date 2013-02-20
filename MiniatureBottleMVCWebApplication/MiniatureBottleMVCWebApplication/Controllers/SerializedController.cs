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
                    strReturn += b.Serialize();
                }
                return strReturn;
            }
            else
            {                
                return context.Bottles.Find(id).Serialize();
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
        
        [HttpPost]
        public ActionResult PostImage(string id="0")
        {
            int intID = 0;
            if (int.TryParse(id, out intID))
            {
                intID = int.Parse(id);
            }
            if (intID == 0)
            {
                return new HttpNotFoundResult();
            }
            byte[] imageBytes;
            Stream s = Request.InputStream;
            StreamReader streamReader = new StreamReader(s);
            string strInputStream = streamReader.ReadToEnd();
            imageBytes = Convert.FromBase64String(strInputStream);
            context.BottleImages.Add(new BottleImage() {ID=intID, BImage=imageBytes});
            context.SaveChanges();
            //using (MemoryStream memoryStream = new MemoryStream(imageBytes))
            //{
            //    Bitmap bmp = new Bitmap(memoryStream);                

            //}            
            return File(imageBytes, "image/jpeg");
        }

        [HttpGet]
        public ActionResult GetImage(string id = "0")
        {
            int intID = 0;            
            if (int.TryParse(id, out intID))
            {
                intID = int.Parse(id);
            }
            if (intID == 0)
            {
                return new HttpNotFoundResult();
            }
            BottleImage bi = context.BottleImages.Find(intID);
            if (bi != null)
            {
                byte[] imageBytes = bi.BImage;
                return File(imageBytes, "image/jpeg");
            }
            return null;
        }
    }
}
