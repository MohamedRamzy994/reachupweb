/*global $, alert, console, jQuery, Typed*/

$(document).ready(function () {




    "use strict";
    
    
    $("html").niceScroll({
        
        cursorcolor: "#282828",
        cursorborder: "none",
        cursorwidth: "5px",
        horizrailenabled: false
        
    });
    
    var typed, scrollButton, x;
    
    $('body').scrollspy({ target: '#navbar-collapsible', offset: 50 });
    
   
     // animate links
    $('.navbar .nav li a').click(function () {
        $('html, body').animate({
            //scrollTop: $('#' + $(this).data('value')).offset().top
            scrollTop: $($(this).attr("href")).offset().top
        }, 1000);
    });

    $('.MyBackground .links a').click(function () {
        $('html, body').animate({
            //scrollTop: $('#' + $(this).data('value')).offset().top
            scrollTop: $($(this).attr("href")).offset().top
        }, 1000);
    });

    
    // animate links
    $('.footer-second .pull-left li a').click(function () {
        $('html, body').animate({
            //scrollTop: $('#' + $(this).data('value')).offset().top
            scrollTop: $($(this).attr("href")).offset().top
        }, 1000);
    });
    
    
    
    $('.carousel').carousel();
    
    
    /* ********************************************************************* */
        
    $(".MyBackground").height($(window).height() - 65);
    
    $(window).on("resize", function () {
        $(".MyBackground").height($(window).height() - 65);
    });
    
    /* ********************************************************************** */
    
    $('.popup-with-zoom-anim').magnificPopup({
        type: 'inline',
        fixedContentPos: false,
        fixedBgPos: true,
        overflowY: 'auto',
        closeBtnInside: true,
        preloader: false,
        midClick: true,
        removalDelay: 300,
        mainClass: 'my-mfp-zoom-in'
    });
    
    /* ********************************************************************** */
    
    $(".about_us .My-Container div.yy:not(:first-of-type)").css({display: "none"});
        
    $("#my-tabs li").click(function () {
        
        $(".about_us .My-Container div.yy:not(:first-of-type)").css({display: "none"});
        
        var myID = $(this).attr("id");
        
        $(this).removeClass("In-active").siblings().addClass("In-active");
        
        $(".about_us #my-tabs").next('div').hide();
        
        $("#" + myID + "-content").fadeIn(400);
        
    });
    
    /* ********************************************************************** */
    
    $('.autoplay').slick({
        slidesToShow: 4,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 2000,
        left : true,
        dots: true,
        responsive: [{
            
            breakpoint: 992,
            settings: {
                slidesToShow: 3,
                infinite: true,
                dots: true
            }
            
        }, {
            
            breakpoint: 800,
            settings: {
                slidesToShow: 2,
                infinite: true,
                arrows: false,
                dots: true
            }
            
        }, {
            
            breakpoint: 401,
            settings: {
                slidesToShow: 1,
                infinite: true,
                arrows: false,
                dots: true
            }
            
        }, {
            
            breakpoint: 251,
            settings: "unslick" // destroys slick
            
        }]
        
    });
    
    /* ********************************************************************** */
    
    $(".youtube-link").grtyoutube({
        theme: "dark" // or dark
    });
    
    /* ********************************************************************** */
    
    $('.projects .myimg p').css({left: '-20%'});
    
    $('.projects .myimg').hover(function () {
        
        $('.projects .myimg p').animate({left: '50%'}, "0");
        
    }, function () {
        
        $('.projects .myimg p').css({left: '-20%'});
        
    });
    
    /* ******************************************* */
    
    $('.about_content').hover(function () {
        
        $(this).children('p').css({color: '#FFF'});
        
    }, function () {
        
        $(this).children('p').css({color: '#777'});
        
    });
    
    
    /* ********************************************************************** */

    $('.footer-third .img-content').directionalHover({
        // CSS class for the overlay
        overlay: "footer-overlay",
        // Linear or swing
        easing: "swing",
        speed: 400
    });
    
    /* ********************************************************************** */

    // Scroll top
    $(".scroll-down i").click(function () {
        
        $("html, body").animate({
            scrollTop: $(".about").offset().top
        }, 1000);
        
    });
    
    /* ********************************************************************** */

    
    
});


// loading 
$(window).on("load", function () {
    
    "use strict";
        
    var typed;
    
    typed = new Typed(".loading-overlay .heading", {

        strings: ["reach UP marketing agency"],
        typeSpeed: 20,
        showCursor: true,
        cursorChar: ''
    });
    
    
    $('.loading-overlay .myloading .sk-cube-grid').fadeOut(2000, function () {

        $(".loading-overlay .myloading .loading-overlay-content").fadeOut(1000);
        
        $(this).parent().parent().fadeOut(2000, function () {

            // Show Scroll
            $("body").css("overflow", "auto");

            $(this).remove();
            
        });
        
    });
    
    
    
});



/* ********************************************************************************************* */


$(window).ready(function () {

    "use strict";

    var a = 0;
    
    $(window).scroll(function () {

        var CountTop = $('.count').offset().top - window.innerHeight;
        
        //console.log($('.count').offset().top - window.innerHeight);
        
        if (a === 0 && $(window).scrollTop() > CountTop) {
            
            $('.count').countTo({
                speed: 6000
            });
            
            a = 10;
        }

    });
    
    
});



$(document).ready(function () {

    "use strict";

    var scrollButton = $("#Scroll-top");

    //Check to see if the window is top if not then display button
    $(window).scroll(function () {

        if ($(this).scrollTop() > 100) {

            scrollButton.fadeIn();

        } else {

            scrollButton.fadeOut();
        }

    });


    //Click event to scroll to top
    scrollButton.click(function () {
        $('html, body').animate({ scrollTop: 0 }, 1000);
        return false;
    });

    /* ***************************************** */

    // FoR vimo Plugin
    /* jQuery(".demo").YouTubePopUp({ autoplay: 0 }); */

});