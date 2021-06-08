using Kutuphane.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Kutuphane.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        Context c = new Context();


        public ActionResult UserPanel()
        {
            var user = (string)Session["Username"];
            var username = c.Users.Where(x => x.Username == user).Select(y => y.Username).FirstOrDefault();
            ViewBag.username = username;
            var sifre = c.Users.Where(x => x.Username == user).Select(y => y.Password).FirstOrDefault();
            ViewBag.password = sifre;
            var namesurname = c.Users.Where(x => x.Username == user).Select(y => y.NameSurname).FirstOrDefault();
            ViewBag.namesurname = namesurname;
            var email = c.Users.Where(x => x.Username == user).Select(y => y.Email).FirstOrDefault();
            ViewBag.email = email;
            var gender = c.Users.Where(x => x.Username == user).Select(y => y.Sex).FirstOrDefault();
            ViewBag.gender = gender;
            var date = c.Users.Where(x => x.Username == user).Select(y => y.Birthofdate).FirstOrDefault();
            ViewBag.date = date.ToShortDateString();
            var address = c.Users.Where(x => x.Username == user).Select(y => y.Address).FirstOrDefault();
            ViewBag.adr = address;
            var age = c.Users.Where(x => x.Username == user).Select(y => y.Birthofdate).FirstOrDefault();
            var nowdate = DateTime.Today;
            int ageof = nowdate.Year - age.Year;
            ViewBag.age = ageof;

            var alldate = c.Users.Where(x => x.Username == user).Select(y => y.Birthofdate).FirstOrDefault();
            int month = alldate.Month;
            int day = alldate.Day;

            if ((month == 12 & day >= 22) || (month == 1 & day <= 21))
            {
                ViewBag.b = "CAPRICORN";
            }
            if ((month == 10 & day >= 23) || (month == 11 & day <= 21))
            {
                ViewBag.b = "SCORPIO";
            }
            if ((month == 3 & day >= 21) || (month == 4 & day <= 20))
            {
                ViewBag.b = "ARIES";
            }
            if ((month == 4 & day >= 21) || (month == 5 & day <= 21))
            {
                ViewBag.b = "TAURUS";
            }
            if ((month == 5 & day >= 22) || (month == 6 & day <= 22))
            {
                ViewBag.b = "GERNINI";
            }

            if ((month == 6 & day >= 23) || (month == 7 & day <= 22))
            {
                ViewBag.b = "CANCER";
            }

            if ((month == 7 & day >= 23) || (month == 8 & day <= 22))
            {
                ViewBag.b = "LEO";
            }

            if ((month == 8 & day >= 23) || (month == 9 & day <= 22))
            {
                ViewBag.b = "VIRGO";
            }
            if ((month == 9 & day >= 23) || (month == 10 & day <= 22))
            {
                ViewBag.b = "LBIRA";
            }

            if ((month == 10 & day >= 22) || (month == 11 & day <= 21))
            {
                ViewBag.b = "SAGITTARIUS ";
            }

            if ((month == 1 & day >= 22) || (month == 2 & day <= 19))
            {
                ViewBag.b = "AQUARIUS";
            }

            if ((month == 2 & day >= 20) || (month == 3 & day <= 20))
            {
                ViewBag.b = "PISCES";
            }
            return View();
        }
      
      

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User u)
        {
            var bilgiler = c.Users.FirstOrDefault(x => x.Username == u.Username && x.Password == u.Password);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Username, false);
                Session["Username"] = bilgiler.Username.ToString();
                return RedirectToAction("UserPanel","User");

            }

            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
            public ActionResult LogOut()
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                return RedirectToAction("Index","Home");
            }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Signup(User p)
        {
            var email = c.Users.Where(x => x.Username == p.Username ).FirstOrDefault();
            var mail = c.Users.Where(x => x.Email == p.Email).FirstOrDefault();
       
            if (ModelState.IsValid && email == null && mail == null)
            {
                c.Users.Add(p);
                c.SaveChanges();
                return View("MailSuccess");
               
            }

            else
            {

                return View("MailAlreadyExist");
            }
        }
        [AllowAnonymous]
        public PartialViewResult MailSuccess()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult MailAlreadyExist()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult AddBook()
        {

            return View();
        }


        [HttpPost]
        public ActionResult AddBook(Exchange e)
        {
            var user = (string)Session["Username"];
            var username = c.Users.Where(x => x.Username == user).Select(y => y.Username).FirstOrDefault();
            ViewBag.username = username;

            c.Exchanges.Add(e);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddedBooks()
        {
            var user = (string)Session["Username"];
            var username = c.Users.Where(x => x.Username == user).Select(y => y.Username).FirstOrDefault();
            var addedbook = c.Exchanges.Where(x=>x.Username == username).ToList();
            return View(addedbook);
        }


    }
    }
