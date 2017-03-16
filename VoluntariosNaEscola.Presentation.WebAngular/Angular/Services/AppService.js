appDataBase.factory('AppService', appService);

appService.$inject = ['$http', 'Constants', '$location', '$rootScope', '$cookieStore', 'NotificationService'];

function appService($http, Constants, $location, $rootScope, $cookieStore, notificationService) {
    var service = {
        get: get,
        post: post,
        saveLoggin: saveLoggin
    };

    function saveLoggin(user)
    {
        $rootScope.repository = {};
        $rootScope.repository.isUserLoggedIn = true;

        $cookieStore.put('repository', $rootScope.repository);
    }

    function get(url, config, success, failure) {
        return $http.get(Constants.HostHttp + url, config)
                    .then(function (result) {
                        if (success == undefined)
                            return result;
                        success(result);
                    }, function (error) {
                        if (error.status == '401') {
                            notificationService.displayError('Authentication required.');
                            $rootScope.previousState = $location.path();
                            $location.path('/login');
                        }
                        else if (failure != null) {
                            failure(error);
                        }
                    });
    }

    function post(url, data, success, failure) {
        return $http.post(Constants.HostHttp + url, data)
                    .then(function (result) {
                        success(result);
                    }, function (error) {
                        if (error.status == '401') {
                            notificationService.displayError('Authentication required.');
                            $rootScope.previousState = $location.path();
                            $location.path('/login');
                        }
                        else if (failure != null) {
                            failure(error);
                        }
                    });
    }

    return service;
}
