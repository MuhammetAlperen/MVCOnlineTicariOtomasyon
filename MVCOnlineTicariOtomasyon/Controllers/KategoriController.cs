using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index()
        {
            var değerler=c.Kategoris.ToList();
            return View(değerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult KategoriSil(int id) 
        {
            var ktg=c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
            
        }
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var ktgr=c.Kategoris.Find(k.KategoriID);
            ktgr.KategoriAd = k.KategoriAd;
           c.SaveChanges();
            return RedirectToAction("index");
        }
    }
}