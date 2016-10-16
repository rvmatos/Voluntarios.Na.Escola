appDataBase.controller('EscolaHomeController', homeCtrl);

homeCtrl.$inject = ['$scope', '$rootScope', '$location', 'ngDialog', 'EscolaService', '$filter'];
function homeCtrl($scope, $rootScope, $location, ngDialog, EscolaService, $filter) {

    $scope.escola = {};

    $scope.loadProfile = function () {


        EscolaService.getByDiretor($rootScope.repository.loggedUser.userid, completedLoad);
    }

    function completedLoad(result) {
        console.log(result);
        $scope.escola = result.data;
    }


};





