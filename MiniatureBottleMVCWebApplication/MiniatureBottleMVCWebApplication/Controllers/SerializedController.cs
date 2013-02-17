﻿using MiniatureBottleMVCWebApplication.Models;
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
        
        public ActionResult PostImage(string id)
        {
            byte[] data;
            using (var fs = new System.IO.FileStream("image.jpg", System.IO.FileMode.Open))
            {
                Bitmap bmp = new Bitmap(fs);
                using (MemoryStream stream = new MemoryStream())
                {
                    bmp.Save(stream, ImageFormat.Bmp);
                    data = stream.ToArray();

                }
            }   
            return File(data, "image/bmp");
        }
    }
}
