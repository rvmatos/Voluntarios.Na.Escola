appDataBase.controller('LoginController', loginCtrl);

loginCtrl.$inject = ['$scope', 'MembershipService', '$rootScope', '$location', 'NotificationService'];

function loginCtrl($scope, membershipService, $rootScope, $location, notificationService) {
    $scope.pageClass = 'login';
    $scope.validSubmitted = false;
    $scope.login = login;
    $scope.user = {};
    
    function login(form) {

        if (form.$valid) {
            $scope.validSubmitted = false;
            membershipService.login($scope.user, loginCompleted);
        }
        else $scope.validSubmitted = true;
    }

    function loginCompleted(result) {

        if (result.data) {
            $scope.user.nome = result.data.username;
            membershipService.saveCredentials(result.data);
            $scope.userData.displayUserInfo();
            console.log(result.data.isVoluntario, result.data.isAdmin);
            
            if (result.data.isAdmin == 'True') {
                $location.path('/');
            }
            else if (result.data.isVoluntario == 'True') {
                console.log('isVoluntario');
                $location.path('/voluntario-home');
            }
            else $location.path('/escola-home');


        }
        else
            notificationService.displayError('Falha ao autenticar, tente novamente.');
    }
}
