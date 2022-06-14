/*global $, alert, console, jQuery, Typed*/

$(document).ready(function () {

    "use strict";
    
    $("html").niceScroll();
    
    var typed, scrollButton, x;
    
    $('body').scrollspy({ target: '#navbar-collapsible', offset: 50 });
    
   
     // animate links
    $('.navbar .nav li a').click(function () {
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
        
    
    
    /* ********************************************************************** */
    
    $('.autoplay').slick({
        slidesToShow: 4,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 3000,
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

        //strings: ["Said You Good Man", "You Are Welcom In My Website"],
        strings: ["You Are Welcom In My Website"],
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
		$('html, body').animate({scrollTop : 0}, 1000);
		return false;
	});
    
	
});