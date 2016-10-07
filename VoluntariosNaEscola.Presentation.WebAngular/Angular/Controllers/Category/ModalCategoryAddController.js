appDataBase.controller('ModalCategoryAddController', modalcategoryCtrl);

modalcategoryCtrl.$inject = ['$scope', '$routeParams', 'CategoryService', '$location', '$rootScope', '$cookieStore', 'ngDialog'];
function modalcategoryCtrl($scope, $routeParams, categoryService, $location, $rootScope, $cookieStore, ngDialog) {

    $scope.action = 'M';
    $scope.Save = Save;
    $scope.closeModal = closeModal;

    function Save(form) {
        if (form.$valid)
            categoryService.insert($scope.entity, completedChange);
    }

    function completed(result) {
        $scope.entity = result.data;
    }

    function completedChange() {
        $scope.loadDataCategory();
        ngDialog.close();
    }

    function closeModal() {
        ngDialog.close();
    }

};
