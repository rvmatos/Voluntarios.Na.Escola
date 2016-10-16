appDataBase.directive('tabtoggle', function () {
    return function (scope, element, attrs) {
        
        $(element).click(function () {

            $('a[role="tab"]').each(function () {              
                $(this).attr("aria-expanded", "false");
                $(this).parent().attr('class', '');
            });

            $('div[role="tabpanel"]').each(function () {
                $(this).removeClass('active in');
            });

            $(this).attr("aria-expanded", "true");
            $(this).parent().attr('class', 'active');
            $('#' + $(this).data('tabtoggle')).addClass('active in');
         
        });
       

    };
});

