// Products Page JavaScript - ASP.NET MVC Integration

let currentView = 'grid';
let currentPage = 1;
let searchTimeout = null;
let isLoading = false;
let filterTimeout = null;
// Initialize Products Page
document.addEventListener('DOMContentLoaded', function() {
    setupEventListeners();
    initializeFromRazorData();
});

// Initialize from Razor ViewModel data
function initializeFromRazorData() {
    // Get initial state from Razor-rendered elements
    const searchInput = document.getElementById('search-input');
    const sortOptions = document.getElementById('sort-options');
    
    // Set initial values from ViewModel
    if (searchInput && searchInput.dataset.initialValue) {
        searchInput.value = searchInput.dataset.initialValue;
    }
    
    if (sortOptions && sortOptions.dataset.initialValue) {
        sortOptions.value = sortOptions.dataset.initialValue;
    }
}

// Setup Event Listeners for Live Search/Filtering
function setupEventListeners() {
    // View Toggle
    document.getElementById('grid-view')?.addEventListener('click', () => switchView('grid'));
    document.getElementById('list-view')?.addEventListener('click', () => switchView('list'));
    
    // Live Search with Debouncing
    const searchInput = document.getElementById('search-input');
    if (searchInput) {
        searchInput.addEventListener('input', function() {
            clearTimeout(searchTimeout);
            showSearchLoading(true);
            
            searchTimeout = setTimeout(() => {
                currentPage = 1;
                submitFilterForm();
                showSearchLoading(false);
            }, 500);
        });
    }
    
    // Live Filtering - Category
    document.querySelectorAll('.category-filter').forEach(radio => {
        radio.addEventListener('change', function() {
            currentPage = 1;
            submitFilterForm();
        });
    });
    
    // Live Filtering - Price Range
    const minPrice = document.getElementById('min-price');
    const maxPrice = document.getElementById('max-price');
    
    if (minPrice) {
        minPrice.addEventListener('input', function() {
            clearTimeout(filterTimeout);
            updatePriceValues();

            filterTimeout = setTimeout(() => {
                currentPage = 1;
                submitFilterForm();
            }, 500);
        });
    }
    
    if (maxPrice) {
        maxPrice.addEventListener('input', function() {
            clearTimeout(filterTimeout);
            updatePriceValues();


            filterTimeout = setTimeout(() => {
               
                currentPage = 1;
                submitFilterForm();
            }, 500);


        });
    }
    
    // Live Sorting
    const sortOptions = document.getElementById('sort-options');
    if (sortOptions) {
        sortOptions.addEventListener('change', function() {
            currentPage = 1;
            submitFilterForm();
        });
    }
    
    // Reset Filters
    document.getElementById('reset-filters')?.addEventListener('click', resetFilters);
    
    // Quick filter chips
    setupQuickFilters();
}

// Submit Filter Form via AJAX to MVC Controller
async function submitFilterForm() {
    if (isLoading) return;
    
    isLoading = true;
    showLoadingState(true);
    
    try {
        const formData = getFilterFormData();
        
        //// Get anti-forgery token from Razor
        //const token = document.querySelector('input[name="__RequestVerificationToken"]')?.value;
        //if (token) {
        //    formData.append('__RequestVerificationToken', token);
        //}
        
        const response = await fetch('Products/Index', {
            method: 'POST',
            headers: {
                'X-Requested-With': 'XMLHttpRequest',
                'Accept': 'text/html'
            },
            body: formData
        });
        
        if (response.ok) {
            const html = await response.text();
            updateProductsPartialView(html);
        } else {
            throw new Error('Server response was not ok');
        }
    } catch (error) {
        console.error('Error filtering products:', error);
        const text = await response.text();
        console.error('Server response:', text);

        showError('Error loading products. Please try again.');
    } finally {
        isLoading = false;
        showLoadingState(false);
    }
}

// Get Form Data from Current Filter State
function getFilterFormData() {
    const formData = new FormData();
    
    // Get values from form elements
    const searchTerm = document.getElementById('search-input')?.value.trim() || '';
    const selectedCategory = document.querySelector('input[name="category"]:checked')?.value || 'all';
    const minPrice = document.getElementById('min-price')?.value || '0';
    const maxPrice = document.getElementById('max-price')?.value || '10000000';
    const sortOption = document.getElementById('sort-options')?.value || '';
    
    // Match these names to your ViewModel properties
    formData.append('SearchTerm', searchTerm);
    formData.append('Category', selectedCategory);
    formData.append('MinPrice', minPrice);
    formData.append('MaxPrice', maxPrice);
    formData.append('SortBy', sortOption);
    formData.append('Page', currentPage.toString());
    //formData.append('ViewType', currentView);
    
    return formData;
}

// Update Products Partial View with Server Response
function updateProductsPartialView(html) {
    const parser = new DOMParser();
    const doc = parser.parseFromString(html, 'text/html');
    
    // Update products grid
    const newProductsGrid = doc.getElementById('products-grid');
    if (newProductsGrid) {
        document.getElementById('products-grid').innerHTML = newProductsGrid.innerHTML;
    }
    
    // Update pagination
    const newPagination = doc.getElementById('pagination');
    if (newPagination) {
        document.getElementById('pagination').innerHTML = newPagination.innerHTML;
    }
    
    // Update results count
    const newResultsCount = doc.getElementById('results-count');
    if (newResultsCount) {
        document.getElementById('results-count').innerHTML = newResultsCount.innerHTML;
    }
    
    // Update browser URL for AJAX navigation
    //updateBrowserURL();
}

// Update Browser URL without reload
//function updateBrowserURL() {
//    const params = new URLSearchParams();
//    const formData = getFilterFormData();
    
//    for (const [key, value] of formData.entries()) {
//        if (value && key !== '__RequestVerificationToken' && key !== 'ViewType') {
//            params.append(key, value);
//        }
//    }
    
//    const newUrl = `${window.location.pathname}?${params.toString()}`;
//    window.history.replaceState({}, '', newUrl);
//}

// Setup Quick Filters
//function setupQuickFilters() {
//    document.querySelectorAll('.filter-chip').forEach(chip => {
//        chip.addEventListener('click', function() {
//            const category = this.dataset.category;
//            document.querySelector(`input[value="${category}"]`).checked = true;
//            currentPage = 1;
//            submitFilterForm();
//        });
//    });
//}

// Show/Hide Loading States
function showLoadingState(show) {
    const productsGrid = document.getElementById('products-grid');
    
    if (show) {
        productsGrid.innerHTML = `
            <div class="col-12 text-center py-5">
                <div class="spinner-border text-primary mb-3" role="status">
                    <span class="visually-hidden">Loading...</span>
                </div>
                <p>Loading products...</p>
            </div>
        `;
    }
}

function showSearchLoading(show) {
    let loadingIndicator = document.getElementById('search-loading');
    
    if (show && !loadingIndicator) {
        loadingIndicator = document.createElement('div');
        loadingIndicator.id = 'search-loading';
        loadingIndicator.className = 'position-absolute top-50 translate-middle-y me-5';
        loadingIndicator.style.right = '50px';
        loadingIndicator.innerHTML = '<div class="spinner-border spinner-border-sm text-primary" role="status"></div>';
        
        const searchContainer = document.getElementById('search-input').parentElement;
        searchContainer.style.position = 'relative';
        searchContainer.appendChild(loadingIndicator);
    } else if (!show && loadingIndicator) {
        loadingIndicator.remove();
    }
}

// Reset Filters
function resetFilters() {
    document.querySelector('input[value="all"]').checked = true;
    document.getElementById('search-input').value = '';
    document.getElementById('sort-options').value = '';
    document.getElementById('min-price').value = 0;
    document.getElementById('max-price').value = 1000000000;
    
    updatePriceValues();
    //currentPage = 1;
    submitFilterForm();
    
    showFilterToast('Filters reset successfully');
}

// Update Price Values Display
function updatePriceValues() {
    const minPriceValue = document.getElementById('min-price-value');
    const maxPriceValue = document.getElementById('max-price-value');
    const minPrice = document.getElementById('min-price');
    const maxPrice = document.getElementById('max-price');
    
    if (minPriceValue && minPrice) {
        minPriceValue.textContent = minPrice.value;
    }
    
    if (maxPriceValue && maxPrice) {
        maxPriceValue.textContent = maxPrice.value;
    }
}

// Change Page
function changePage(page) {
    currentPage = page;
    submitFilterForm();
}

// Switch View
function switchView(view) {
    currentView = view;
    
    // Update active button
    document.getElementById('grid-view').classList.toggle('active', view === 'grid');
    document.getElementById('list-view').classList.toggle('active', view === 'list');
    
    // Update view type and resubmit
    submitFilterForm();
}

// Show Toast Messages
function showFilterToast(message) {
    const toast = document.createElement('div');
    toast.className = 'position-fixed top-0 start-50 translate-middle-x mt-3 alert alert-success alert-dismissible fade show';
    toast.style.zIndex = '1060';
    toast.innerHTML = `
        ${message}
        <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
    `;
    
    document.body.appendChild(toast);
    
    setTimeout(() => {
        toast.remove();
    }, 3000);
}

function showError(message) {
    const toast = document.createElement('div');
    toast.className = 'position-fixed top-0 start-50 translate-middle-x mt-3 alert alert-danger alert-dismissible fade show';
    toast.style.zIndex = '1060';
    toast.innerHTML = `
        ${message}
        <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
    `;
    
    document.body.appendChild(toast);
    
    setTimeout(() => {
        toast.remove();
    }, 5000);
}