appDataBase.controller('EventoEditController', homeCtrl);

homeCtrl.$inject = ['$scope', '$rootScope', '$location', 'ngDialog', 'EscolaService', 'EventoService', 'NotificationService', '$filter'];
function homeCtrl($scope, $rootScope, $location, ngDialog, EscolaService, eventoService, notificationService, $filter) {

    $scope.escola = { diretor: { aprovadores: [] } };
    $scope.userLogged = $rootScope.repository.loggedUser;
    $scope.evento = {};

    $scope.loadProfile = function () {


        EscolaService.getByDiretor($rootScope.repository.loggedUser.userid, completedLoad);
    }

    function completedLoad(result) {

        $scope.escola = result.data;
        console.log($scope.escola);
    }


    $scope.loadProfile();

};





