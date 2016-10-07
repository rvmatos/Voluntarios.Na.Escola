appDataBase.controller('CategoryController', categoryCtrl);

categoryCtrl.$inject = ['$scope', 'CategoryService', '$location', '$rootScope', '$cookieStore', 'ngDialog'];
function categoryCtrl($scope, categoryService, $location, $rootScope, $cookieStore, ngDialog) {

    $scope.ResultData = [];
    $scope.loadData = loadData;

    function loadData() {
        categoryService.getAll(completed);
    }

    function completed(result) {
        $scope.ResultData = result.data;
    }

    $scope.delete = function (category) {
        $scope.category = category;
        $scope.name = category.name;
        $scope.domain = "a categoria";

        $scope.callback = function () {
            loadData();
        };

        ngDialog.open({
            template: './Views/Modal/_Delete.html',
            controller: 'CategoryController',
            className: 'ngdialog-theme-default',
            scope: $scope
        });
    }

    $scope.confirmDelete = function () {
        categoryService.remove($scope.category.id, completedDelete);
    }

    function completedDelete(result) {
        ngDialog.closeAll();
        if ($scope.callback) {
            $scope.callback();
        }
    }

    $scope.close = function () {
        ngDialog.closeAll();
    }
};
