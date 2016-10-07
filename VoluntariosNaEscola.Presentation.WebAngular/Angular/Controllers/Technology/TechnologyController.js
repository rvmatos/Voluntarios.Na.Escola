appDataBase.controller('TechnologyController', technologyCtrl);

technologyCtrl.$inject = ['$scope', 'TechnologyService', '$location', '$rootScope', '$cookieStore', 'ngDialog'];
function technologyCtrl($scope, technologyService, $location, $rootScope, $cookieStore, ngDialog) {

    $scope.ResultData = [];
    $scope.loadData = loadData;

    function loadData() {
        technologyService.getAll(completed);
    }

    function completed(result) {
        $scope.ResultData = result.data;
    }

    $scope.delete = function (technology) {
        $scope.technology = technology;

        $scope.name = technology.name;

        $scope.domain = "a tecnologia";

        $scope.callback = function () {
            loadData();
        };

        ngDialog.open({
            template: './Views/Modal/_Delete.html',
            controller: 'TechnologyController',
            className: 'ngdialog-theme-default',
            scope: $scope
        });
    }


    $scope.confirmDelete = function () {
        technologyService.remove($scope.technology.id, completedDelete);
    }

    function completedDelete(result) {
        ngDialog.closeAll();
        if ($scope.callback)
            $scope.callback();
    }

    $scope.close = function () {
        ngDialog.closeAll();
    }
};
