appDataBase.controller('ContactAddController', contactCtrl);

contactCtrl.$inject = ['$scope', '$routeParams', 'ContactService', '$location', '$rootScope', '$cookieStore'];
function contactCtrl($scope, $routeParams, contactService, $location, $rootScope, $cookieStore) {

    $scope.action = 'I';
    $scope.Save = Save;

    function Save(form) {
        if (form.$valid)
            contactService.insert($scope.entity, completedChange);
    }

    function completed(result) {
        $scope.entity = result.data;
    }

    function completedChange() {
        $location.path('/contacts');
    }

};
