appDataBase.controller('VoluntarioHomeController', homeCtrl);

homeCtrl.$inject = ['$scope', '$rootScope', '$location', 'ngDialog', 'VoluntarioService', '$filter'];
function homeCtrl($scope, $rootScope, $location, ngDialog, VoluntarioService, $filter) {


    $scope.loadProfile = function () {

        console.log($rootScope.repository.loggedUser);
        VoluntarioService.getById($rootScope.repository.loggedUser.userid, completedLoad);
    }

    function completedLoad(result) {
        console.log(result);
    }


};





