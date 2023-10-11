using Özkader_Otomotiv.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Özkader_Otomotiv.Controllers
{
    public class AdminController : Controller
    {
        OzkaderDBEntities2 db = new OzkaderDBEntities2();

        // GET: Admin
        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Tbl_Admin t)
        {
            var info = db.Tbl_Admin.FirstOrDefault(x => x.AdminKullanici == t.AdminKullanici && x.AdminSifre == t.AdminSifre);
            if (info != null)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("GirisYap", "Admin");
            }
        }

        public ActionResult Index(int sayfa = 1)
        {
            var t = db.Tbl_Kategori.ToList().ToPagedList(sayfa, 5);
            return View(t);
        }

        public ActionResult Sil(int id)
        {
            var t = db.Tbl_Kategori.Find(id);
            db.Tbl_Kategori.Remove(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Tbl_Kategori p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.KategoriFoto = "/Image/" + dosyaadi + uzanti;
            }

            db.Tbl_Kategori.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Urunler(int sayfa = 1)
        {
            var t = db.Tbl_Urun.ToList().ToPagedList(sayfa, 5);
            return View(t);
        }

        [HttpGet]
        public ActionResult Ekle2()
        {
            List<SelectListItem> ktg = (from x in db.Tbl_Kategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.KategoriAd,
                                            Value = x.KategoriID.ToString()
                                        }).ToList();
            ViewBag.drop = ktg;
            return View();
        }

        [HttpPost]
        public ActionResult Ekle2(Tbl_Urun p)
        {
            if(Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.UrunFotograf = "/Image/" + dosyaadi + uzanti;
            }

            var ktgr = db.Tbl_Kategori.Where(x => x.KategoriID == p.Tbl_Kategori.KategoriID).FirstOrDefault();
            p.Tbl_Kategori = ktgr;

            db.Tbl_Urun.Add(p);
            db.SaveChanges();
            return RedirectToAction("Urunler");
        }

        public ActionResult Sil2(int id)
        {
            var t = db.Tbl_Urun.Find(id);
            db.Tbl_Urun.Remove(t);
            db.SaveChanges();
            return RedirectToAction("Urunler");
        }

        public ActionResult Iletisim(int sayfa = 1)
        {
            var t = db.Tbl_Iletisim.ToList().ToPagedList(sayfa, 5);
            return View(t);
        }
        public ActionResult Sil3(int id)
        {
            var t = db.Tbl_Iletisim.Find(id);
            db.Tbl_Iletisim.Remove(t);
            db.SaveChanges();
            return RedirectToAction("Iletisim");
        }
    }
}