using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel a)
        {
            c.Personels.Add(a);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var per = c.Personels.Find(id);
            c.Personels.Remove(per);
            c.SaveChanges() ;
            return RedirectToAction("Index");

        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var pr = c.Personels.Find(id);
            return View("PersonelGetir",pr);
        }
        public ActionResult PersonelGuncelle(Personel a)
        {
            var pers=c.Personels.Find(a.PersonelID);
            pers.PersonelAd = a.PersonelAd;
            pers.PersonelSoyad= a.PersonelSoyad;
            pers.PersonelGorsel = a.PersonelGorsel;
            pers.Departmanid= a.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatısDetay()
        {
            return View();
        }
    }
}