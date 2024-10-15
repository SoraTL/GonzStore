using GenZStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenZStore.Controllers
{
    public class CartController : Controller
    {
        private GonzStoreDbContext _context = GonzStoreDbContext.GenInstance();

        // GET: Cart
        public ActionResult Index()
        {
            string userId = Session["UserId"] as string;
            Cart cart;

            if (!string.IsNullOrEmpty(userId))
            {
                cart = _context.carts
                    .Include(c => c.CartItems.Select(ci => ci.Product))
                    .FirstOrDefault(c => c.UserId == userId);

                if (cart == null)
                {
                    cart = new Cart { UserId = userId };
                    _context.carts.Add(cart);
                    _context.SaveChanges();
                }
            }
            else
            {
                string guestId = Session["GuestId"] as string;

                if (string.IsNullOrEmpty(guestId))
                {
                    guestId = Guid.NewGuid().ToString(); 
                    Session["GuestId"] = guestId;
                }

                //cart = _context.carts
                //    .Include(c => c.CartItems.Select(ci => ci.Product))
                //    .FirstOrDefault(c => c.UserId == guestId);
                cart = _context.carts.FirstOrDefault(c => c.CartId==1);


                // Nếu giỏ hàng của guest không tồn tại, tạo mới
                if (cart == null)
                {
                    cart = new Cart { UserId = guestId };
                    _context.carts.Add(cart);
                    _context.SaveChanges();
                }
            }

            return View(cart); // Trả về đối tượng Cart
        }


        // POST: Cart/AddToCart
        [HttpPost]
        public ActionResult AddToCart(int productId)
        {
            string userId = Session["UserId"] as string; // Lấy UserId từ Session

            if (string.IsNullOrEmpty(userId))
            {
                // Nếu UserId không có trong session, chuyển đến trang login hoặc xử lý theo cách khác
                return RedirectToAction("Login", "Account");
            }

            var cart = _context.carts
                .Include(c => c.CartItems)
                .FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _context.carts.Add(cart);
                _context.SaveChanges();
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem == null)
            {
                cartItem = new CartItem { ProductId = productId, Quantity = 1, CartId = cart.CartId };
                _context.cartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += 1;
                _context.Entry(cartItem).State = EntityState.Modified;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: Cart/UpdateQuantity
        [HttpPost]
        public ActionResult UpdateQuantity(int cartItemId, int quantity)
        {
            var cartItem = _context.cartItems.Find(cartItemId);
            if (cartItem != null && quantity > 0)
            {
                cartItem.Quantity = quantity;
                _context.Entry(cartItem).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // POST: Cart/RemoveFromCart
        [HttpPost]
        public ActionResult RemoveFromCart(int cartItemId)
        {
            var cartItem = _context.cartItems.Find(cartItemId);
            if (cartItem != null)
            {
                _context.cartItems.Remove(cartItem);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
