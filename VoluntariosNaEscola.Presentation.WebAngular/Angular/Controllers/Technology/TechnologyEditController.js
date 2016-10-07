appDataBase.controller('TechnologyEditController', technologyCtrl);

technologyCtrl.$inject = ['$scope', '$routeParams', 'TechnologyService', '$location', '$rootScope', '$cookieStore'];
function technologyCtrl($scope, $routeParams, technologyService, $location, $rootScope, $cookieStore) {

    $scope.action = 'U';
    $scope.id = $routeParams.id;
    $scope.Save = Save;

    function loadData() {
        technologyService.getById($scope.id, completed);
    }

    function Save(form) {
        if (form.$valid) {
            $scope.validSubmitted = false;
            technologyService.update($scope.entity, completedChange);
        }
        else $scope.validSubmitted = true;
    }

    function completed(result) {
        $scope.entity = result.data;
    }

    function completedChange() {
        $location.path('/technologies');
    }

    loadData();
};
