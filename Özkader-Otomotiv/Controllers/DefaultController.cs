using Özkader_Otomotiv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Özkader_Otomotiv.Controllers
{
    public class DefaultController : Controller
    {
        OzkaderDBEntities2 db = new OzkaderDBEntities2();

        // GET: Default
        public ActionResult Anamenu()
        {
            return View();
        }

        public ActionResult Hakkımızda()
        {
            return View();
        }

        public ActionResult kvkaydınlatma()
        {
            return View();
        }

        public ActionResult kvkbilgilendirme()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Iletisim_form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Iletisim_form(Tbl_Iletisim p)
        {
            db.Tbl_Iletisim.Add(p);
            db.SaveChanges();
            return RedirectToAction("Iletisim_form");
        }

        public ActionResult Iletisim_bilgi()
        {
            return View();
        }

        public ActionResult Google_map()
        {
            return View();
        }

        public ActionResult Katalog()
        {
            var t = db.Tbl_Kategori.ToList();
            return View(t);
        }

        public ActionResult Urunler(int id)
        {
            var x = db.Tbl_Urun.Where(t => t.UrunKategori == id).ToList();
            string ad = "";

            //Server=.\\MSSQLSERVER2019;Database=OzkaderDB;User ID=muharrem;Password=Atombilmez42-;MultipleActiveResultSets=True;App=EntityFramework&quot;
            //Server=myServerAddress;Database=myDataBase;Integrated Security=True;Asynchronous Processing=True;

            SqlConnection conn = new SqlConnection("Server=DESKTOP-1Q8GSDA;Database=OzkaderDB;Integrated Security=True;Asynchronous Processing=True;");
            SqlCommand comm = new SqlCommand("select KategoriAd from Tbl_Kategori where KategoriID = @p1", conn);
            comm.Parameters.AddWithValue("@p1", id);
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while(dr.Read())
            {
                ad = dr[0].ToString();
            }
            conn.Close();
            dr.Close();

            Session.Add("id", ad);
            return View(x);
        }
    }
}