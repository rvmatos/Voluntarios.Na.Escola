appDataBase.controller('CategoryAddController', categoryCtrl);

categoryCtrl.$inject = ['$scope', '$routeParams', 'CategoryService', '$location', '$rootScope', '$cookieStore'];
function categoryCtrl($scope, $routeParams, categoryService, $location, $rootScope, $cookieStore) {

    $scope.action = 'I';
    $scope.Save = Save;

    function Save(form) {
        if (form.$valid)
            categoryService.insert($scope.entity, completedChange);
    }

    function completed(result) {
        $scope.entity = result.data;
    }

    function completedChange() {
        $location.path('/categories');
    }

};
