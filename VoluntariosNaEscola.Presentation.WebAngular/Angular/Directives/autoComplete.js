appDataBase.directive('autoComplete', function ($timeout) {
    return function (scope, iElement, iAttrs) {
        //var result = $.map(iAttrs.uiItems, function (item) {
        //    return {
        //        label: item.name,
        //        value: item.id
        //    }
        //});

        iElement.autocomplete({
            lookup: scope[iAttrs.uiItems],
            appendTo: '#autocomplete-container-' + iAttrs.uiItems
        });
    };
});