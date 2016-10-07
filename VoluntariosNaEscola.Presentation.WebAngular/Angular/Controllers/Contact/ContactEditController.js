appDataBase.controller('ContactEditController', contactCtrl);

contactCtrl.$inject = ['$scope', '$routeParams', 'ContactService', '$location', '$rootScope', '$cookieStore'];
function contactCtrl($scope, $routeParams, contactService, $location, $rootScope, $cookieStore) {

    $scope.action = 'U';
    $scope.id = $routeParams.id;
    $scope.Save = Save;

    function loadData() {
        contactService.getById($scope.id, completed);
    }

    function Save(form) {
        if (form.$valid) 
            contactService.update($scope.entity, completedChange);
    }

    function completed(result) {
        $scope.entity = result.data;
    }

    function completedChange() {
        $location.path('/contacts');
    }

    loadData();
};
