using Shoppers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shoppers.Controllers
{
    public class HomeController : Controller
    {
        private shopperEntities db = new shopperEntities();

        public ActionResult TestIndex()
        {
            return View();
        }
         [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Stock(string id)
        {
            var stock = db.Stocks.Where(d => d.CategoryId == id);
            ViewBag.Category = id;
            return View(stock.ToList());
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}