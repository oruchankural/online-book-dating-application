using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Siniflar;


namespace Kutuphane.Controllers
{
    public class HomeController : Controller
       
    {
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Books(string bookcategory)
        {
           
            var booktype = c.Kitaplars.Where(x => x.Producttype == 1).ToString();
            booktype = "Book";
            ViewBag.type = booktype;

          

            var Popular = from x in c.Kitaplars select x;

            if (!string.IsNullOrEmpty(bookcategory))
            {
                Popular = Popular.Where(y => y.Category.Contains(bookcategory));

            }
          
                return PartialView(Popular.Where(x=>x.BookID <8).ToList());
  
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

     







    }
}