appDataBase.directive('inputmask', function () {
    return function (scope, element, attrs) {
        console.log(scope,element, attrs);
        $(element).inputmask({ placeholder: " ", clearMaskOnLostFocus: true });
       
    };
});

