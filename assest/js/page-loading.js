/*
 * Title:   Travelo - Travel, Tour Booking HTML5 Template - Page Loading Js
 * Author:  http://themeforest.net/user/soaptheme
 */

// pace.js should be active

if (typeof Pace != "undefined") {
    var soapPageLoadingContent = false;
    //document.write('<img alt="" src="images/logo2.png" style="display: none;">');
    var logoImg = new Image();
    logoImg.src = "images/logo2.png";
    var soapPageLoadingProgressInterval = setInterval(function() {
        try {
            if (document.body.className.indexOf("pace-done") != -1) {
                clearInterval(soapPageLoadingProgressInterval);
            }
            if (document.body.className.indexOf("pace-running") == -1) {
                return;
            }
            if (!soapPageLoadingContent) {
               /*document.getElementsByClassName("pace-activity")[0].innerHTML = '<div class="loading-page style1">' +
                                                '<div class="loading-page-wrapper">' +
                                                    '<div class="container">' +
                                                            '<h1 class="logo block">' +
                                                                '<a title="Travelo" href="#">' +
                                                                    '<img alt="" src="images/logo2.png">' +
                                                                '</a>' +
                                                            '</h1>' +
                                                            '<div class="loading-progress-bar block col-sm-10 col-md-9 col-lg-8">' +
                                                                '<div style="width: 1%;" class="loading-progress"></div>' +
                                                            '</div>' +
                                                            '<span class="loading-text">Loading...</span>' +
                                                    '</div>' +
                                                '</div>' +
                                            '</div>';*/
				document.getElementsByClassName("pace-activity")[0].innerHTML = '<div class="loading-page style2">' +
                                                '<div class="loading-page-wrapper">' +
                                                    '<div class="container">' +
                                                            '<h1 class="logo block">' +
                                                                '<a title="Travelo" href="#">' +
                                                                    '<img alt="" src="images/logo2.png">' +
                                                                '</a>' +
                                                            '</h1>' +
															'<div class="loading-text block">Website is Loading...</div>' +
															'<div class="notice-message block">please<br>be patient!</div><br />' +
                                                            '<div class="loading-progress-bar block col-sms-10 col-sm-8 col-md-6">' +
                                                                '<div class="loading-progress" style="width: 1%;"></div>' +
																'<div class="loading-percent">1%</div>' +
                                                            '</div>' +
                                                    '</div>' +
                                                '</div>' +
                                            '</div>';
                soapPageLoadingContent = true;
            }

            var percent = document.getElementsByClassName("pace-progress")[0].getAttribute("data-progress-text");
            document.getElementsByClassName("loading-progress")[0].style.width = percent;
			document.getElementsByClassName("loading-percent")[0].innerHTML = percent;
        } catch(e) {  }
    }, 50);
}