using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DaneKsiązek.Models;

namespace DaneKsiązek.Controllers
{
    public class HomeController : Controller
    {

        private KsiazkiEntities _db = new KsiazkiEntities();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View(_db.Ksiazki.ToList());
        }
        //
        // GET: Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //POST : /Home/Create

        [HttpPost]
        public ActionResult Create(Ksiazki newKsiazka)
        {
            if (ModelState.IsValid)
            {
                _db.Ksiazki.Add(newKsiazka);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(newKsiazka);
            }
        }

        // GET : /Home/Edit/5

        public ActionResult Edit(int id)
        {
            var ksiazkaToEdit = (from Ksiazki in _db.Ksiazki where Ksiazki.ksiazkaID == id select Ksiazki).First();
            return View(ksiazkaToEdit);
        }

        // POST : /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Ksiazki ksiazkaToEdit)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(ksiazkaToEdit).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            try
            {
                // TODO: ADD update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var ksiazkaToDel = (from Ksiazki in _db.Ksiazki where Ksiazki.ksiazkaID == id select Ksiazki).First();
            return View(ksiazkaToDel);
        }

        [HttpPost]

        public ActionResult Delete(int id,Ksiazki ksiazkaToDel)
        {
            var SelKsiazka = (from Ksiazki in _db.Ksiazki where Ksiazki.ksiazkaID == id select Ksiazki).First();
            if (!ModelState.IsValid)
                return View(SelKsiazka);
            _db.Ksiazki.Remove(SelKsiazka);
            _db.SaveChanges();
            return RedirectToAction("Index");
            try
            {
                // TODO: ADD update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var ksiazkaToDetails = (from Ksiazki in _db.Ksiazki where Ksiazki.ksiazkaID == id select Ksiazki).First();
            return View(ksiazkaToDetails);

        }
        public ActionResult About()
        {
            ViewBag.Message = "Aplikacja webowa o nazwie Baza książek";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}