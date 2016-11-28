appDataBase.controller('EventoNewController', homeCtrl);

homeCtrl.$inject = ['$scope', '$rootScope', '$location', 'ngDialog', 'EscolaService', 'EventoService', 'NotificationService', '$filter'];
function homeCtrl($scope, $rootScope, $location, ngDialog, EscolaService, eventoService, notificationService, $filter) {

    $scope.escola = { diretor: { aprovadores: [] } };
    $scope.userLogged = $rootScope.repository.loggedUser;
    $scope.evento = { acoes: [] };
    $scope.acao = {};

    $scope.loadProfile = function () {


        EscolaService.getByDiretor($rootScope.repository.loggedUser.userid, completedLoad);
    }

    function completedLoad(result) {

        $scope.escola = result.data;
        console.log($scope.escola);
    }

    $scope.addAcao = function(entity) {
        $scope.evento.acoes.push(entity);
        console.log($scope.evento);
        $scope.acao = {};
    }

    $scope.create = function (entity) {
        entity.idEscola = $scope.escola.id;
        console.log(entity);
        eventoService.insert(entity, completedInserted)
    }

    function completedInserted(result) {
        $location.path('/escola/home');
    }
    $scope.loadProfile();

};





