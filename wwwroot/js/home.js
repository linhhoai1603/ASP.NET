document.addEventListener("DOMContentLoaded", function () {
    const swiper1 = new Swiper(".slideshow", {
        loop: true, // Lặp lại slider
        autoplay: {
            delay: 3000, // Tự động chuyển slide sau 3 giây
            disableOnInteraction: false, // Dừng khi tương tác (false nếu muốn tiếp tục)
        },
        navigation: {
            nextEl: ".swiper-button-next", // Nút chuyển tiếp
            prevEl: ".swiper-button-prev", // Nút lùi
        },
        spaceBetween: 30, // Khoảng cách giữa các slide
        speed: 600, // Tốc độ chuyển slide (ms)
    });

    const swiper2 = new Swiper(".swiper", {
        loop: true,
        slidesPerView: 4,
        slidesPerGroup: 4,
        spaceBetween: 10,
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
    });
});

// Hàm để bật/tắt hiển thị dropdown
function toggleDropdown() {
    const dropdown = document.getElementById("dropdown-menu");
    if (dropdown.classList.contains("hidden")) {
        dropdown.classList.remove("hidden");
        dropdown.classList.add("visible");
    } else {
        dropdown.classList.remove("visible");
        dropdown.classList.add("hidden");
    }
}

// Đóng dropdown khi click ra ngoài
document.addEventListener("click", function (event) {
    const dropdown = document.getElementById("dropdown-menu");
    const button = document.getElementById("page-header-user-dropdown");

    // Kiểm tra nếu click không phải vào button hoặc dropdown
    if (!button.contains(event.target) && !dropdown.contains(event.target)) {
        dropdown.classList.remove("visible");
        dropdown.classList.add("hidden");
    }
});

