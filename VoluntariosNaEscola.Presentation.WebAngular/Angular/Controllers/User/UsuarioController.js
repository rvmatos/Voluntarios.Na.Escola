appDataBase.controller('UsuarioController', usuarioCtrl);

usuarioCtrl.$inject = ['$scope', 'UsuarioService', '$location', '$rootScope', '$cookieStore', 'ngDialog'];
function usuarioCtrl($scope, UsuarioService, $location, $rootScope, $cookieStore, ngDialog) {

    $scope.create = function (usuario) {
  
        console.log(usuario);
        UsuarioService.insert(usuario, completedchange);
        
    }

    function completedchange(result) {
        $location.path('/home');

    }

  
};
