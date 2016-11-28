appDataBase.controller('VoluntarioHomeController', homeCtrl);

homeCtrl.$inject = ['$scope', '$rootScope', '$location', 'ngDialog', 'VoluntarioService', 'EscolaService', '$filter'];
function homeCtrl($scope, $rootScope, $location, ngDialog, VoluntarioService, escolaService, $filter) {

    $scope.voluntario = {};
    $scope.escolas = [];


    $scope.loadProfile = function () {


        VoluntarioService.getById($rootScope.repository.loggedUser.userid, completedLoad);
    }

    $scope.loadEscolas = function () {
        escolaService.getAll(completedEscolaLoad);
    }
    $scope.VincularEscola = function (idEscola, idVoluntario) {
        console.log('VincularEscola', idEscola, idVoluntario);

        VoluntarioService.vincularEscola(idEscola, idVoluntario);
    }

    $scope.GetVinculadasEscolas = function (escolasElegivel, escolasEleitas) {
        console.log(escolasElegivel, escolasEleitas);
        var result = [];
        if (escolasEleitas.length > 0) {
            escolasElegivel.forEach(function (elegivel) {
                var achou = false;
                escolasEleitas.forEach(function (eleita) {
                    if (eleita.id == elegivel.id) {
                        achou = true;
                    }
                });
                if (!achou)
                    result.push(elegivel);
            });
        }
        else return escolasElegivel;



        return result;
    }

    function completedLoad(result) {
        console.log(result);
        $scope.voluntario = result.data;
        $scope.loadEscolas();
    }

    function completedEscolaLoad(result) {
        $scope.escolas = $scope.GetVinculadasEscolas(result.data, $scope.voluntario.escolas);
    }
    
    $scope.loadProfile();
   

};





