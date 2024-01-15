using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;
namespace MVCStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MVCDbStokEntities1 db = new MVCDbStokEntities1();
        public ActionResult Index()
        {
            var degerler = db.TBLMusteriler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MusteriEkle(TBLMusteriler p1)
        {
            db.TBLMusteriler.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var musteri = db.TBLMusteriler.Find(id);
            db.TBLMusteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Güncelle(int id)
        {
            var musteri = db.TBLMusteriler.Find(id);
            return View("Güncelle",musteri);
        }

        public ActionResult Guncelle(TBLMusteriler p1)
        {
            var mstr = db.TBLMusteriler.Find(p1.musteriId);
            mstr.musteriAd = p1.musteriAd;
            mstr.musteriSoyad = p1.musteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
            
    }
}