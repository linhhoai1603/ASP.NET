document.addEventListener("DOMContentLoaded", function () {
  const swiper = new Swiper(".slideshow", {
    loop: true, // Lặp lại slider
    autoplay: {
      delay: 3000, // Tự động chuyển slide sau 3 giây
      disableOnInteraction: true, // Không dừng khi người dùng tương tác
    },
    navigation: {
      nextEl: ".swiper-button-next", // Nút chuyển tiếp
      prevEl: ".swiper-button-prev", // Nút lùi
    },
    speed: 600, // Tốc độ chuyển slide (ms)
  });
});
