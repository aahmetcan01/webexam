using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MVCDbStokEntities1 db = new MVCDbStokEntities1();
        public ActionResult Index()
        {
            var degerler = db.TBLUrunler.ToList();
            return View(degerler);
        }


        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.TBLKategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriId.ToString()

                                             }).ToList();

            ViewBag.dgr = degerler;






            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(TBLUrunler p1)
        {

            var ktg = db.TBLKategoriler.Where(m => m.KategoriId == p1.TBLKategoriler.KategoriId).FirstOrDefault();
            p1.TBLKategoriler = ktg;
            db.TBLUrunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var urun = db.TBLUrunler.Find(id);
            db.TBLUrunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Güncelle(int id)
        {
            var urun = db.TBLUrunler.Find(id);
            return View("Güncelle", urun);
        }

        public ActionResult Guncelle(TBLUrunler p1)
        {

            var urn = db.TBLUrunler.Find(p1.urunId);
            urn.urunAd = p1.urunAd;
           urn.urunKategori = p1.urunKategori;
           urn.fiyat = p1.fiyat;
            urn.marka = p1.marka;
            urn.stok = p1.stok;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}