appDataBase.directive('toggle', function () {
    return function (scope, element, attrs) {

        if($(element).data('toggle') =='tooltip')
        {
            $(element).tooltip();
        }


    };
});

