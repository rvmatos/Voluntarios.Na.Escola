appDataBase.controller('GroupEditController', groupCtrl);

groupCtrl.$inject = ['$scope', '$routeParams', 'GroupService', '$location', '$rootScope', '$cookieStore'];
function groupCtrl($scope, $routeParams, groupService, $location, $rootScope, $cookieStore) {

    $scope.action = 'U';
    $scope.id = $routeParams.id;
    $scope.Save = Save;

    function loadData() {
        groupService.getById($scope.id, completed);
    }

    function Save(form) {
        if (form.$valid)
            groupService.update($scope.entity, completedChange);
    }

    function completed(result) {
        $scope.entity = result.data;
    }

    function completedChange() {
        $location.path('/groups');
    }

    loadData();
};
