 
appDataBase.factory('MembershipService', membershipService);

membershipService.$inject = ['AppService', 'Constants', '$http', '$cookieStore', '$rootScope', 'NotificationService'];

function membershipService(apiService, Constants, $http, $cookieStore, $rootScope, notificationService) {

    var service = {
        login: login,
        saveCredentials: saveCredentials,
        removeCredentials: removeCredentials,
        isUserLoggedIn: isUserLoggedIn
    }

    function login(userlogin, completed) {

        $http({
            url: Constants.HostHttp + 'security/TOKEN',
            method: "POST",
            data: $.param({ grant_type: 'password', username: userlogin.username, password: userlogin.password }),
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(completed, loginFailed);


    }

    function saveCredentials(data) {
        var membershipData = data.access_token;

        $rootScope.repository = {
            loggedUser: {
                username: data.username,
                userid: data.userid,
                name: data.name,
                isAdmin: data.isAdmin,
                isSupervisor: data.isSupervisor,
                isDiretor: data.isDiretor,
                isVoluntario: data.isVoluntario,
                authdata: membershipData
            }
        };
        $http.defaults.headers.common['Authorization'] = 'Bearer ' + membershipData;
        $cookieStore.put('repository', $rootScope.repository);
    }

    function removeCredentials() {
        $rootScope.repository = {};
        $cookieStore.remove('repository');
        $http.defaults.headers.common.Authorization = '';
    };

    function loginFailed(response) {
        notificationService.displayError("Falha ao autenticar. Por favor, tente novamente.");
    }

    function isUserLoggedIn() {
        return $rootScope.repository.loggedUser != null;
    }

    return service;
}
