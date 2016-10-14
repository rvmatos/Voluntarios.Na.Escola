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
            

            if ($rootScope.previousState)
                $location.path($rootScope.previousState);
            else {
                if ($scope.userData.isAdmin) {
                    $location.path('/');
                }
                else if($scope.userData.isVoluntario)
                {
                    $location.path('#/voluntario-home');
                }
                else $location.path('#/escola-home');
            }
        }
        else
            notificationService.displayError('Falha ao autenticar, tente novamente.');
    }
}
