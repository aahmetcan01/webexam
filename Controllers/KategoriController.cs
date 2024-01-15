using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MVCDbStokEntities1 db = new MVCDbStokEntities1();
        public ActionResult Index()
        {
            var degerler = db.TBLKategoriler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKategoriler p1)
        {
            db.TBLKategoriler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var kategori = db.TBLKategoriler.Find(id);
            db.TBLKategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Güncelle(int id)
        {
            var ktgr = db.TBLKategoriler.Find(id);
            return View("Güncelle", ktgr);
        }

        public ActionResult Guncelle(TBLKategoriler p1)
        {

            var ktgg = db.TBLKategoriler.Find(p1.KategoriId);
            ktgg.KategoriAd = p1.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}