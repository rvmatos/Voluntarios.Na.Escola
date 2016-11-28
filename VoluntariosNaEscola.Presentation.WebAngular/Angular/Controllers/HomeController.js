appDataBase.controller('HomeController', homeCtrl);

homeCtrl.$inject = ['$scope', '$rootScope', '$location', 'ngDialog', 'UsuarioService', '$filter'];
function homeCtrl($scope, $rootScope, $location, ngDialog, UsuarioService,  $filter) {

   
    $scope.loadProfile = function () {

        var userLogged = $rootScope.repository.loggedUser;

        if (userLogged.isAdmin == 'True') {
            console.log(result.data.isVoluntario, result.data.isAdmin);
            $location.path('/admin/home');
        }
        else if (userLogged.isVoluntario == 'True') {
            console.log('isVoluntario');
            $location.path('/voluntario/home');
        }
        else if (userLogged.isSupervisor == 'True') {
            console.log('supervisor/home');
        }
        else if (userLogged.isDiretor) {
            console.log("escola/home");
            $location.path('/escola/home');

        } else {
            $location.path('/login');
        }
    }

    $scope.loadProfile();

};





