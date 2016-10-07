appDataBase.factory('loadingStatusInterceptor', function ($q, $rootScope) {
    var activeRequests = 0;
    var started = function() {
        if (activeRequests == 0) {         
            initLoading();
        }    
        activeRequests++;
    };
    var ended = function() {
        activeRequests--;
        if (activeRequests == 0) {
            hideLoading();           
        }
    };
    return {
        request: function(config) {
            started();
            return config || $q.when(config);
        },
        response: function(response) {
            ended();
            return response || $q.when(response);
        },
        responseError: function(rejection) {
            ended();
            return $q.reject(rejection);
        }
    };
});