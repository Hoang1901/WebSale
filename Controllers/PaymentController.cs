using Microsoft.AspNetCore.Mvc;
using WebPhone.Models;
using WebPhone.Extensions;

public class PaymentController : Controller
{
    // GET: /Payment/Checkout
    public IActionResult Checkout()
    {
        // Giả sử giỏ hàng được lưu trữ trong session
        var cart = GetCartFromSession();

        if (cart == null || cart.Items.Count == 0)
        {
            return RedirectToAction("Index", "Product"); // Nếu giỏ hàng trống, quay lại trang sản phẩm
        }

        // Tính tổng tiền của giỏ hàng
        decimal totalAmount = 0;
        foreach (var item in cart.Items)
        {
            totalAmount += item.Total; // Giả sử mỗi item có trường "Total"
        }

        // Trả về trang thanh toán với thông tin tổng tiền
        var paymentInfo = new PaymentInfo
        {
            TotalAmount = totalAmount
        };

        return View(paymentInfo);
    }

    // POST: /Payment/ProcessPayment
    [HttpPost]
    public IActionResult ProcessPayment(PaymentInfo paymentInfo)
    {
        if (ModelState.IsValid)
        {
            // Giả lập xử lý thanh toán (thực tế sẽ gọi API của cổng thanh toán như Stripe, PayPal, v.v.)
            // Ví dụ: Gọi dịch vụ thanh toán để xử lý

            // Giả sử thanh toán thành công
            ProcessSuccessfulPayment();

            // Sau khi thanh toán thành công, bạn có thể làm sạch giỏ hàng và lưu đơn hàng.
            ClearCart();

            // Điều hướng đến trang "Thanh toán thành công"
            return RedirectToAction("PaymentSuccess");
        }

        // Nếu thông tin thanh toán không hợp lệ, quay lại trang thanh toán
        return View("Checkout", paymentInfo);
    }

    // GET: /Payment/PaymentSuccess
    public IActionResult PaymentSuccess()
    {
        return View();
    }

    // Giả lập lấy giỏ hàng từ Session
    private Cart GetCartFromSession()
    {
        var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
        return cart;
    }

    // Giả lập quá trình thanh toán thành công
    private void ProcessSuccessfulPayment()
    {
        // Bạn có thể lưu thông tin đơn hàng vào cơ sở dữ liệu
        // hoặc thực hiện các hành động sau khi thanh toán thành công.
    }

    // Giả lập xóa giỏ hàng sau khi thanh toán
    private void ClearCart()
    {
        HttpContext.Session.Remove("Cart");
    }
}
