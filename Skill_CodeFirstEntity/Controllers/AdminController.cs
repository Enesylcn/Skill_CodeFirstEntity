using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Skill_CodeFirstEntity.Models.Sınıflar;

namespace Skill_CodeFirstEntity.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        CONTEXT c = new CONTEXT();
        public ActionResult Index()
        {
            
            var degerler = c.YETENEKLERS.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(YETENEKLER y)
        {
            
            c.YETENEKLERS.Add(y);
            c.SaveChanges();
            return View();
        }
        public ActionResult YetenekSil(int id)
        {

           var deger= c.YETENEKLERS.Find(id);
            c.YETENEKLERS.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekGuncelle(int id)
        {
            var deger = c.YETENEKLERS.Find(id);

            return View("YetenekGuncelle", deger);
        }
        [HttpPost]
        public ActionResult YetenekGuncelle(YETENEKLER y)
        {
            var deger = c.YETENEKLERS.Find(y.ID);
            deger.ACIKLAMA = y.ACIKLAMA;
            deger.DEGER = y.DEGER;
            c.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}