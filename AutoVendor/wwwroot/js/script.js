 // Elements
    const productsGrid = document.getElementById('products');
    const emptyState = document.getElementById('emptyState');
    const searchInput = document.getElementById('searchInput');

    const filterToggle = document.getElementById('filterToggle');
    const filterMenu = document.getElementById('filterMenu');
    const applyBtn = document.getElementById('applyFilters');
    const clearBtn = document.getElementById('clearFilters');

    // Open/close dropdown
    function openMenu(){ filterMenu.classList.add('open'); filterMenu.setAttribute('aria-hidden','false'); filterToggle.setAttribute('aria-expanded','true'); }
    function closeMenu(){ filterMenu.classList.remove('open'); filterMenu.setAttribute('aria-hidden','true'); filterToggle.setAttribute('aria-expanded','false'); }
    filterToggle.addEventListener('click', (e)=> {
      e.stopPropagation();
      if(filterMenu.classList.contains('open')) closeMenu(); else openMenu();
    });
    document.addEventListener('click', (e)=> {
      if(!filterMenu.contains(e.target) && !filterToggle.contains(e.target)) closeMenu();
    });
    document.addEventListener('keydown', (e)=> { if(e.key === 'Escape') closeMenu(); });

    // Helper: get current filters
    function getFilters() {
      const q = searchInput.value.trim().toLowerCase();

      // multiple models via checkboxes
      const selectedModels = Array.from(document.querySelectorAll('input[name="model"]:checked')).map(cb => cb.value);

      const brand = document.getElementById('brandFilter').value;
      const priceF = document.getElementById('priceFilter').value;
      const sort = document.getElementById('sortFilter').value;

      return { q, selectedModels, brand, priceF, sort };
    }

    // Apply filters to DOM cards
    function applyFilters() {
      const { q, selectedModels, brand, priceF, sort } = getFilters();

      // collect products
      const cards = Array.from(productsGrid.querySelectorAll('.product'));

      // filter
      let filtered = cards.filter(card => {
        const title = card.querySelector('h3').textContent.toLowerCase();
        const model = (card.dataset.model || '').toLowerCase();
        const brandData = card.dataset.brand || '';
        const price = Number(card.dataset.price || 0);

        if (q && !title.includes(q)) return false;
        if (selectedModels.length && !selectedModels.includes(card.dataset.model)) return false;
        if (brand && brandData !== brand) return false;

        if (priceF === 'lt50k' && !(price < 50000)) return false;
        if (priceF === '50to100k' && !(price >= 50000 && price <= 100000)) return false;
        if (priceF === 'gt100k' && !(price > 100000)) return false;

        return true;
      });

      // sort
      if (sort === 'asc' || sort === 'desc') {
        filtered.sort((a,b) => {
          const pa = Number(a.dataset.price || 0);
          const pb = Number(b.dataset.price || 0);
          return sort === 'asc' ? (pa - pb) : (pb - pa);
        });
      }

      // render: hide all, then show filtered in order
      cards.forEach(c => c.style.display = 'none');
      filtered.forEach(c => {
        c.style.display = 'block';
        productsGrid.appendChild(c); // reorder visually
      });

      emptyState.style.display = filtered.length ? 'none' : 'block';
    }

    // Bind buttons
    document.getElementById('searchBtn').addEventListener('click', applyFilters);
    applyBtn.addEventListener('click', () => { applyFilters(); closeMenu(); });

    clearBtn.addEventListener('click', () => {
      searchInput.value = '';
      document.querySelectorAll('input[name="model"]').forEach(cb => cb.checked = false);
      document.getElementById('brandFilter').value = '';
      document.getElementById('priceFilter').value = '';
      document.getElementById('sortFilter').value = '';

      // reset view (show all)
      Array.from(productsGrid.querySelectorAll('.product')).forEach(c => c.style.display = 'block');
      emptyState.style.display = 'none';
      closeMenu();
    });

    // Optional: Enter key triggers search
    searchInput.addEventListener('keydown', (e)=> { if(e.key === 'Enter') { e.preventDefault(); applyFilters(); } });