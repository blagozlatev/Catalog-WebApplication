using MiniatureBottleMVCWebApplication.Models;
using System;
using System.Collections.Generic;
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
            string strReturn = string.Empty;
            if (id == 0)
            {
                List<Bottle> bottles = context.Bottles.ToList();
                foreach (Bottle b in bottles)
                {
                    strReturn += b.Age + "#" + b.Alcohol + "#" + b.AlcoholType + "#" +
                        b.City + "#" + b.Color + "#" + b.Content + "#" + b.Continent + "#"
                        + b.Country + "#" + b.ID + "#" + b.Manufacturer + "#" + b.Material
                         + "#" + b.Name + "#" + b.Note + "#" + b.Shape + "#" + b.Shell + "\n";
                }
                return strReturn;
            }
            else
            {
                Bottle b = context.Bottles.Find(id);
                return strReturn += b.Age + "#" + b.Alcohol + "#" + b.AlcoholType + "#" +
                        b.City + "#" + b.Color + "#" + b.Content + "#" + b.Continent + "#"
                        + b.Country + "#" + b.ID + "#" + b.Manufacturer + "#" + b.Material
                         + "#" + b.Name + "#" + b.Note + "#" + b.Shape + "#" + b.Shell + "\n";
            }            
        }

        //
        // POST: /Serialized/

        [HttpPost]
        public string Post()
        {
            Bottle b = new Bottle();
            Stream s = Request.InputStream;
            StreamReader sr = new StreamReader(s);
            while (!sr.EndOfStream)
            {
                string bottle = sr.ReadLine();
                string[] btlArgs = bottle.Split('#');                
                b.Age = int.Parse(btlArgs[0]);
                b.Alcohol = btlArgs[1];
                b.AlcoholType = btlArgs[2];
                b.City = btlArgs[3];
                b.Color = btlArgs[4];
                b.Content = btlArgs[5];
                b.Continent = btlArgs[6];
                b.Country = btlArgs[7];
                b.ID = int.Parse(btlArgs[8]);
                b.Manufacturer = btlArgs[9];
                b.Material = btlArgs[10];
                b.Name = btlArgs[11];
                b.Note = btlArgs[12];
                b.Shape = btlArgs[13];
                b.Shell = btlArgs[14];                
                context.Bottles.Add(b);
                context.SaveChanges();
            }            
            return b.ToString();
        }

    }
}
