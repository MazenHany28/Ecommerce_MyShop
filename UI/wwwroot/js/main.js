// Main JavaScript for MyShop E-commerce

// Cart Management
class CartManager {
    constructor() {
        this.updateCartCount();
    }

    async addToCart(productId, quantity = 1) {
        try {
            const formData = new FormData();
            formData.append('productId', productId);
            formData.append('quantity', quantity);
            
            // Get anti-forgery token
            //const token = document.querySelector('input[name="__RequestVerificationToken"]')?.value;
            //if (token) {
            //    formData.append('__RequestVerificationToken', token);
            //}

            const token = document.querySelector('meta[name="x-xsrf-token"]')?.getAttribute('content');
            if (token) formData.append('__RequestVerificationToken', token);

            
            const response = await fetch('/Cart/AddToCart', {
                method: 'POST',
                headers: {
                    'X-Requested-With': 'XMLHttpRequest'
                },
                body: formData
            });


            if (response.status === 401) {

                window.location.href = '/Identity/Account/Login';
                return; 
            }
            
            if (response.ok) {
                const data = await response.json();
                if (data.success) {
                    this.updateCartCount(data.cartCount);
                    this.showAddToCartToast(data.productName, quantity);
                } else {
                    this.showToast(data.message || 'Failed to add product to cart', 'error');
                }
            } else {
                throw new Error('Network response was not ok');
            }
        } catch (error) {
            console.error('Error adding to cart:', error);
            this.showToast('Error adding product to cart', 'error');
        }
    }

    async updateCartCount() {
        try {
            const response = await fetch('/Cart/GetCartCount');
            if (response.ok) {
                const data = await response.json();
                const cartCountElements = document.querySelectorAll('#cart-count');
                cartCountElements.forEach(element => {
                    element.textContent = data.cartCount;
                });
            }
        } catch (error) {
            console.error('Error updating cart count:', error);
        }
    }

    showAddToCartToast(productName, quantity) {
        this.showToast(`Added ${quantity} ${quantity > 1 ? 'items' : 'item'} of ${productName} to cart`, 'success');
    }

    showToast(message, type = 'info') {
        const toast = document.createElement('div');
        toast.className = `toast align-items-center text-bg-${type === 'error' ? 'danger' : type} border-0`;
        toast.setAttribute('role', 'alert');
        toast.innerHTML = `
            <div class="d-flex">
                <div class="toast-body">
                    <i class="fas fa-${this.getToastIcon(type)} me-2"></i>${message}
                </div>
                <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast"></button>
            </div>
        `;
        
        const toastContainer = document.querySelector('.toast-container') || this.createToastContainer();
        toastContainer.appendChild(toast);
        
        const bsToast = new bootstrap.Toast(toast);
        bsToast.show();
        
        toast.addEventListener('hidden.bs.toast', () => {
            toast.remove();
        });
    }

    createToastContainer() {
        const container = document.createElement('div');
        container.className = 'toast-container position-fixed top-0 end-0 p-3';
        document.body.appendChild(container);
        return container;
    }

    getToastIcon(type) {
        const icons = {
            success: 'check-circle',
            error: 'exclamation-circle',
            warning: 'exclamation-triangle',
            info: 'info-circle'
        };
        return icons[type] || 'info-circle';
    }
}

// Initialize Cart Manager
const cartManager = new CartManager();

// Global addToCart function
function addToCart(productId, quantity = 1) {
    cartManager.addToCart(productId, quantity);
}




// Star Rating Generator
//function generateStarRating(rating) {
//    let stars = '';
//    const fullStars = Math.floor(rating);
//    const hasHalfStar = rating % 1 !== 0;
    
//    for (let i = 0; i < fullStars; i++) {
//        stars += '<i class="fas fa-star"></i>';
//    }
    
//    if (hasHalfStar) {
//        stars += '<i class="fas fa-star-half-alt"></i>';
//    }
    
//    const emptyStars = 5 - Math.ceil(rating);
//    for (let i = 0; i < emptyStars; i++) {
//        stars += '<i class="far fa-star"></i>';
//    }
    
//    return stars;
//}

// Initialize when DOM is loaded


document.addEventListener('DOMContentLoaded', function () {
    // Initialize tooltips
    const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    const tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
    
    // Update cart count on page load
    cartManager.updateCartCount();
});