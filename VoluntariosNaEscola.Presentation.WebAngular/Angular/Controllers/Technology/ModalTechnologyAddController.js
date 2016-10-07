appDataBase.controller('ModalTechnologyAddController', modalTechnologyCtrl);

modalTechnologyCtrl.$inject = ['$scope', '$routeParams', 'TechnologyService', '$location', '$rootScope', '$cookieStore', 'ngDialog'];
function modalTechnologyCtrl($scope, $routeParams, technologyService, $location, $rootScope, $cookieStore, ngDialog) {

    $scope.action = 'M';
    $scope.Save = Save;
    $scope.closeModal = closeModal;

    function closeModal() {
        ngDialog.close();
    }

    function Save(form) {
        if (form.$valid)
            technologyService.insert($scope.entity, completedChange);
    }

    function completed(result) {
        $scope.entity = result.data;
    }

    function completedChange() {
        $scope.loadDataTechnology();
        ngDialog.close();
    }

};
