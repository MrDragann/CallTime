$(document).ready(function () {


    // Scroll Events
    $(window).scroll(function () {

        var wScroll = $(this).scrollTop();

        // Activate menu
        if (wScroll > 20) {
            $('#main-nav').addClass('active');
            $('#slide_out_menu').addClass('scrolled');
        }
        else {
            $('#main-nav').removeClass('active');
            $('#slide_out_menu').removeClass('scrolled');
        };


        //Scroll Effects

    });


    // Navigation
    $('#navigation').on('click', function (e) {
        e.preventDefault();
        $(this).addClass('open');
        $('#slide_out_menu').toggleClass('open');

        if ($('#slide_out_menu').hasClass('open')) {
            $('.menu-close').on('click', function (e) {
                e.preventDefault();
                $('#slide_out_menu').removeClass('open');
            })
        }
    });


    // Price Table
    var individual_price_table = $('#price_tables').find('.individual');
    var company_price_table = $('#price_tables').find('.company');


    $('.switch-toggles').find('.individual').addClass('active');
    $('#price_tables').find('.individual').addClass('active');

    $('.switch-toggles').find('.individual').on('click', function () {
        $(this).addClass('active');
        $(this).closest('.switch-toggles').removeClass('active');
        $(this).siblings().removeClass('active');
        individual_price_table.addClass('active');
        company_price_table.removeClass('active');
    });

    $('.switch-toggles').find('.company').on('click', function () {
        $(this).addClass('active');
        $(this).closest('.switch-toggles').addClass('active');
        $(this).siblings().removeClass('active');
        company_price_table.addClass('active');
        individual_price_table.removeClass('active');
    });


    // Wow Animations
    wow = new WOW(
        {
            boxClass: 'wow',      // default
            animateClass: 'animated', // default
            offset: 60,          // default
            mobile: true,       // default
            live: true        // default
        }
    )
    wow.init();


    // Menu For Xs Mobile Screens
    if ($(window).height() < 450) {
        $('#slide_out_menu').addClass('xs-screen');
    }

    $(window).on('resize', function () {
        if ($(window).height() < 450) {
            $('#slide_out_menu').addClass('xs-screen');
        } else {
            $('#slide_out_menu').removeClass('xs-screen');
        }
    });


    // Magnific Popup
    $(".lightbox").magnificPopup();

    $(".icon-circle-down").click(function () {
        var li = $(this).parent().parent();
        if (li.hasClass("active")) {
           
            li.children().find("p").addClass("animated fadeOutDown");
            setTimeout(function () {
                li.removeClass("active");
                li.children().find("p").removeClass("animated fadeOutDown");
            }, 600);
          
            //li.children().find("p").removeClass("animated slideInUp");
        }
        else {
            li.addClass("active");
          
        }
    });
   //ывывыв
	$(".typed").typed({
        strings: ["криптовалютными биржами"],
		// Optionally use an HTML element to grab strings from (must wrap each string in a <p>)
		stringsElement: null,
		// typing speed
		typeSpeed: 20,
		// time before typing starts
		startDelay: 200,
		// backspacing speed
		backSpeed: 20,
		// time before backspacing
        backDelay: 500,
        fadeOut: true,
        fadeOutClass: 'typed-fade-out',
        fadeOutDelay: 500,
		// loop
		loop: false,
        // show cursor
        showCursor: true,
		// character for cursor
		cursorChar: "|",
		// attribute to type (null == text)
		attr: null,
		// either html or text
		contentType: 'html',
		// call when done callback function
		callback: function() {},
		// starting callback function before each string
		preStringTyped: function() {},
		//callback for every typed string
		onStringTyped: function() {},
		// callback for reset
		resetCallback: function() {}
	});




  

});
