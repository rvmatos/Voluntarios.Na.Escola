appDataBase.directive('back', function ($timeout) {
    return function (scope, iElement) {
        $(iElement[0]).on('click', function () {

            if (scope.action == 'M')
                scope.closeModal();

            else {
                history.back();
                scope.$apply();
            }
        });
    };
});