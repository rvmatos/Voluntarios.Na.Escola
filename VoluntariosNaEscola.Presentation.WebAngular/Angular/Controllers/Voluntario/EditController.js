appDataBase.controller('VoluntarioEditController', contactCtrl);

contactCtrl.$inject = ['$scope', '$routeParams', 'VoluntarioService', '$location', '$rootScope', '$cookieStore'];
function contactCtrl($scope, $routeParams, voluntarioService, $location, $rootScope, $cookieStore) {

    $scope.action = 'U';
    $scope.id = $routeParams.id;
    $scope.Save = Save;
    $scope.userLogged = $rootScope.repository.loggedUser;

    function loadData() {

        voluntarioService.getById($scope.id, completed);
    }

    function Save(form) {
        if (form.$valid) 
            voluntarioService.update($scope.entity, completedChange);
    }

    function completed(result) {
        $scope.entity = result.data;
    }

    function completedChange() {
        $location.path('/voluntario/home');
    }

    loadData();
};
