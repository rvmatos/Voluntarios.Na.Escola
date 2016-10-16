appDataBase.controller('VoluntarioEditController', contactCtrl);

contactCtrl.$inject = ['$scope', '$routeParams', 'EscolaService', '$location', '$rootScope', '$cookieStore'];
function contactCtrl($scope, $routeParams, escolaService, $location, $rootScope, $cookieStore) {

    $scope.action = 'U';
    $scope.id = $routeParams.id;
    $scope.Save = Save;
    $scope.userLogged = $rootScope.repository.loggedUser;

    function loadData() {
        escolaService.getById($scope.id, completed);
    }

    function Save(form) {
        if (form.$valid)
            escolaService.update($scope.entity, completedChange);
    }

    function completed(result) {
        $scope.entity = result.data;
    }

    function completedChange() {
        $location.path('/escola-home');
    }

    loadData();
};
