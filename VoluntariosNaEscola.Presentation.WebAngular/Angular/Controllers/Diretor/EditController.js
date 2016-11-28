appDataBase.controller('VoluntarioEditController', contactCtrl);

editCtrl.$inject = ['$scope', '$routeParams', 'DiretorService', '$location', '$rootScope', '$cookieStore'];
function editCtrl($scope, $routeParams, diretorService, $location, $rootScope, $cookieStore) {

    $scope.action = 'U';
    $scope.id = $routeParams.id;
    $scope.Save = Save;
    $scope.userLogged = $rootScope.repository.loggedUser;

    function loadData() {
        diretorService.getById($scope.id, completed);
    }

    function Save(form) {
        if (form.$valid)
            diretorService.update($scope.entity, completedChange);
    }

    function completed(result) {
        $scope.entity = result.data;
    }

    function completedChange() {
        $location.path('/escola/home');
    }

    loadData();
};
