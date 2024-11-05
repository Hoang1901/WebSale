namespace WebPhone.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        // Thêm sản phẩm vào giỏ hàng
        public void AddToCart(Product product)
        {
            var cartItem = Items.FirstOrDefault(i => i.ProductId == product.Id);
            if (cartItem == null)
            {
                Items.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = 1
                });
            }
            else
            {
                cartItem.Quantity++;
            }
        }

        // Xóa sản phẩm khỏi giỏ hàng
        public void RemoveFromCart(int productId)
        {
            var cartItem = Items.FirstOrDefault(i => i.ProductId == productId);
            if (cartItem != null)
            {
                Items.Remove(cartItem);
            }
        }

        // Tính tổng tiền của giỏ hàng
        public decimal GetTotal()
        {
            return Items.Sum(item => item.Total);
        }
    }
}
