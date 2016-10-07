appDataBase.controller('ContactController', contactCtrl);

contactCtrl.$inject = ['$scope', 'ContactService', '$location', '$rootScope', '$cookieStore', 'ngDialog'];
function contactCtrl($scope, contactService, $location, $rootScope, $cookieStore, ngDialog) {

    $scope.ResultData = [];
    $scope.loadData = loadData;

    function loadData() {
        contactService.getAll(completed);
    }

    function completed(result) {
        $scope.ResultData = result.data;
    }

    $scope.delete = function (contact) {
        $scope.contact = contact;

        $scope.name = contact.name;

        $scope.domain = "contato";

        $scope.callback = function () {
            loadData();
        };

        ngDialog.open({
            template: './Views/Modal/_Delete.html',
            controller: 'ContactController',
            className: 'ngdialog-theme-default',
            scope: $scope
        });
    }


    $scope.confirmDelete = function () {
        contactService.remove($scope.contact.id, completedDelete);
    }

    function completedDelete(result) {
        $scope.close();
        if ($scope.callback)
            $scope.callback();
    }

    $scope.close = function () {
        ngDialog.closeAll();
    }
};
