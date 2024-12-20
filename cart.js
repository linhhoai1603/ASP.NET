function formatPrice(value) {
  return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(value).replace(/₫/g, 'đ');
}

function updateTotalPrice() {
  const prices = document.querySelectorAll('.price');
  let total = 0;
  prices.forEach(price => {
    const priceValue = parseInt(price.textContent.replace(/\D/g, ''));
    total += priceValue;
  });
  document.getElementById('total-price').textContent = formatPrice(total);
  document.getElementById('final-price').textContent = formatPrice(total);
}

function increaseQuantity(event, unitPrice) {
  const quantityElement = event.target.parentNode.querySelector('.quantity');
  let quantity = parseInt(quantityElement.textContent);
  quantity++;
  quantityElement.textContent = quantity;

  const priceElement = event.target.parentNode.querySelector('.price');
  priceElement.textContent = formatPrice(quantity * unitPrice);

  updateTotalPrice();
}

function decreaseQuantity(event, unitPrice) {
  const quantityElement = event.target.parentNode.querySelector('.quantity');
  let quantity = parseInt(quantityElement.textContent);
  if (quantity > 1) {
    quantity--;
    quantityElement.textContent = quantity;

    const priceElement = event.target.parentNode.querySelector('.price');
    priceElement.textContent = formatPrice(quantity * unitPrice);

    updateTotalPrice();
  }
}
