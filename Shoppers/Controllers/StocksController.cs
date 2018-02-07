using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shoppers.Models;
using System.IO;

namespace Shoppers.Controllers
{
    [Authorize]
    public class StocksController : Controller
    {
        private shopperEntities db = new shopperEntities();

        // GET: Stocks
        public ActionResult Index()
        {
            var stocks = db.Stocks.Include(s => s.Category);
            return View(stocks.ToList());
        }

        // GET: Stocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // GET: Stocks/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Description");
            return View();
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Stock stock, HttpPostedFileBase file)
        {
            DateTime d1 = DateTime.Now;
            string tempDate = d1.Year.ToString() + d1.Month.ToString("0#") + d1.Day.ToString("0#");
            string pathToUpload = "~/Products/";
            if (file != null)
            {
                Random r = new Random();
                int n = r.Next(0, 20900);
                string genName = stock.Description;
                if (genName.Length > 6)
                {
                    genName = genName.Substring(1, 8).Trim();
                }
                genName = genName + n.ToString();

                string filtype = file.ContentType.Substring(file.ContentType.LastIndexOf('/'), file.ContentType.Length - file.ContentType.LastIndexOf('/')).Replace("/", "");
                string tempPath = stock.Name.Substring(0, 4).Trim().Replace(" ", "") + genName + "_" + tempDate + "." + filtype;
                string actualPath = Path.Combine(Server.MapPath(pathToUpload), tempPath);
                string relPath = stock.Name.Substring(0, 4).Trim().Replace(" ", "") + genName + "_" + tempDate + "." + filtype;
                file.SaveAs(actualPath);
              //  stock.PathUrl = relPath.Replace("~", "");

            }
            db.Stocks.Add(stock);
            if (db.SaveChanges() > 0) { 
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Description", stock.CategoryId);
            return View(stock);
        }

        // GET: Stocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Description", stock.CategoryId);
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Stock stock, HttpPostedFileBase file)
        {
            DateTime d1 = DateTime.Now;
            string tempDate = d1.Year.ToString() + d1.Month.ToString("0#") + d1.Day.ToString("0#");
            string pathToUpload = "~/Products/";
            if (file != null)
            {
                Random r = new Random();
                int n = r.Next(0, 20900);
                string genName = stock.Description;
                if (genName.Length > 6)
                {
                    genName = genName.Substring(1, 8).Trim();
                }
                genName = genName + n.ToString();

                string filtype = file.ContentType.Substring(file.ContentType.LastIndexOf('/'), file.ContentType.Length - file.ContentType.LastIndexOf('/')).Replace("/", "");
                string tempPath = stock.Name.Substring(0, 4).Trim().Replace(" ", "") + genName + "_" + tempDate + "." + filtype;
                string actualPath = Path.Combine(Server.MapPath(pathToUpload), tempPath);
                string relPath = stock.Name.Substring(0, 4).Trim().Replace(" ", "") + genName + "_" + tempDate + "." + filtype;
                file.SaveAs(actualPath);
                //  stock.PathUrl = relPath.Replace("~", "");

            }
            db.Entry(stock).State = EntityState.Modified;
            if (db.SaveChanges() > 0) { 
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Description", stock.CategoryId);
            return View(stock);
        }

        // GET: Stocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stock stock = db.Stocks.Find(id);
            db.Stocks.Remove(stock);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
