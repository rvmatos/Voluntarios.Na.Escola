﻿appDataBase.controller('AprovadorHomeController', homeCtrl);

homeCtrl.$inject = ['$scope', '$rootScope', '$location', 'ngDialog', 'SupervisorService', 'EscolaService', '$filter'];
function homeCtrl($scope, $rootScope, $location, ngDialog, SupervisorService, escolaService, $filter) {

    $scope.voluntario = {};
    $scope.escolas = [];


    $scope.loadProfile = function () {


        SupervisorService.getById($rootScope.repository.loggedUser.userid, completedLoad);
    }

    $scope.loadEscolas = function () {
        escolaService.getAll(completedEscolaLoad);
    }

    function completedLoad(result) {
        console.log(result);
        $scope.voluntario = result.data;
    }

    function completedEscolaLoad(result) {
        $scope.escolas = result.data;
    }



};





