appDataBase.controller('HomeController', homeCtrl);

homeCtrl.$inject = ['$scope', '$rootScope', '$location', 'ngDialog', 'UsuarioService', '$filter'];
function homeCtrl($scope, $rootScope, $location, ngDialog, UsuarioService,  $filter) {

   
    $scope.loadProfile = function () {

        console.log($rootScope.repository.loggedUser);
        UsuarioService.getById($rootScope.repository.loggedUser.userid, completedLoad);
    }

    function completedLoad(result) {
        console.log(result);
    }


};





