using MiniatureBottleMVCWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        public ActionResult Index(int id = 0)
        {
            if (id == 0)
            {
                List<Bottle> bottles = context.Bottles.ToList();
                string strReturn = string.Empty;
                foreach (Bottle b in bottles)
                {
                    strReturn += Bottle.Serialize(b);
                }
                return Content(strReturn);
            }
            else
            {
                Bottle b = context.Bottles.Find(id);
                if (b == null)
                {
                    return Content("0");
                }
                return Content(Bottle.Serialize(b));
            }
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
                return Content("1");
            }
            return Content("0");
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
            Stream s = Request.InputStream;
            StreamReader streamReader = new StreamReader(s);
            string strInputStream = streamReader.ReadToEnd();
            byte[] imageBytes = Convert.FromBase64String(strInputStream);
            try
            {
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    Bitmap bit = ImageFunctions.resizeImage
                        (new Bitmap(ms), new Size() { Width = 800, Height = 800 });
                    MemoryStream ms_arr = new MemoryStream();
                    bit.Save(ms_arr, ImageFormat.Jpeg);

                    Bottle b = context.Bottles.Find(id);
                    b.BottleImage.BottleImg = ms_arr.ToArray();
                    context.Entry(b).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return Content("1");
            }
            catch (Exception ex)
            { }
            return Content("0");
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
            var imageId = (from b
                         in context.Bottles
                           where b.Id == id
                           select
                           new { b.BottleImageId }).Single();
            BottleImage bi = context.BottleImages.Find(imageId.BottleImageId);
            return File(bi.BottleImg, "image/jpeg");
        }

        //
        // GET: /Serialized/GetImageBase/id
        [HttpGet]
        public ActionResult GetImageBase(int id = 0)
        {
            if (id != 0)
            {
                try
                {
                    var imageId = (from b
                                 in context.Bottles
                                   where b.Id == id
                                   select
                                   new { b.BottleImageId }).Single();
                    BottleImage bi = context.BottleImages.Find(imageId.BottleImageId);
                    return Content(Convert.ToBase64String
                    (bi.BottleImg, Base64FormattingOptions.None));
                }
                catch (NullReferenceException ex)
                {
                    return Content("0");
                }
                catch (InvalidOperationException ex)
                {
                    return Content("0");
                }
            }
            return Content("0");
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }


    }
}