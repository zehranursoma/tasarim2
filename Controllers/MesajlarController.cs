using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcKutuphaneP.Models.Entitiy;
namespace mvcKutuphaneP.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var uyemmail = (string)Session["Mail"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x => x.ALICI == uyemmail.ToString()).ToList();
            return View(mesajlar);
        }

        public ActionResult Giden()
        {
            var uyemmail = (string)Session["Mail"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x => x.GONDEREN == uyemmail.ToString()).ToList();
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLAR t)
        {
            var uyemmail = (string)Session["Mail"].ToString();
            t.GONDEREN = uyemmail.ToString();
            t.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLMESAJLAR.Add(t);
            db.SaveChanges();
            return RedirectToAction("Giden","Mesajlar");
        }
    }
}