appDataBase.controller('GroupController', groupCtrl);

groupCtrl.$inject = ['$scope', 'GroupService', '$location', '$rootScope', '$cookieStore', 'ngDialog'];
function groupCtrl($scope, groupService, $location, $rootScope, $cookieStore, ngDialog) {

    $scope.ResultData = [];
    $scope.loadData = loadData;

    function loadData() {
        groupService.getAll(completed);
    }

    function completed(result) {
        $scope.ResultData = result.data;
    }

    $scope.delete = function (group) {
        $scope.group = group;

        $scope.name = group.name;

        $scope.domain = "o grupo";

        $scope.callback = function () {
            loadData();
        };

        ngDialog.open({
            template: './Views/Modal/_Delete.html',
            controller: 'GroupController',
            className: 'ngdialog-theme-default',
            scope: $scope
        });
    }


    $scope.confirmDelete = function () {
        groupService.remove($scope.group.id, completedDelete);
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
