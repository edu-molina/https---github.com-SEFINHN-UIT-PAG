var BlankonDashboard = function () {

    return {

        // =========================================================================
        // CONSTRUCTOR APP
        // =========================================================================
        init: function () {


            
            //BlankonDashboard.gritterNotification();
            //BlankonDashboard.bredcrumbLocation();
          
        },



        // =========================================================================
        // GRITTER NOTIFICATION
        // =========================================================================
        gritterNotification: function () {
            // display marketing alert only once
            if ($('#wrapper').css('opacity')) {
                //if (!$.cookie('intro')) {

                    // Gritter notification intro 1
                    setTimeout(function () {
                        var unique_id = $.gritter.add({
                            // (string | mandatory) the heading of the notification
                            title: 'Welcome to Blankon',
                            // (string | mandatory) the text inside the notification
                            text: 'Blankon is a theme fullpack admin template powered by Twitter bootstrap 3 front-end framework.',
                            // (string | optional) the image to display on the left
                            image: BlankonApp.handleBaseURL() + '/assets/global/img/icon/64/contact.png',
                            // (bool | optional) if you want it to fade out on its own or just sit there
                            sticky: false,
                            // (int | optional) the time you want it to be alive for before fading out
                            time: ''
                        });

                        // You can have it return a unique id, this can be used to manually remove it later using
                        setTimeout(function () {
                            $.gritter.remove(unique_id, {
                                fade: true,
                                speed: 'slow'
                            });
                        }, 12000);
                    }, 5000);

                    // Gritter notification intro 2
                    setTimeout(function () {
                        $.gritter.add({
                            // (string | mandatory) the heading of the notification
                            title: 'Playing sounds',
                            // (string | mandatory) the text inside the notification
                            text: 'Blankon made for playing small sounds, will help you with this task. Please make your sound system is active',
                            // (string | optional) the image to display on the left
                            image: BlankonApp.handleBaseURL() + '/assets/global/img/icon/64/sound.png',
                            // (bool | optional) if you want it to fade out on its own or just sit there
                            sticky: false,
                            // (int | optional) the time you want it to be alive for before fading out
                            time: ''
                        });
                    }, 8000);

                    // Set cookie intro
                    $.cookie('intro', 1, { expires: 1 });
                //}
            }
        },

        // =========================================================================
        // BREDCRUMB LOCATION
        // =========================================================================
        bredcrumbLocation: function () {

            if (window.location.pathname != "/"){ 
            
            var url = location.pathname.substring(location.pathname.lastIndexOf("/") + 1);

            var menu = $(".sidebar-menu")[0];

            var currentItem = $(menu).find("[href$='" + url + "']");

            $(".bredcrumb").html($("<li><i class='fa fa-home'></i><a href='"
                                    +window.location.origin
                                    +"'>Dashboard</a><i class='fa fa-angle-right'></i></li>"));

            var len = $(currentItem.parents("li").get().reverse()).length;

            $(currentItem.parents("li").get().reverse()).each(function (index, element) {
                if (index == len - 1) {
                    $(".bredcrumb").append("<li class='active'></li>").append( $(this).children("a").innerHTML);
                }
                else {
                    $(".bredcrumb").append("<li><a href='#'> "
                                            + $(this).children("a").innerHTML
                                            + "</a><i class='fa fa-angle-right'></i></li>");
                }
            });

            }
            
        },


    };

}();

// Call main app init
BlankonDashboard.init();
