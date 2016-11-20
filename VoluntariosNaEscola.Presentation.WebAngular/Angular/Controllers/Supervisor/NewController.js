appDataBase.controller('SupervisorNovoController', homeCtrl);

homeCtrl.$inject = ['$scope', '$routeParams', '$rootScope', '$location', 'ngDialog', 'SupervisorService', 'ConviteAprovacaoService', '$filter', 'NotificationService'];
function homeCtrl($scope, $routeParams, $rootScope, $location, ngDialog, supervisorService, conviteAprovacaoService, $filter, notificationService) {

    $scope.entity = {};
    $scope.id = $routeParams.id;
    $scope.aprovado = false;
    $scope.aprovador = {
        nome: '',
        email: ''
    };
    $scope.loadEntity = function () {
        console.log($routeParams);
        console.log($scope.id);
        conviteAprovacaoService.getByGuid($scope.id, completedLoad);
    }

   
    function completedLoad(result) {
        console.log(result);
        if (result.data.conviteAceito)
        {
            notificationService.displaySuccess('Sua opinião já foi registrada, continue seu cadastro.');
            $scope.aprovado = result.data.conviteAceito;
        }
        $scope.entity = result.data;
        $scope.aprovador.nome = $scope.entity.nome;
        $scope.aprovador.email = $scope.entity.email;


    }

    $scope.Aprovar = function (entity) {
        entity.diretorAprovado = true;
        entity.conviteAceito = true;
        entity.dtAceite = new Date();
        conviteAprovacaoService.update(entity, aprovarEvento);
        console.log(entity);
    }

    $scope.Save = function (aprovador) {
        if (($('#frmEditvoluntarios').parsley().isValid()))
        {
            supervisorService.insert(aprovador, completedInsert);
            
        }
        console.log(aprovador);
    }

    $scope.Reprovar = function (entity) {
        entity.diretorAprovado = false;
        entity.conviteAceito = true;
        conviteAprovacaoService.update(entity, function () {
            notificationService.displaySuccess('Sua opinião foi registrada com sucesso, continue seu cadastro.');
            $location.path('#/login');
        });
        console.log(entity);
        console.log(entity);
    }

    function aprovarEvento(result) {
        notificationService.displaySuccess('Sua opinião foi registrada com sucesso, continue seu cadastro.');
    }

    function completedInsert(result) {
        notificationService.displaySuccess('Cadastro realizado com sucesso.');
        $location.path('#/login');
    }

    $scope.loadEntity();


};





