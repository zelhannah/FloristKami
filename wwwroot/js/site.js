// ===========================
// FLORIST KAMI - MAIN SCRIPT
// Complete & Optimized
// ===========================

// ===== GLOBAL STATE =====
let favorites = JSON.parse(localStorage.getItem('favorites')) || [];
let currentCategory = 'all';
let currentSearchTerm = '';

// ===== FAVORITES MANAGEMENT =====

/**
 * Update favorite count badge in navbar
 * Supports multiple badge IDs for flexibility
 */
function updateFavoriteCount() {
    const countElements = [
        document.getElementById('favoriteCount'),
        document.getElementById('favCount')
    ];
    
    countElements.forEach(countElement => {
        if (countElement) {
            if (favorites.length > 0) {
                countElement.textContent = favorites.length;
                countElement.classList.remove('hidden');
                countElement.classList.add('flex');
            } else {
                countElement.classList.add('hidden');
                countElement.classList.remove('flex');
            }
        }
    });
    
    // Update all heart icons
    updateHeartIcons();
}

/**
 * Update visual state of all favorite heart icons
 */
function updateHeartIcons() {
    document.querySelectorAll('.favorite-toggle').forEach(button => {
        const productId = button.dataset.id;
        const icon = button.querySelector('.heart-icon');
        
        if (icon) {
            if (favorites.includes(productId)) {
                // Favorited state - filled heart
                icon.classList.remove('text-stone-400');
                icon.classList.add('text-rose-600');
                icon.setAttribute('fill', 'currentColor');
                icon.setAttribute('stroke-width', '0');
            } else {
                // Not favorited state - outline heart
                icon.classList.remove('text-rose-600');
                icon.classList.add('text-stone-400');
                icon.setAttribute('fill', 'none');
                icon.setAttribute('stroke-width', '2');
            }
        }
    });
}

/**
 * Toggle favorite status for a product
 * @param {string} productId - The product ID to toggle
 */
function toggleFavorite(productId) {
    if (favorites.includes(productId)) {
        // Remove from favorites
        favorites = favorites.filter(id => id !== productId);
        showToast('Dihapus dari favorit', 'error');
    } else {
        // Add to favorites
        favorites.push(productId);
        showToast('Ditambahkan ke favorit', 'success');
    }
    
    // Save to localStorage
    localStorage.setItem('favorites', JSON.stringify(favorites));
    
    // Update UI
    updateFavoriteCount();
}

// ===== TOAST NOTIFICATION SYSTEM =====

/**
 * Show toast notification with message
 * @param {string} message - Message to display
 * @param {string} type - 'success' or 'error'
 */
function showToast(message, type = 'success') {
    // Remove existing toasts
    document.querySelectorAll('.toast-notification').forEach(t => t.remove());
    
    const toast = document.createElement('div');
    toast.className = `toast-notification fixed bottom-6 right-6 px-6 py-4 rounded-2xl shadow-2xl text-white z-50 transform transition-all duration-300 ${
        type === 'success' 
            ? 'bg-gradient-to-r from-green-500 to-emerald-500' 
            : 'bg-gradient-to-r from-red-500 to-pink-500'
    }`;
    
    toast.innerHTML = `
        <div class="flex items-center space-x-3">
            ${type === 'success' 
                ? `<svg class="w-6 h-6" fill="currentColor" viewBox="0 0 20 20">
                    <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.707-9.293a1 1 0 00-1.414-1.414L9 10.586 7.707 9.293a1 1 0 00-1.414 1.414l2 2a1 1 0 001.414 0l4-4z" clip-rule="evenodd"/>
                   </svg>`
                : `<svg class="w-6 h-6" fill="currentColor" viewBox="0 0 20 20">
                    <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM8.707 7.293a1 1 0 00-1.414 1.414L8.586 10l-1.293 1.293a1 1 0 101.414 1.414L10 11.414l1.293 1.293a1 1 0 001.414-1.414L11.414 10l1.293-1.293a1 1 0 00-1.414-1.414L10 8.586 8.707 7.293z" clip-rule="evenodd"/>
                   </svg>`
            }
            <span class="font-semibold">${message}</span>
        </div>
    `;
    
    document.body.appendChild(toast);
    
    // Animate in
    setTimeout(() => {
        toast.style.opacity = '1';
        toast.style.transform = 'translateY(0)';
    }, 10);
    
    // Remove after 3 seconds
    setTimeout(() => {
        toast.style.opacity = '0';
        toast.style.transform = 'translateY(1rem)';
        setTimeout(() => toast.remove(), 300);
    }, 3000);
}

// ===== PRODUCT FILTERING SYSTEM =====

/**
 * Filter products based on category and search term
 */
function filterProducts() {
    const searchInput = document.getElementById('searchInput');
    currentSearchTerm = searchInput ? searchInput.value.toLowerCase() : '';
    
    const productsGrid = document.getElementById('productsGrid');
    const specialEditionSection = document.getElementById('specialEditionSection');
    const emptyState = document.getElementById('emptyState');
    
    // Handle special edition category with carousel
    if (currentCategory === 'specialedition') {
        if (productsGrid) productsGrid.style.display = 'none';
        if (specialEditionSection) specialEditionSection.classList.remove('hidden');
        if (emptyState) emptyState.classList.add('hidden');
        return;
    }
    
    // Show regular products grid
    if (productsGrid) productsGrid.style.display = 'grid';
    if (specialEditionSection) specialEditionSection.classList.add('hidden');
    
    // Filter products
    let visibleCount = 0;
    document.querySelectorAll('.product-card').forEach(card => {
        const category = card.dataset.category;
        const name = card.dataset.name || '';
        const description = card.dataset.description || '';
        
        const matchesCategory = currentCategory === 'all' || category === currentCategory;
        const matchesSearch = currentSearchTerm === '' || 
                             name.includes(currentSearchTerm) || 
                             description.includes(currentSearchTerm);
        
        if (matchesCategory && matchesSearch) {
            card.style.display = 'block';
            card.classList.remove('hidden');
            visibleCount++;
        } else {
            card.style.display = 'none';
            card.classList.add('hidden');
        }
    });
    
    // Show/hide empty state
    if (emptyState) {
        if (visibleCount === 0) {
            emptyState.classList.remove('hidden');
        } else {
            emptyState.classList.add('hidden');
        }
    }
}

/**
 * Reset all filters to default state
 */
function resetFilters() {
    const searchInput = document.getElementById('searchInput');
    if (searchInput) searchInput.value = '';
    
    currentCategory = 'all';
    currentSearchTerm = '';
    
    // Reset category buttons styling
    const categoryButtons = document.querySelectorAll('.category-btn');
    categoryButtons.forEach((btn, index) => {
        btn.classList.remove('bg-gradient-to-r', 'from-rose-500', 'to-pink-500', 'text-white', 'shadow-lg', 'scale-105');
        btn.classList.add('bg-white', 'text-stone-700', 'border-2', 'border-rose-200');
        
        // Set first button (All Products) as active
        if (index === 0) {
            btn.classList.remove('bg-white', 'text-stone-700', 'border-2', 'border-rose-200');
            btn.classList.add('bg-gradient-to-r', 'from-rose-500', 'to-pink-500', 'text-white', 'shadow-lg', 'scale-105');
        }
    });
    
    filterProducts();
}

// ===== MOBILE MENU MANAGEMENT =====

/**
 * Initialize mobile menu toggle functionality
 */
function initMobileMenu() {
    const mobileMenuBtn = document.getElementById('mobileMenuBtn');
    const mobileMenu = document.getElementById('mobileMenu');
    
    if (mobileMenuBtn && mobileMenu) {
        mobileMenuBtn.addEventListener('click', (e) => {
            e.stopPropagation();
            mobileMenu.classList.toggle('hidden');
        });
        
        // Close mobile menu when clicking outside
        document.addEventListener('click', (e) => {
            if (!mobileMenuBtn.contains(e.target) && !mobileMenu.contains(e.target)) {
                mobileMenu.classList.add('hidden');
            }
        });
        
        // Close menu when clicking menu items
        mobileMenu.querySelectorAll('a').forEach(link => {
            link.addEventListener('click', () => {
                mobileMenu.classList.add('hidden');
            });
        });
    }
}

// ===== SMOOTH SCROLL FOR ANCHOR LINKS =====

/**
 * Add smooth scroll behavior to anchor links
 */
function initSmoothScroll() {
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            const targetId = this.getAttribute('href');
            if (targetId === '#') return;
            
            const targetElement = document.querySelector(targetId);
            if (targetElement) {
                e.preventDefault();
                targetElement.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        });
    });
}

// ===== LAZY LOAD IMAGES =====

/**
 * Lazy load images for better performance
 */
function initLazyLoad() {
    const images = document.querySelectorAll('img[data-src]');
    
    if ('IntersectionObserver' in window) {
        const imageObserver = new IntersectionObserver((entries, observer) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    const img = entry.target;
                    img.src = img.dataset.src;
                    img.removeAttribute('data-src');
                    imageObserver.unobserve(img);
                }
            });
        });
        
        images.forEach(img => imageObserver.observe(img));
    } else {
        // Fallback for older browsers
        images.forEach(img => {
            img.src = img.dataset.src;
            img.removeAttribute('data-src');
        });
    }
}

// ===== EVENT LISTENERS INITIALIZATION =====

/**
 * Initialize all event listeners when DOM is ready
 */
document.addEventListener('DOMContentLoaded', function() {
    console.log('FloristKami initialized');
    
    // Initialize favorites display
    updateFavoriteCount();
    
    // Initialize mobile menu
    initMobileMenu();
    
    // Initialize smooth scroll
    initSmoothScroll();
    
    // Initialize lazy load
    initLazyLoad();
    
    // ===== FAVORITE TOGGLE BUTTONS =====
    document.querySelectorAll('.favorite-toggle').forEach(button => {
        button.addEventListener('click', function(e) {
            e.preventDefault();
            e.stopPropagation();
            
            const productId = this.dataset.id;
            toggleFavorite(productId);
        });
    });
    
    // ===== CATEGORY FILTER BUTTONS =====
    document.querySelectorAll('.category-btn').forEach(button => {
        button.addEventListener('click', function() {
            const category = this.dataset.category;
            currentCategory = category;
            
            // Update active button styling
            document.querySelectorAll('.category-btn').forEach(btn => {
                btn.classList.remove('bg-gradient-to-r', 'from-rose-500', 'to-pink-500', 'text-white', 'shadow-lg', 'scale-105');
                btn.classList.add('bg-white', 'text-stone-700', 'border-2', 'border-rose-200');
            });
            
            this.classList.remove('bg-white', 'text-stone-700', 'border-2', 'border-rose-200');
            this.classList.add('bg-gradient-to-r', 'from-rose-500', 'to-pink-500', 'text-white', 'shadow-lg', 'scale-105');
            
            // Apply filter
            filterProducts();
            
            // Scroll to products section
            const productsSection = document.getElementById('products');
            if (productsSection) {
                productsSection.scrollIntoView({ behavior: 'smooth', block: 'start' });
            }
        });
    });
    
    // ===== SEARCH INPUT =====
    const searchInput = document.getElementById('searchInput');
    if (searchInput) {
        // Debounce search for better performance
        let searchTimeout;
        searchInput.addEventListener('input', function() {
            clearTimeout(searchTimeout);
            searchTimeout = setTimeout(() => {
                filterProducts();
            }, 300);
        });
    }
    
    // ===== SYNC FAVORITES ACROSS BROWSER TABS =====
    window.addEventListener('storage', function(e) {
        if (e.key === 'favorites') {
            favorites = JSON.parse(e.newValue) || [];
            updateFavoriteCount();
        }
    });
    
    // ===== SCROLL TO TOP BUTTON =====
    const scrollToTopBtn = createScrollToTopButton();
    
    window.addEventListener('scroll', () => {
        if (window.pageYOffset > 300) {
            scrollToTopBtn.classList.remove('hidden');
            scrollToTopBtn.classList.add('flex');
        } else {
            scrollToTopBtn.classList.add('hidden');
            scrollToTopBtn.classList.remove('flex');
        }
    });
});

// ===== SCROLL TO TOP BUTTON =====

/**
 * Create floating scroll to top button
 */
function createScrollToTopButton() {
    const btn = document.createElement('button');
    btn.className = 'hidden fixed bottom-6 left-6 bg-gradient-to-r from-rose-500 to-pink-500 text-white p-4 rounded-full shadow-2xl hover:scale-110 transition-all z-40 items-center justify-center';
    btn.innerHTML = `
        <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 10l7-7m0 0l7 7m-7-7v18"/>
        </svg>
    `;
    btn.onclick = () => {
        window.scrollTo({
            top: 0,
            behavior: 'smooth'
        });
    };
    document.body.appendChild(btn);
    return btn;
}

// ===== EXPOSE PUBLIC API =====

/**
 * Global API for external access
 */
window.FloristKami = {
    toggleFavorite,
    updateFavoriteCount,
    filterProducts,
    resetFilters,
    showToast,
    favorites: () => favorites // Getter for favorites array
};

console.log('FloristKami API ready');

/*
========================================
PENJELASAN SITE.JS:
========================================

1. GLOBAL STATE MANAGEMENT:
   - favorites: Array of favorite product IDs
   - currentCategory: Active filter category
   - currentSearchTerm: Current search query

2. FAVORITES SYSTEM:
   - updateFavoriteCount(): Update badge di navbar
   - updateHeartIcons(): Update visual heart icons
   - toggleFavorite(): Add/remove dari favorites
   - Sync dengan localStorage
   - Cross-tab synchronization

3. TOAST NOTIFICATIONS:
   - Success (green) & Error (red) variants
   - Auto-dismiss after 3 seconds
   - Smooth animations
   - Only one toast at a time

4. FILTERING SYSTEM:
   - Category filter (7 categories)
   - Search filter (name & description)
   - Combined filtering logic
   - Empty state handling
   - Special edition carousel handling

5. MOBILE MENU:
   - Toggle visibility
   - Click outside to close
   - Auto-close on link click

6. SMOOTH SCROLL:
   - Anchor links (#products, #about, dll)
   - Smooth animation
   - Better UX

7. LAZY LOAD:
   - Images load saat visible
   - Better performance
   - Intersection Observer API

8. SCROLL TO TOP:
   - Floating button
   - Shows after 300px scroll
   - Smooth scroll animation

9. DEBOUNCING:
   - Search input (300ms delay)
   - Prevents excessive filtering

10. EVENT LISTENERS:
    - Favorite buttons
    - Category buttons
    - Search input
    - Mobile menu
    - Storage events (cross-tab sync)

11. PUBLIC API:
    - window.FloristKami object
    - Accessible from anywhere
    - Used by Razor views

12. PERFORMANCE:
    - Debounced search
    - Lazy loading
    - Efficient DOM manipulation
    - Event delegation where possible
*/