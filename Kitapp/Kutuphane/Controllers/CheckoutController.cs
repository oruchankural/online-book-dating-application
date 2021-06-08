using Kutuphane.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        Context c = new Context();
        public ActionResult Index(int id)
        {
            var checkout = c.Kitaplars.Where(x => x.BookID == id).ToList();
            var bookname = c.Kitaplars.Where(x => x.BookID == id).Select(y => y.BookName).FirstOrDefault();
            ViewBag.bn = bookname;
            var bookprice = c.Kitaplars.Where(x => x.BookID == id).Select(y => y.Price).FirstOrDefault();
            ViewBag.bp = bookprice;
            return View(checkout);
        }
    }
}