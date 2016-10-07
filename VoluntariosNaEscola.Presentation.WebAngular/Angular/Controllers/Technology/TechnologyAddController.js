appDataBase.controller('TechnologyAddController', technologyCtrl);

technologyCtrl.$inject = ['$scope', '$routeParams', 'TechnologyService', '$location', '$rootScope', '$cookieStore'];
function technologyCtrl($scope, $routeParams, technologyService, $location, $rootScope, $cookieStore) {

    $scope.action = 'I';
    $scope.Save = Save;

    function Save(form) {
        if (form.$valid)
            technologyService.insert($scope.entity, completedChange);
    }

    function completed(result) {
        $scope.entity = result.data;
    }

    function completedChange() {
        $location.path('/technologies');
    }
};
