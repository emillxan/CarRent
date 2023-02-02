$(document).ready(function () {
    var swiper = new Swiper(".mySwiper", {});

    $('body').on('click', '.btn-burger', function () {
        event.preventDefault()
        $('.main-nav').animate({ 'width': '10rem' }, 200);
        $('.nav-bg').css('display', 'block');
        $('.nav-bg').animate({ 'opacity': '1' }, 200);
    })

    function closeBurgerNav() {
        event.preventDefault();
        $('.main-nav').animate({ 'width': '0rem' }, 200);
        $('.nav-bg').animate({ 'opacity': '0' }, 200);
        $('.nav-bg').css('display', 'none');
    }

    $('body').on('click', '.nav-bg', function () { closeBurgerNav(); })
    $('body').on('click', 'nav ul li .close', function () { closeBurgerNav(); })

    if ($('*').is('.header-carousel__box')) {
        setInterval(function () {
            if ($('.header-carousel__box').position().left == 0) {
                $('.header-carousel__box').animate({ left: '-100%' }, 500)
            } else {
                $('.header-carousel__box').animate({ left: '0' }, 500)
            }
        }, 5000)
    }


    $('body').on('click', '.featured-cars .featured-cars__top .featured-cars__btn a', function () {
        event.preventDefault()
        $(this).parent().children().removeClass('active')
        $(this).addClass('active')
    })



    $('body').on('click', '.our-car__shop .top-filter .top-filter__visible a', function () {
        event.preventDefault()
        $(this).parent().children().children().removeClass('active')
        $(this).children().addClass('active')
        console.log($(this).children().hasClass('.fa-grip'));
        if ($(this).children().hasClass('fa-grip')) {
            $('.our-car__shop .car-card').addClass('bg')
            $('.our-car__shop .car-card').removeClass('sm')
        } else {
            $('.our-car__shop .car-card').addClass('sm')
            $('.our-car__shop .car-card').removeClass('bg')
        }
    })
})