﻿appDataBase.controller('EscolaHomeController', homeCtrl);

homeCtrl.$inject = ['$scope', '$rootScope', '$location', 'ngDialog', 'EscolaService', 'ConviteAprovacaoService', 'EventoService', 'NotificationService', '$filter'];
function homeCtrl($scope, $rootScope, $location, ngDialog, EscolaService, conviteAprovacaoService, eventoService, notificationService, $filter) {

    $scope.escola = { diretor: { aprovadores: [] } };
    $scope.userLogged = $rootScope.repository.loggedUser;
    $scope.convite = {};

    $scope.loadProfile = function () {


        EscolaService.getByDiretor($rootScope.repository.loggedUser.userid, completedLoad);
    }

    $scope.loadConvites = function (idDiretor) {

        conviteAprovacaoService.getConvitesBy(idDiretor, completedLoadConvites);

    }

    $scope.ReenviarConvite = function (convite) {
        conviteAprovacaoService.reenviarConvite(convite.id, reenviarSuccess);
    }

    $scope.ExcluirConvite = function (convite) {
        conviteAprovacaoService.remove(convite.id, excluirSuccess);
    }

    $scope.addConvite = function () {


        var convite = { nome: $scope.convite.nome, email: $scope.convite.email, idDiretor: $scope.escola.idDiretor };

        conviteAprovacaoService.insert(convite, insertCompleted);

        $scope.convite = {};
    }

    $scope.GetQtdEmAberto = function (aprovadores) {
        var qtd = 0;
        $.each(aprovadores, function (index, entity) {
            if (!entity.conviteAceito)
                qtd++;
        });
        console.log(aprovadores);
        return qtd;
    }

    $scope.GetQtdAprovados = function (aprovadores) {
        var qtd = 0;
        $.each(aprovadores, function (index, entity) {
            if (entity.diretorAprovado)
                qtd++;
        });
        console.log(aprovadores);
        return qtd;
    }

    $scope.PermiteReenviar = function (convite) {

        if (convite.dtEnvio != null) {
            var d1 = new Date();
            var d2 = getDate(convite.dtEnvio);
            d2.setHours(d2.getHours() + 1);


            if (d1 > d2)
                return true;
        }
        else if (convite.dtAceite == null) {
            return true;
        }
        return false;
    }

    function getDate(dateDotNet) {

        if (dateDotNet && dateDotNet != null) {
            var date = dateDotNet.split('T')[0];
            var time = dateDotNet.split('T')[1].split('.')[0];

            var resultDate = new Date(date.split('-')[0], date.split('-')[1] - 1, date.split('-')[2], time.split(':')[0], time.split(':')[1], time.split(':')[2], 0);
            return resultDate;
        }
        return null;
    }

    function insertCompleted(result) {
        $scope.loadConvites($scope.escola.idDiretor);
    }

    function completedLoad(result) {

        $scope.escola = result.data;
        console.log('completedLoad', result.data);
        $scope.loadConvites($scope.escola.idDiretor);
        eventoService.getByIdEscola($scope.escola.id, function (result) { $scope.escola.eventos = result.data; })
    }

    function completedLoadConvites(result) {
        $scope.escola.diretor.aprovadores = result.data;

    }
    function excluirSuccess() {
        notificationService.displaySuccess('Convite excluido com sucesso.');
        $scope.loadConvites($scope.escola.idDiretor);
    }

    function reenviarSuccess(result) {

        notificationService.displaySuccess('Email reeenviado com sucesso.');
        $scope.loadConvites(result.data.model.idDiretor);
    }

};





