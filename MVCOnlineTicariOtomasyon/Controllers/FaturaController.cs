using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c=new Context();
        public ActionResult Index()
        {
            var degerler = c.Faturalars.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar s)
        {
            c.Faturalars.Add(s);
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura=c.Faturalars.Find(id);
            return View("FaturaGetir",fatura);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fat = c.Faturalars.Find(f.FaturaID);
            fat.FaturaSeriNo= f.FaturaSeriNo;
            fat.FaturaSıraNo = f.FaturaSıraNo;
            fat.VergiDairesi= f.VergiDairesi;
            fat.Tarih= f.Tarih;
            fat.Saat= f.Saat;
            fat.TeslimAlan= f.TeslimAlan;
            fat.TeslimEden= f.TeslimEden;
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler=c.FaturaKalems.Where(x=>x.Faturaid==id).ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();

        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("index");

        }


    }
}