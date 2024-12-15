document.querySelector("form").addEventListener("submit", function (e) {
  e.preventDefault();
  const minPrice = document.getElementById("minPrice").value;
  const maxPrice = document.getElementById("maxPrice").value;
  const brand = document.getElementById("brand").value;

  console.log(`Filtering products with:
      Min Price: ${minPrice},
      Max Price: ${maxPrice},
      Brand: ${brand}`);
  alert("Filter applied successfully!");
});
