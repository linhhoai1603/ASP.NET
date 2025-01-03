document.getElementById('applyFilters').addEventListener('click', function () {
  const brand = document.getElementById('brand').value;
  const priceRange = document.getElementById('priceRange').value;
  const storage = document.getElementById('storage').value;

  // Lấy giá trị từ các checkbox trong dropdown "Sắp xếp theo"
  const sortCheckboxes = document.querySelectorAll('.sort-checkbox');
  const selectedSort = Array.from(sortCheckboxes)
      .filter(checkbox => checkbox.checked)
      .map(checkbox => checkbox.value);

  console.log('Thương hiệu:', brand);
  console.log('Khoảng giá:', priceRange);
  console.log('Dung lượng:', storage);
  console.log('Sắp xếp theo:', selectedSort);

  // Logic tiếp theo để xử lý
});
