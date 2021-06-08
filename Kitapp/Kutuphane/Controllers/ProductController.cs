using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Siniflar;
namespace Kutuphane.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index(string bookcategory)
        {
            var booktype = c.Kitaplars.Where(x => x.Producttype == 1).ToString();
            booktype = "Book";
            ViewBag.type = booktype;


        

            var Books = from x in c.Kitaplars select x;

            if (!string.IsNullOrEmpty(bookcategory))
            {
                Books = Books.Where(y => y.Category.Contains(bookcategory));
             
            }
            return View(Books.ToList());
        }
   
        public ActionResult Ebook()
        {
            var booktype = c.Kitaplars.Where(x => x.Producttype == 2).ToString();
            booktype = "E-book";
            ViewBag.type = booktype;
            var books = c.Kitaplars.Where(x => x.Producttype == 2).ToList();
            return View(books);
        }

      
        public PartialViewResult Exchangehome ()
        {
            var booktype = c.Exchanges.ToString();
            booktype = "Exchange";
            ViewBag.type = booktype;



            var books = c.Exchanges.Where(x=>x.BookID<=4).ToList();
            return PartialView(books);
        }
        
        public ActionResult Exchange()
        {
          

            var booktype = c.Exchanges.ToString();
            booktype = "Exchange";
            ViewBag.type = booktype;



            var books = c.Exchanges.ToList();
         
            return View(books);
        }
        public ActionResult Productdetails(int id)
        {
            var details = c.Kitaplars.Where(x => x.BookID == id).ToList();
            return View(details);
        }
     
        public ActionResult Exchangedetails(int id)
        {
            var user = (string)Session["Username"];
            var username = c.Users.Where(x => x.Username == user).Select(y => y.Username).FirstOrDefault();
            ViewBag.username = username;
            var details = c.Exchanges.Where(x => x.BookID == id).ToList();
            return View(details);
        }

       



    }
}