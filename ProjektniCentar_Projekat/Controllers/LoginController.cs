using ProjektniCentar_Projekat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using System.IO;
using System.Data.SqlClient;
using System.Web.Security;

namespace ProjektniCentar_Projekat.Controllers
{
    public class LoginController : Controller
    {
        private BazaContext db = new BazaContext();
        
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SmartLogin()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Authorize(ProjektniCentar_Projekat.Models.Korisnik korisnik)
        {

            using (BazaContext db = new BazaContext())
            {
                var userDetails = db.Korisniks.Where(x => x.Username == korisnik.Username && x.Password == korisnik.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    TempData["Error"] = "Pogresan username ili password.";
                    return View("SmartLogin", korisnik);
                }
                else
                {

                    if (userDetails.PravoPristupa == "admin")
                    {
                        Session["IDKorisnik"] = userDetails.IDKorisnik;
                        Session["Ime"] = userDetails.Ime;
                        Session["Pravo pristupa"] = userDetails.PravoPristupa;
                        return RedirectToAction("ViewAdmin", "Login");
                    }
                    else if (userDetails.PravoPristupa == "korisnik")
                    {
                        Session["IDKorisnik"] = userDetails.IDKorisnik;
                        Session["Ime"] = userDetails.Ime;
                        Session["Pravo pristupa"] = userDetails.PravoPristupa;
                        return RedirectToAction("ViewKorisnik", "Login");
                    }
                    else if (userDetails.PravoPristupa == "pregledac")
                    {  
                        Session["IDKorisnik"] = userDetails.IDKorisnik;
                        Session["Ime"] = userDetails.Ime;
                        Session["Pravo pristupa"] = userDetails.PravoPristupa;
                        return RedirectToAction("ViewPregledac", "Login");
                    }
                    else
                    {
                        TempData["Error"] = "Pogresan username ili password.";
                        return View("SmartLogin", korisnik);
                    }

                }

            }

        }

        public ActionResult ViewAdmin()
        {
            return View(db.Skolas.ToList());
        }

        public ActionResult ViewKorisnik()
        {
            return View(db.Skolas.ToList());
        }

        public ActionResult ViewPregledac()
        {
            return View(db.Skolas.ToList());
        }






        // Metode za promenu podataka skole

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Skola skola = db.Skolas.Find(id);

            return View(skola);
        }

        [HttpPost]
        public ActionResult Edit(Skola skola, HttpPostedFileBase image1)
        {

            skola.Fotografija = new byte[image1.ContentLength];
            Stream fs = image1.InputStream;
            fs.Read(skola.Fotografija, 0, image1.ContentLength);

            try
            {
                db.Entry(skola).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewAdmin", "Login");
            }
            catch (Exception)
            {
                throw;
                
            }
        }






        // Metoda za izmenu podataka kada se uloguje korisnik

        [HttpGet]
        public ActionResult EditViewKorisnik(int? id)
        {
            Skola skola = db.Skolas.Find(id);

            return View(skola);
        }

        [HttpPost]
        public ActionResult EditViewKorisnik(Skola skola, HttpPostedFileBase image1)
        {

            skola.Fotografija = new byte[image1.ContentLength];
            Stream fs = image1.InputStream;
            fs.Read(skola.Fotografija, 0, image1.ContentLength);

            try
            {
                db.Entry(skola).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewKorisnik", "Login");
            }
            catch (Exception)
            {

                throw;
            }
        }






        // Metoda za citanje slike

        [HttpGet]
        public FileContentResult ReadImage(int? id)
        {
            Skola image = db.Skolas.Find(id);


            if (image.Fotografija == null)
            {
                TempData["Error"] = "Nema slike.";
            }

            return File(image.Fotografija, image.NazivSkole);
        }






        // Metoda za ispisivanje ostalih podataka skole na posebnoj stranici

        public ActionResult Details(int id)
        {
            return View(db.Skolas.Find(id));
        }

        public ActionResult DetailsViewKorisnik(int id)
        {
            return View(db.Skolas.Find(id));
        }

        public ActionResult DetailsViewPregledac(int id)
        {
            return View(db.Skolas.Find(id));
        }








        // Metode za kreiranje skole

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Skola skola, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                skola.Fotografija = new byte[image1.ContentLength];
                Stream fs = image1.InputStream;
                fs.Read(skola.Fotografija, 0, image1.ContentLength);

                try
                {
                    db.Skolas.Add(skola);
                    db.SaveChanges();
                    return RedirectToAction("ViewAdmin", "Login");
                }
                catch (Exception)
                {
                }
            }

            return View(skola);
        }








        //Metode za brisanje skole

        public ActionResult Delete(int? id)
        {
            using (db)
            {
                return View(db.Skolas.Where(x => x.IDSkola == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                var ID = new SqlParameter("@IDSkola", id);
                var rezultat1 = db.Database.ExecuteSqlCommand("ObrisiKontakt @IDSkola", ID);
                var rezultat2 = db.Database.ExecuteSqlCommand("ObrisiSkolu @IDSkola", ID);

                db.SaveChanges();

                return RedirectToAction("ViewAdmin");
            }
            catch (Exception)
            {

                throw;
            }
        }








        // Prikazivanje liste korisnika

        public ActionResult ListKorisnik()
        {
            return View(db.Korisniks.ToList());
        }








        //Metode za kreiranje novog korisnika

        [HttpGet]
        public ActionResult CreateKorisnik()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateKorisnik(Korisnik korisnik)
        {
            db.Korisniks.Add(korisnik);
            db.SaveChanges();
            return RedirectToAction("ListKorisnik", "Login");
        }








        // Metode za resetovanje lozinke i promene prava pristupa kod korisnika

        public ActionResult EditKorisnik(int? id)
        {
            Korisnik korisnik = db.Korisniks.Find(id);

            return View(korisnik);
        }

        [HttpPost]
        public ActionResult EditKorisnik(Korisnik korisnik)
        {
            try
            {
                db.Entry(korisnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListKorisnik", "Login");
            }
            catch (Exception)
            {

                throw;
            }
        }









        // Metode za brisanje korisnika

        public ActionResult DeleteKorisnik(int? id)
        {
            using (db)
            {
                return View(db.Korisniks.Where(x => x.IDKorisnik == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult DeleteKorisnik(int? id, FormCollection collection)
        {
            try
            {
                using (db)
                {
                    Korisnik korisnik = db.Korisniks.Where(x => x.IDKorisnik == id).FirstOrDefault();
                    db.Korisniks.Remove(korisnik);
                    db.SaveChanges();
                }
                return RedirectToAction("ListKorisnik");
            }
            catch (Exception)
            {

                throw;
            }
        }







        // Metoda za Log out
        
        public ActionResult LogOut()
        {
            Session.Clear();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
            FormsAuthentication.SignOut();
             return View("SmartLogin");
        }






        // Metode za dodavanje kontakta

        [HttpGet]
        public ActionResult DodajKontakt()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DodajKontakt(ListaKontakt lista, Skola skola)
        {

            db.ListaKontakts.Add(lista);
            db.SaveChanges();

            ListaKontakt lk = new ListaKontakt();
            lk.IDKontakt = lista.IDKontakt;
            Skola sk = new Skola();
            sk.IDSkola = skola.IDSkola;

            using (var context = new BazaContext())
            {
                Skola sk1 = new Skola();
                sk1.IDSkola = sk.IDSkola;
                context.Skolas.Add(sk1);
                context.Skolas.Attach(sk1);

                ListaKontakt lk1 = new ListaKontakt();
                lk1.IDKontakt = lk.IDKontakt;
                context.ListaKontakts.Add(lk1);
                context.ListaKontakts.Attach(lk1);

                sk1.ListaKontakts = new List<ListaKontakt>();
                sk1.ListaKontakts.Add(lk1);

                context.SaveChanges();
            }

            return RedirectToAction("ViewAdmin", "Login");
        }






        // Metoda za prikazivanje kontakata u parcijalnom pogledu

        public ActionResult PrikaziKontakte(int ID)
        {
            using (var context = new BazaContext())
            {
                var id = new SqlParameter("@IDSkola", ID);
                var rezultat = context.Database.SqlQuery<ListaKontakt>("PrikaziKontakte @IDSkola", id);

                return View(rezultat.ToList());
            }
        }
    }
}