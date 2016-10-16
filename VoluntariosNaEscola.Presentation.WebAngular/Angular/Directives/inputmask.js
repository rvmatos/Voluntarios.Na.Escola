appDataBase.directive('inputmask', function () {
    return function (scope, element, attrs) {
        console.log('dataInputmask');
        $(element).inputmask();
       
    };
});

