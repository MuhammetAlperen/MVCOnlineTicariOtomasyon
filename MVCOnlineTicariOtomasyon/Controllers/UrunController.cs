﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;
using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System.Security.Cryptography;
using System.Web.UI.WebControls;


namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> değer1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = değer1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
          
            var urn = c.Uruns.Find(id);
            c.Uruns.Remove(urn);
            c.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult UrunGetir(int id)
        {

            List<SelectListItem> değer1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = değer1;
            var urundeger=c.Uruns.Find(id);
            return View("UrunGetir",urundeger);
        }
        public ActionResult UrunGuncelle(Urun p)
        {
            var urn = c.Uruns.Find(p.UrunID);
            urn.AlisFiyat=p.AlisFiyat;
            urn.Durum=p.Durum;
            urn.Kategoriid = p.Kategoriid;
            urn.Marka=p.Marka;
            urn.Stok=p.Stok;
            urn.UrunAd=p.UrunAd;
            urn.SatisFiyat=p.SatisFiyat;
            urn.UrunAd = p.UrunAd;
            urn.UrunGorsel=p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }

    }
}