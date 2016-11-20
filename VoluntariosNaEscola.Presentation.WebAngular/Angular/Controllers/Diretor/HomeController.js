appDataBase.controller('DiretorHomeController', homeCtrl);

homeCtrl.$inject = ['$scope', '$rootScope', '$location', 'ngDialog', 'DiretorService', '$filter'];
function homeCtrl($scope, $rootScope, $location, ngDialog, DiretorService, $filter) {

    $scope.escola = {};

    $scope.loadProfile = function () {


       DiretorService.getById($rootScope.repository.loggedUser.userid, completedLoad);
    }

    function completedLoad(result) {
        $scope.escola = result.data;
    }


};





