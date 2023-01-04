using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {

        // GET: Depatman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var depart = c.Departmans.Find(id);
            c.Departmans.Remove(depart);
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpn = c.Departmans.Find(id);
            return View("DepartmanGetir", dpn);
        }
        public ActionResult DepartmanGuncelle(Departman k)
        {
            var dpt = c.Departmans.Find(k.DepartmanID);
            dpt.DepartmanAd = k.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var detay = c.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt = c.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.s = dpt;
            return View(detay);
        }
        public ActionResult DepartmanPersonelSatıs(int id)
        {
            var degerler=c.satisHareketleris.Where(x=>x.Personelid==id).ToList();
            var pers = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd+" "+y.PersonelSoyad).FirstOrDefault();
            ViewBag.per = pers;
            return View(degerler);
        }
    }
}