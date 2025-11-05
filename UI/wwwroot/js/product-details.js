// Product Details Page JavaScript

// Initialize Product Details Page
document.addEventListener('DOMContentLoaded', function() {
    setupProductDetailsEvents();
});

// Setup Event Listeners
function setupProductDetailsEvents() {
    // Quantity controls
    const quantityInput = document.getElementById('quantity');
    const stock = parseInt(document.getElementById('Stock').value);
    if (quantityInput) {
        quantityInput.addEventListener('change', function() {
            if (this.value < 1) this.value = 1;
            if (this.value > stock) this.value = stock;
        });
    }
}

// Quantity Controls
function decreaseQuantity() {
    const quantityInput = document.getElementById('quantity');
    if (quantityInput.value > 1) {
        quantityInput.value = parseInt(quantityInput.value) - 1;
    }
}

function increaseQuantity() {
    const stock = parseInt(document.getElementById('Stock').value);
    const quantityInput = document.getElementById('quantity');
    if (quantityInput.value < stock) {
        quantityInput.value = parseInt(quantityInput.value) + 1;
    }
}

// Add to Cart from Details Page
function addToCartFromDetails(productId) {
    const quantity = parseInt(document.getElementById('quantity').value);
    addToCart(productId, quantity);
}