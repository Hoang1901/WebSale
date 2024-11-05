using Microsoft.AspNetCore.Mvc;
using WebPhone.Models;
using WebPhone.Extensions;  // Đảm bảo bạn đã thêm namespace Extensions

public class CartController : Controller
{
    // Xem giỏ hàng
    public IActionResult Index()
    {
        var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
        if (cart == null)
        {
            cart = new Cart();
        }
        return View(cart);
    }

    // Xóa sản phẩm khỏi giỏ hàng
    public IActionResult RemoveFromCart(int productId)
    {
        var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
        if (cart != null)
        {
            cart.RemoveFromCart(productId);
            HttpContext.Session.SetObjectAsJson("Cart", cart);
        }
        return RedirectToAction("Index");
    }
}
