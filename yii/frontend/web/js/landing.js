$(function() {
	if (window.innerHeight < 800) {
		$('.fix-to-screen-height').css('min-height',window.innerHeight + 'px');
	}
	// $.each('.fix-to-screen-height', function(i, elem) {
	// });
	$(window).scroll(function() {
		if ($('body').scrollTop() < 10) {
			$('.navbar-default').removeClass('scrolled');	
			return;
		}
		$('.navbar-default').addClass('scrolled');
	});

	$('.go-to-register').on('click', function() {
		$('body').animate({scrollTop:$('.registration-section').offset().top - 80}, '2000', 'swing');
	});
});


/*!
 * Start Bootstrap - Creative v3.3.7+1 (http://startbootstrap.com/template-overviews/creative)
 * Copyright 2013-2016 Start Bootstrap
 * Licensed under MIT (https://github.com/BlackrockDigital/startbootstrap/blob/gh-pages/LICENSE)
 */
window.sr = ScrollReveal();
sr.reveal(".sr-section", {
    duration: 600,
    scale: .3,
    distance: "0px"
});