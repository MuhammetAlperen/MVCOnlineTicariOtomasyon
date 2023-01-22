using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        //GET:CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
       
    }
}