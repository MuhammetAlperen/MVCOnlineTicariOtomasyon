using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context a=new Context();
        public ActionResult Index()
        {
            var urunler = a.Uruns.ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            a.Uruns.Add(p);
            a.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urn = a.Uruns.Find(id);
            a.Uruns.Remove(urn);
            a.SaveChanges();
            return RedirectToAction("index");
        }

    }
}