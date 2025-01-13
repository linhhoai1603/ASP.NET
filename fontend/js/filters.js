document.getElementById('applyFilters').addEventListener('click', function () {
  const brand = document.getElementById('brand').value;
  const priceRange = document.getElementById('priceRange').value;
  const storage = document.getElementById('storage').value;

  // Lấy giá trị từ các radio button trong dropdown "Sắp xếp theo"
  const selectedSort = document.querySelector('input[name="sortOption"]:checked')?.value;

  console.log('Thương hiệu:', brand);
  console.log('Khoảng giá:', priceRange);
  console.log('Dung lượng:', storage);
  console.log('Sắp xếp theo:', selectedSort);

  // Logic tiếp theo để xử lý
});
