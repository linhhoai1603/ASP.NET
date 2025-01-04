
// Lấy tất cả các thẻ card
const cards = document.querySelectorAll('.card');

// Lặp qua từng card và thêm sự kiện click
cards.forEach(card => {
    card.addEventListener('click', () => {
        // Lấy URL từ thuộc tính data-url
        const url = card.getAttribute('data-url');
        if (url) {
            // Chuyển hướng đến URL
            window.location.href = url;
        }
    });
});
