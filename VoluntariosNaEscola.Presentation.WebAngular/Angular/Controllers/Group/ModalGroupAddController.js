appDataBase.controller('ModalGroupAddController', modalgroupCtrl);

modalgroupCtrl.$inject = ['$scope', '$routeParams', 'GroupService', '$location', '$rootScope', '$cookieStore', 'ngDialog'];
function modalgroupCtrl($scope, $routeParams, groupService, $location, $rootScope, $cookieStore, ngDialog) {

    $scope.action = 'M';
    $scope.Save = Save;
    $scope.closeModal = closeModal;

    function closeModal() {
        ngDialog.close();
    }

    function Save(form) {
        if (form.$valid)
            groupService.insert($scope.entity, completedChange);
    }

    function completed(result) {
        $scope.entity = result.data;
    }

    function completedChange() {
        $scope.loadDataGroup();
        ngDialog.close();
    }

};
