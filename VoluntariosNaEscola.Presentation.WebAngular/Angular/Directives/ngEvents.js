appDataBase.directive('ngEnter', function () {
    return function (scope, element, attrs) {
        var result = $(element).closest('form');
        result.bind("keydown keypress", function (event) {
            if (event.which === 13) {
                scope.$apply(function () {
                    scope.$eval(attrs.ngEnter);
                });

                event.preventDefault();
            }
        });
    };
});

