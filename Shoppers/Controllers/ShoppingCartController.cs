using Shoppers.Models;
using Shoppers.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Shoppers.Controllers
{
    public class ShoppingCartController : Controller
    {
        private shopperEntities db = new shopperEntities();
        [Authorize]
        public ActionResult Cart()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = (decimal)cart.GetTotal()
            };
            Session["Msg"] = "Status";
            Session["CartItems"] = viewModel;
            Session["CartTotal"] = viewModel.CartTotal;
            ViewBag.GrandTotal = viewModel.CartTotal;

            // Return the view
            return View(viewModel);

        }
        public PartialViewResult CartPartial()
        {
            ShoppingCartViewModel model = (ShoppingCartViewModel)Session["CartItems"];
            return PartialView(model);
        }
        [Authorize]
        public ActionResult AddToCart(int id)
        {
            //var papersSearch = db.Papers.FirstOrDefault(d => d.Name == name);
            //var mybundle = db.Bundles.FirstOrDefault(s=>s.PaperId== papersSearch.Id);
            //// Retrieve the bundle from the database
            var addedBundle = db.Stocks.FirstOrDefault(b => b.Id == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedBundle);

            // Go back to the main store page for more shopping
            return RedirectToAction("Cart");
        }
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the pdt to display confirmation
            string productName = db.Stocks.FirstOrDefault(item => item.Id == id).Name;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(productName) +
                    " has been removed from your shopping cart.",
                CartTotal = (decimal)cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };

            //  return Json(results);
            return RedirectToAction("Cart", "ShoppingCart");

        }

        public ActionResult RemoveCartItem(int id)
        {

            ShoppingCart shop = new ShoppingCart();
            shop.RemoveCartItem(id);

            return RedirectToAction("Cart", "ShoppingCart");

        }
        //
        // GET: /ShoppingCart/CartSummary








        //public JavaScriptResult EmptyCart()
        //{
        //    var cartItem = db.Carts.FirstOrDefault(cart => cart.Id == id);

        //    db.Carts.Remove(cartItem);


        //    // Save changes
        //    db.SaveChanges();
        //    return JsonResult()
        //}




        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewBag.Count = cart.GetCount();
            ViewBag.Model = (ShoppingCartViewModel)Session["CartItems"];
            return PartialView("CartSummary");
        }
        public ActionResult RegisterMe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterMe(Customer subscriber)
        {
            subscriber.UserId = User.Identity.Name;
            subscriber.DateRegistered = DateTime.Now;
       
            string zeroCheck = subscriber.ContactNo.Trim().Substring(0);
            db.Customers.Add(subscriber);
            if (db.SaveChanges() > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Products()
        {
      
          List<Stock>  lstStocks = new List<Stock>();

            var collection = db.Stocks.OrderByDescending(s => s.Id).ToList();
            Customer user = db.Customers.FirstOrDefault(d => d.UserId == User.Identity.Name);
            var transactions = db.Transactions.Where(d => d.CustomerId == user.Id && d.Sms=="PENDING").ToList().Distinct();
            List<Stock> stocks = new List<Stock>();
            int g = 0;
            foreach (var t in transactions.OrderByDescending(s => s.CartId))
            {
                if (t.Id != g)
                {
                    Stock p = db.Stocks.Find(t.Id);
                    stocks.Add(p);
                
                }
            }

            lstStocks = stocks.OrderByDescending(s => s.Id).ToList();
         

        


            return View(lstStocks);

        }
        //shopping cart items 
        [HttpPost]

        // GET: ShoppingCart/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
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
