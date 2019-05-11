$(document).ready(function() {
    $(".testimonial-carousel").each(function () {
        $(this).slick({
            infinite: !0,
            slidesToShow: 4,
            slidesToScroll: 1,
            autoplay: !1,
            arrows: true,
            prevArrow: $(this).closest('.my-slider-box').find(".prev"),
            nextArrow: $(this).closest('.my-slider-box').find(".next"),
            responsive: [{
                breakpoint: 1200,
                settings: {
                    slidesToShow: 3
                }
            }, {
                breakpoint: 992,
                settings: {
                    slidesToShow: 2
                }
            }, {
                breakpoint: 600,
                settings: {
                    slidesToShow: 1
                }
            }]
        });
    })
});