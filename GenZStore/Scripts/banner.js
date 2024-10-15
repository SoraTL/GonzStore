// JS file: script.js
let currentIndex = 0;
const slides = document.querySelectorAll('.banner-slide');
const dots = document.querySelectorAll('.dot');
const totalSlides = slides.length;
const bannerTrack = document.querySelector('.banner-track');

function showSlide(index) {
    const slideWidth = slides[0].clientWidth;
    bannerTrack.style.transform = `translateX(-${index * slideWidth}px)`;
}

function nextSlide() {
    currentIndex = (currentIndex + 1) % totalSlides;
    showSlide(currentIndex);
}

function currentSlide(index) {
    currentIndex = index;
    showSlide(currentIndex);
}

showSlide(currentIndex);
setInterval(nextSlide, 5000); // Chuyển ảnh mỗi 3 giây
