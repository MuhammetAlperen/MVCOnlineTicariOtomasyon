using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class SatısController : Controller
    {
        // GET: Satıs
        Context c=new Context();
        public ActionResult Index()
        {
            var degerler=c.satisHareketleris.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatıs()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatıs(SatisHareketleri s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.satisHareketleris.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            var sat = c.satisHareketleris.Find(id);
            return View("SatisGetir", sat);
        }
        public ActionResult SatisGüncelle(SatisHareketleri p)
        {
            var sts = c.satisHareketleris.Find(p.SatisID);
            sts.Urunid = p.Urunid;
            sts.Cariid=p.Cariid;
            sts.Personelid=p.Personelid;
            sts.Adet=p.Adet;
            sts.Fiyat=p.Fiyat;
            sts.ToplamTutar=p.ToplamTutar;
            sts.Tarih=p.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = c.satisHareketleris.Where(x => x.SatisID == id).ToList();
            return View(degerler);
        }
    }
}