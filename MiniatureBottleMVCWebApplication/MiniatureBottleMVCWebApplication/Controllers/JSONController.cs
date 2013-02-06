using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniatureBottleMVCWebApplication.Models;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MiniatureBottleMVCWebApplication.Controllers
{
    public class JSONController : Controller
    {
        private MiniatureBottleContext context = new MiniatureBottleContext();
        //
        // GET: /JSON/

        public JsonResult Index(int id = 0)
        {

            if (id == 0)
            {
                List<Bottle> bottles = context.Bottles.ToList();
                return this.Json(bottles, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Bottle bottle = context.Bottles.Find(id);
                return this.Json(bottle, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPut]
        public void JSONPut()
        {
            Stream s = Request.InputStream;
            StreamReader sr = new StreamReader(s);
            string json = sr.ReadToEnd();
            Bottle b = (Bottle)JsonConvert.DeserializeObject(json);
            context.Bottles.Add(b);
        }
    }
}
