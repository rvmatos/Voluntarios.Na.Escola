appDataBase.controller('UsuarioController', usuarioCtrl);

usuarioCtrl.$inject = ['$scope', 'UsuarioService', '$location', '$rootScope', '$cookieStore', 'ngDialog'];
function usuarioCtrl($scope, UsuarioService, $location, $rootScope, $cookieStore, ngDialog) {

    $scope.create = function (usuario) {
  
        console.log(usuario);
        if (usuario.isVoluntario)
        {
            UsuarioService.insert(usuario, completedchange);
        }
        else {
            var entity = {
                nome: usuario.nomeEscola,
                endereco: usuario.endereco,
                diretor: {
                    nome: usuario.nomeDiretor,
                    apelido: usuario.apelido,
                    senha: usuario.senha,
                    telefone: usuario.telefone,
                    email: usuario.email
                }
            };
            UsuarioService.insert(entity, completedchange);
        }
        
    }

    function completedchange(result) {
        $location.path('/home');

    }

  
};
