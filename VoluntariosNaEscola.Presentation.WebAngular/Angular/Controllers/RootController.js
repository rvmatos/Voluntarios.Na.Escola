appDataBase.controller('RootController', rootCtrl);

rootCtrl.$inject = ['$scope', '$location', 'MembershipService', '$rootScope'];
function rootCtrl($scope, $location, membershipService, $rootScope) {
    $scope.pageClass = '';
    $scope.userData = {};

    $scope.userData.displayUserInfo = displayUserInfo;
    $scope.logout = logout;
    $scope.careUp = false;
    $scope.isAdmin =  $rootScope.repository.loggedUser != null && $rootScope.repository.loggedUser.isAdmin == 'True';

    function displayUserInfo() {
        $scope.userData.isUserLoggedIn = membershipService.isUserLoggedIn();

        if ($scope.userData.isUserLoggedIn)
            return $rootScope.repository.loggedUser.name;
    }

    function logout() {
        membershipService.removeCredentials();
        $location.path('#/');
        $scope.userData.displayUserInfo();
    }

    $scope.userData.displayUserInfo();
}
