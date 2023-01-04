using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context(); 
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult YeniCari(Cariler p)
        {
            p.Durum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var car = c.Carilers.Find(id);
            car.Durum = false;
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult CariGetir(int id)
        {
            var cr = c.Carilers.Find(id);
            return View("CariGetir", cr);
        }
        public ActionResult CariGuncelle(Cariler p) 
        {
            var cri = c.Carilers.Find(p.CariID);
            cri.CariAd=p.CariAd;
            cri.CariSoyad=p.CariSoyad;
            cri.CariSehir=p.CariSehir;
            cri.CariMail=p.CariMail;
            c.SaveChanges();
            return RedirectToAction("index");
        }
    }
}