appDataBase.controller('AdministradorHomeController', homeCtrl);

homeCtrl.$inject = ['$scope', '$rootScope', '$location', 'ngDialog', 'UsuarioService', 'EscolaService','VoluntarioService', 'DiretorService', '$filter'];
function homeCtrl($scope, $rootScope, $location, ngDialog, usuarioService, escolaService, voluntarioService, diretorService, $filter) {

    $scope.voluntarios = [];
    $scope.escolas = [];
    $scope.diretores = [];
    $scope.entity = {};



    $scope.loadInit = function () {
        diretorService.getAll(completedDiretorLoad);
        escolaService.getAll(completedEscolaLoad)
        voluntarioService.getAll(completedVoluntarioLoad)
        usuarioService.getById($rootScope.repository.loggedUser.userid, completedLoad)
    }

    

    $scope.AprovarDiretor = function (idDiretor) {
        diretorService.aprovarDiretor(idDiretor);
    }

    function completedLoad(result) {
        $scope.entity = result.data;
    }

    function completedDiretorLoad(result) {
        console.log('completedDiretorLoad', result.data);
        $scope.diretores = result.data;
    }

    function completedEscolaLoad(result) {
        console.log('completedEscolaLoad', result.data);
        $scope.escolas = result.data;
    }

    function completedVoluntarioLoad(result) {
        console.log('completedVoluntarioLoad', result.data);
        $scope.voluntarios = result.data;
    }

    $scope.loadInit();

};





