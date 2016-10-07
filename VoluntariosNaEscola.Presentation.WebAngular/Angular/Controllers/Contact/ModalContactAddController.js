appDataBase.controller('ModalContactAddController', modalContactCtrl);

modalContactCtrl.$inject = ['$scope', '$routeParams', 'ContactService', '$location', '$rootScope', '$cookieStore', 'ngDialog'];
function modalContactCtrl($scope, $routeParams, contactService, $location, $rootScope, $cookieStore, ngDialog) {

    $scope.action = 'M';
    $scope.Save = Save;

    $scope.closeModal = closeModal;

    function closeModal() {
        ngDialog.close();
    }

    function Save(form) {
        if (form.$valid)
            contactService.insert($scope.entity, completedChange);
    }

    function completed(result) {
        $scope.entity = result.data;
    }

    function completedChange() {
        $scope.loadDataContact();
        ngDialog.close();
    }
};
