appDataBase.controller('EscolaHomeController', homeCtrl);

homeCtrl.$inject = ['$scope', '$rootScope', '$location', 'ngDialog', 'EscolaService', 'ConviteAprovacaoService', 'NotificationService', '$filter'];
function homeCtrl($scope, $rootScope, $location, ngDialog, EscolaService, conviteAprovacaoService, notificationService, $filter) {

    $scope.escola = { diretor: { aprovadores: [] } };

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
        console.log($scope);

        var convite = { nome: $scope.convite.nome, email: $scope.convite.email, idDiretor: $scope.escola.idDiretor };

        conviteAprovacaoService.insert(convite, insertCompleted);

        $scope.convite = {};
    }
    $scope.PermiteReenviar = function (convite) {

        if (convite.dtEnvio != null) {
            var d1 = new Date();
            var d2 = getDate(convite.dtEnvio);           
            d2.setHours(d2.getHours() + 1);
            console.log(d1, d2);

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
        $scope.loadConvites($scope.escola.idDiretor);
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





