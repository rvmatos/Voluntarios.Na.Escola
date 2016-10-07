appDataBase.controller('CategoryEditController', categoryCtrl);

categoryCtrl.$inject = ['$scope', '$routeParams', 'CategoryService', '$location', '$rootScope', '$cookieStore'];
function categoryCtrl($scope, $routeParams, categoryService, $location, $rootScope, $cookieStore) {

    $scope.action = 'U';
    $scope.id = $routeParams.id;
    $scope.Save = Save;
    function loadData() {
        categoryService.getById($scope.id, completed);
    }

    function Save(form) {
        if (form.$valid)
            categoryService.update($scope.entity, completedChange);
    }

    function completed(result) {
        $scope.entity = result.data;
    }

    function completedChange() {
        $location.path('/categories');
    }
    loadData();

};
