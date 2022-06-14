(function() {
    "use strict";

    // custom scrollbar

    $("html").niceScroll({ styler: "fb", cursorcolor: "#282828", cursorwidth: '6', cursorborderradius: '10px', background: '#FFFFFF', spacebarenabled: false, cursorborder: '0', zindex: '1000' });

 
    $(".scrollbar1").niceScroll({ styler: "fb", cursorcolor:"#282828", cursorwidth: '6', cursorborderradius: '0',autohidemode: 'false', background: '#FFFFFF', spacebarenabled:false, cursorborder: '0'});

	
	
    $(".scrollbar1").getNiceScroll();
    if ($('body').hasClass('scrollbar1-collapsed')) {
        $(".scrollbar1").getNiceScroll().hide();
    }

})(jQuery);

(function() {
    "use strict";

    // custom scrollbar

    $("html").niceScroll({ styler: "fb", cursorcolor:"#282828", cursorwidth: '6', cursorborderradius: '10px', background: '#FFFFFF', spacebarenabled:false, cursorborder: '0',  zindex: '1000'});

    $(".scrollbar1").niceScroll({ styler: "fb", cursorcolor:"#282828", cursorwidth: '6', cursorborderradius: '0',autohidemode: 'false', background: '#FFFFFF', spacebarenabled:false, cursorborder: '0'});

	
	
    $(".scrollbar1").getNiceScroll();
    if ($('nav.gn-menu-wrapper').hasClass('scrollbar1-collapsed')) {
        $(".scrollbar1").getNiceScroll().hide();
    }

})(jQuery);


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




                     
     
  