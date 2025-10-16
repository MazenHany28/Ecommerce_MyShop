// Cart Management JavaScript - MVC Integration

// Remove from Cart
function removeFromCart(productId) {
    if (!confirm('Are you sure you want to remove this item from your cart?')) {
        return;
    }
    
    const formData = new FormData();
    formData.append('productId', productId);
    
    const token = document.querySelector('input[name="__RequestVerificationToken"]')?.value;
    if (token) {
        formData.append('__RequestVerificationToken', token);
    }
    
    fetch('/Cart/RemoveFromCart', {
        method: 'POST',
        headers: {
            'X-Requested-With': 'XMLHttpRequest'
        },
        body: formData
    })
    .then(response => {
        if (response.ok) {
            location.reload(); // Reload to update cart page
        } else {
            throw new Error('Network response was not ok');
        }
    })
    .catch(error => {
        console.error('Error removing from cart:', error);
        showToast('Error removing item from cart', 'error');
    });
}

// Update Cart Quantity
function updateCartQuantity(productId, quantity) {
    if (quantity < 1) quantity = 1;
    if (quantity > 10) {
        quantity = 10;
        showToast('Maximum quantity per item is 10', 'warning');
    }
    
    const formData = new FormData();
    formData.append('productId', productId);
    formData.append('quantity', quantity);
    
    const token = document.querySelector('input[name="__RequestVerificationToken"]')?.value;
    if (token) {
        formData.append('__RequestVerificationToken', token);
    }
    
    fetch('/Cart/UpdateCart', {
        method: 'POST',
        headers: {
            'X-Requested-With': 'XMLHttpRequest'
        },
        body: formData
    })
    .then(response => {
        if (response.ok) {
            location.reload(); // Reload to update cart totals
        } else {
            throw new Error('Network response was not ok');
        }
    })
    .catch(error => {
        console.error('Error updating cart:', error);
        showToast('Error updating cart quantity', 'error');
    });
}

// Show Toast Messages
function showToast(message, type = 'info') {
    const toast = document.createElement('div');
    toast.className = `toast align-items-center text-bg-${type === 'error' ? 'danger' : type} border-0`;
    toast.setAttribute('role', 'alert');
    toast.innerHTML = `
        <div class="d-flex">
            <div class="toast-body">
                <i class="fas fa-${getToastIcon(type)} me-2"></i>${message}
            </div>
            <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast"></button>
        </div>
    `;
    
    const toastContainer = document.querySelector('.toast-container') || createToastContainer();
    toastContainer.appendChild(toast);
    
    const bsToast = new bootstrap.Toast(toast);
    bsToast.show();
    
    toast.addEventListener('hidden.bs.toast', () => {
        toast.remove();
    });
}

function createToastContainer() {
    const container = document.createElement('div');
    container.className = 'toast-container position-fixed top-0 end-0 p-3';
    document.body.appendChild(container);
    return container;
}

function getToastIcon(type) {
    const icons = {
        success: 'check-circle',
        error: 'exclamation-circle',
        warning: 'exclamation-triangle',
        info: 'info-circle'
    };
    return icons[type] || 'info-circle';
}