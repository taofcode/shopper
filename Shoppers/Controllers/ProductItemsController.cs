using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shoppers.Models;

namespace Shoppers.Controllers
{
    [Authorize]
    public class ProductItemsController : Controller
    {
        private shopperEntities db = new shopperEntities();

        // GET: ProductItems
        public ActionResult Index()
        {
            var productItems = db.ProductItems.Include(p => p.Cart).Include(p => p.Stock);
            return View(productItems.ToList());
        }

        // GET: ProductItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductItem productItem = db.ProductItems.Find(id);
            if (productItem == null)
            {
                return HttpNotFound();
            }
            return View(productItem);
        }

        // GET: ProductItems/Create
        public ActionResult Create()
        {
            ViewBag.CartId = new SelectList(db.Carts, "Id", "CartId");
            ViewBag.StockId = new SelectList(db.Stocks, "Id", "Name");
            return View();
        }

        // POST: ProductItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StockId,LastDateUpdated,UpdatedBy,Qty,CartId")] ProductItem productItem)
        {
            if (ModelState.IsValid)
            {
                db.ProductItems.Add(productItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CartId = new SelectList(db.Carts, "Id", "CartId", productItem.CartId);
            ViewBag.StockId = new SelectList(db.Stocks, "Id", "Name", productItem.StockId);
            return View(productItem);
        }

        // GET: ProductItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductItem productItem = db.ProductItems.Find(id);
            if (productItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.CartId = new SelectList(db.Carts, "Id", "CartId", productItem.CartId);
            ViewBag.StockId = new SelectList(db.Stocks, "Id", "Name", productItem.StockId);
            return View(productItem);
        }

        // POST: ProductItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StockId,LastDateUpdated,UpdatedBy,Qty,CartId")] ProductItem productItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CartId = new SelectList(db.Carts, "Id", "CartId", productItem.CartId);
            ViewBag.StockId = new SelectList(db.Stocks, "Id", "Name", productItem.StockId);
            return View(productItem);
        }

        // GET: ProductItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductItem productItem = db.ProductItems.Find(id);
            if (productItem == null)
            {
                return HttpNotFound();
            }
            return View(productItem);
        }

        // POST: ProductItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductItem productItem = db.ProductItems.Find(id);
            db.ProductItems.Remove(productItem);
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
