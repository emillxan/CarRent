$(document).ready(function () {
    var swiper = new Swiper(".carPageSwiper", {
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
    });
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


    $('body').on('click', '.my-acc-in .show-password', function () {
        event.preventDefault();

        if ($(this).text() == 'SHOW') {
            $('.my-acc-in .pass').attr('type', 'text');
            $(this).text('HIDE')
        }
        else {
            $('.my-acc-in .pass').attr('type', 'password');
            $(this).text('SHOW')
        }

    })




    $('body').on('click', '#btn-create-acc', function () {
        event.preventDefault()
        let html = `<section class="my-acc-in create-acc container">
        <h2>Create an account</h2>
        <div class="in-box">
            <p>Already have an account? <a href="" class="log-in" id="btn-sing-acc">Log in instead!</a></p>
            <table>
                <tbody class="input-box">
                    <tr>
                        <th><p>First name</p></th>
                        <td><input type="text"></td>
                    </tr>
                    <tr>
                        <th><p>Last name</p></th>
                        <td><input type="text"></td>
                    </tr>
                    <tr>
                        <th><p>Email</p></th>
                        <td><input type="text"></td>
                    </tr>
                    <tr>
                        <th><p>Password</p></th>
                        <td>    
                            <div class="pass-box">
                                <input type="password" class="pass">
                                <a href="" class="show-password">SHOW</a>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th><p>Birthdate</p></th>
                        <td><input type="date"></td>
                    </tr>
                </tbody>
            </table>
            <div class="">
                <div class="check">
                    <input type="checkbox" name="'" id="">
                    <p>Receive offers from our partners</p>
                </div>
                <div class="check">
                    <input type="checkbox" name="'" id="">
                    <p>Sign up for our newsletter</p>
                </div>
            </div>
            <div class="btn-box">
                <a href="" class="sing-in">SAVE</a>
            </div>
        </div>
    </section>`
        $('main').html(html);
    })
    $('body').on('click', '#btn-sing-acc', function () {
        event.preventDefault()
        let html = `<section class="my-acc-in log-in container">
        <h2>Log in to your account</h2>
        <div class="in-box">
            <table>
                <tbody class="input-box">
                    <tr>
                        <th><p>Emai</p></th>
                        <th><input type="text"></th>
                    </tr>
                    <tr>
                        <th><p>Password</p></th>
                        <th>
                            <div class="pass-box">
                                <input type="password" class="pass">
                                <a href="" class="show-password">SHOW</a>
                            </div>
                        </th>
                    </tr>
                </tbody>
            </table>
            <div class="btn-box">
                <a href="" class="forgot-password">Forgot your password?</a>
                <a href="" class="sing-in">SING IN</a>
                <hr>
                <a href="" class="create-acc" id="btn-create-acc">No account? Create one here</a>
            </div>
        </div>
    </section>`
        $('main').html(html);
    })
})