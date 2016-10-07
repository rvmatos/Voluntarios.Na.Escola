appDataBase.directive('dropShowHide', function ($timeout) {
    return function (scope, iElement) {
        $(iElement[0]).on('click', function () {
            if ($('.daterangepicker').is(':visible'))
                $('.daterangepicker').hide();
            else $('.daterangepicker').show();
        });
    };
});