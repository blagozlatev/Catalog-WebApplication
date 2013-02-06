using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniatureBottleMVCWebApplication.Models;

namespace MiniatureBottleMVCWebApplication.Controllers
{
    public class JSONController : Controller
    {
        //
        // GET: /JSON/

        public JsonResult Index()
        {
            List<Bottle> bottles;
            using (MiniatureBottleContext context = new MiniatureBottleContext()){
                bottles = context.Bottles.ToList();                
            }            
            return this.Json(bottles, JsonRequestBehavior.AllowGet);
        }

    }
}
