document.addEventListener("DOMContentLoaded", function () {
    const addToCartButtons = document.querySelectorAll('.add-to-cart-btn');

    addToCartButtons.forEach(button => {
        button.addEventListener('click', function (e) {
            const productId = e.target.getAttribute('data-product-id');
            const quantity = 1;  // Giả sử số lượng mặc định là 1

            // Gửi yêu cầu Ajax để thêm sản phẩm vào giỏ hàng
            fetch('/Cart/AddToCart', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ productId, quantity })
            })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    // Cập nhật UI giỏ hàng
                    alert('Product added to cart!');
                    updateCartIcon(data.cartItemCount); // Cập nhật số lượng sản phẩm trong giỏ hàng
                } else {
                    alert('Failed to add product to cart.');
                }
            })
            .catch(error => {
                console.error('Error:', error);
            });
        });
    });

    // Hàm cập nhật số lượng giỏ hàng trên icon (hoặc trên menu)
    function updateCartIcon(cartItemCount) {
        const cartIcon = document.querySelector('#cart-icon');
        if (cartIcon) {
            cartIcon.textContent = cartItemCount;  // Giả sử bạn có một thẻ chứa số lượng sản phẩm trong giỏ
        }
    }
});
