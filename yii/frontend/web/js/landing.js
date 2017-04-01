$(document).ready(function() {
	$('.fix-to-screen-height').css('min-height',window.innerHeight + 'px');
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
