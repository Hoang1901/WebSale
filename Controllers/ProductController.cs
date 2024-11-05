using Microsoft.AspNetCore.Mvc;
using WebPhone.Models;
using WebPhone.Extensions;  // Đảm bảo bạn đã thêm namespace Extensions

public class ProductController : Controller
{
    // Giả lập dữ liệu sản phẩm (có thể thay thế bằng việc lấy từ CSDL)
    private static List<Product> GetProducts()
    {
        return new List<Product>
        {
            new Product { Id = 1, Name = "iPhone 15", Price = 999.99m, Description = "Smartphone with powerful features", ImageUrl = "/images/iphone15.jpg" },
            new Product { Id = 2, Name = "Samsung Galaxy S22", Price = 899.99m, Description = "Flagship Android smartphone", ImageUrl = "/images/samsunggalaxys22.jpg" },
            new Product { Id = 3, Name = "MacBook Pro 16", Price = 2399.99m, Description = "Laptop for professionals", ImageUrl = "/images/macbookpro16.jpg" },
            new Product { Id = 4, Name = "Dell XPS 13", Price = 1299.99m, Description = "Compact and powerful laptop", ImageUrl = "/images/dellxps13.jpg" }
        };
    }

    // Hiển thị danh sách sản phẩm
    public IActionResult Index()
    {
        var products = GetProducts();
        return View(products);
    }

    // Thêm sản phẩm vào giỏ hàng
    public IActionResult AddToCart(int productId)
    {
        var product = GetProducts().FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
            if (cart == null)
            {
                cart = new Cart();
            }
            cart.AddToCart(product);
            HttpContext.Session.SetObjectAsJson("Cart", cart);
        }
        return RedirectToAction("Index", "Product");
    }
}
