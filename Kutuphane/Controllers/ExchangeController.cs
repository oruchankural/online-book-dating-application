using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Siniflar;

namespace Kutuphane.Controllers
{
    public class ExchangeController : Controller
    {
        // GET: Exchange
        Context c = new Context();
        public ActionResult Index()
        {
            var booktype = c.Exchanges.ToString();
            booktype = "Exchange";
            ViewBag.type = booktype;
            var books = c.Exchanges.ToList();
            var username = c.Exchanges.Select(x => x.Username).ToList();
            ViewBag.username = username;
            return View(books);
          
        }
    }
}