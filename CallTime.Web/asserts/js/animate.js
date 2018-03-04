$(document).ready(function () {
    $("#become-partner").hover(function () {
        var btn = $("#become-partner").find(".btn-orange");
        btn.addClass('animated  bounce');
        setTimeout(function () {
            btn.removeClass('animated  bounce');
        }, 900);
    }
    );
    $("#arrow-down").hover(function () {
        $(this).addClass('animated  rubberBand');
        var self = this;
        setTimeout(function () {
            $(self).removeClass('animated  rubberBand');
        }, 900);
    });
    $(".plus").hover(function () {
        $(this).addClass('animated  rubberBand');
        var self = this;
        setTimeout(function () {
            $(self).removeClass('animated  rubberBand');
        }, 900);
    });
    $(".arrow-up").hover(function () {
        $(this).addClass('animated  tada');
        var self = this;
        setTimeout(function () {
            $(self).removeClass('animated  tada');
        }, 900);
    });
    $(".arrow-down").hover(function () {
        $(this).addClass('animated  jello');
        var self = this;
        setTimeout(function () {
            $(self).removeClass('animated  jello');
        }, 900);
    });


    // Скролл
    $(document).on('click', 'a[href^="#"]', function (event) {
        event.preventDefault();
        var offset = $($.attr(this, 'href')).offset();
        var header = $("#main-nav").height();
        var parentClass = $(this).parent();
        if (parentClass.hasClass("flex-item") ) {
            $(".flex-item").removeClass("active");
            parentClass.addClass("active");
        }
        offset.top = offset.top - header;
        $('html, body').animate({
            scrollTop: offset.top
        }, 1000);
    });


    //Открытие сервисов
    $(".nav-incoming-service").click(function () {
        $(".nav-incoming-service").addClass("active");
        $(".nav-additional-service").removeClass("active");
        $(".nav-outgoing-service").removeClass("active");

        $("#incoming-service").addClass("active");
        $("#additional-service").removeClass("active");
        $("#outgoing-service").removeClass("active");
        return true;
    });
    $(".nav-outgoing-service").click(function () {
        $(".nav-outgoing-service").addClass("active");
        $(".nav-incoming-service").removeClass("active");
        $(".nav-additional-service").removeClass("active");

        $("#outgoing-service").addClass("active");
        $("#additional-service").removeClass("active");
        $("#incoming-service").removeClass("active");
        return true;
    });
    $(".nav-additional-service").click(function () {
        $(".nav-additional-service").addClass("active");
        $(".nav-incoming-service").removeClass("active");
        $(".nav-outgoing-service").removeClass("active");

        $("#additional-service").addClass("active");
        $("#incoming-service").removeClass("active");
        $("#outgoing-service").removeClass("active");
        return true;
    });

    // Меню 
    //var $init = $('#about');
    //if ($init.length) {
    //    $init.bind('inview', function (event, isInView) {
    //        var $this = $(this);
    //        if (isInView) {
    //            $(".flex-item").removeClass("active");
    //            $(".nav-about").addClass("active");
    //        } else {
    //            $this.removeClass('in-viewport');
    //        }
    //    });
    //}
    //var $init = $('#services');
    //if ($init.length) {
    //    $init.bind('inview', function (event, isInView) {
    //        var $this = $(this);
    //        if (isInView) {
    //            $(".flex-item").removeClass("active");
    //            $(".nav-services").addClass("active");
    //        } else {
    //            $this.removeClass('in-viewport');
    //        }
    //    });
    //}
    //var $init = $('#contacts');
    //if ($init.length) {
    //    $init.bind('inview', function (event, isInView) {
    //        var $this = $(this);
    //        if (isInView) {
    //            $(".flex-item").removeClass("active");
    //            $(".nav-contacts").addClass("active");
    //        } else {
    //            $this.removeClass('in-viewport');
    //        }
    //    });
    //}
    //var $init = $('#become-partner');
    //if ($init.length) {
    //    $init.bind('inview', function (event, isInView) {
    //        var $this = $(this);
    //        if (isInView) {
    //            $(".flex-item").removeClass("active");
    //            $(".nav-become-partner").addClass("active");
    //        } else {
    //            $this.removeClass('in-viewport');
    //        }
    //    });
    //}

});