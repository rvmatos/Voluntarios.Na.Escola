appDataBase.controller('GroupAddController', groupCtrl);

groupCtrl.$inject = ['$scope', '$routeParams', 'GroupService', '$location', '$rootScope', '$cookieStore'];
function groupCtrl($scope, $routeParams, groupService, $location, $rootScope, $cookieStore) {

    $scope.action = 'I';
    $scope.Save = Save;

    function Save(form) {
        if (form.$valid)
            groupService.insert($scope.entity, completedChange);
    }

    function completed(result) {
        $scope.entity = result.data;
    }

    function completedChange() {
        $location.path('/groups');
    }

};
