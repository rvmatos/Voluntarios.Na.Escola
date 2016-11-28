appDataBase.config(function ($routeProvider) {

});
appDataBase.config(config)
       .run(run);

function config($routeProvider, $httpProvider) {
 
    $httpProvider.interceptors.push('loadingStatusInterceptor');
    $httpProvider.defaults.useXDomain = true;
    delete $httpProvider.defaults.headers.common['X-Requested-With'];
    $routeProvider
        .when('/home', {
            templateUrl: './Views/Blank.html',
            controller: 'HomeController',
            resolve: { isAuthenticated: isAuthenticated }
        })
        .when('/login', {
            templateUrl: './Views/Auth/Login.html',
            controller: 'LoginController'
        })
         .when('/cadastre-se',
        {
            templateUrl: './Views/Auth/Register.html',
            controller: 'UsuarioController'
        })
        .when('/admin/home',
        {
            templateUrl: './Views/Administrador/Index.html',
            controller: 'AdministradorHomeController',
            resolve: { isAuthenticated: isAuthenticated }
        })
        .when('/admin/edit/:id', {
            templateUrl: './Views/Administrador/Edit.html',
            controller: 'AdministradorEditController',
            resolve: { isAuthenticated: isAuthenticated }
        })
        .when('/voluntario/home',
        {
            templateUrl: './Views/Voluntario/Index.html',
            controller: 'VoluntarioHomeController',
            resolve: { isAuthenticated: isAuthenticated }
        })
        .when('/voluntario/edit/:id', {
            templateUrl: './Views/Voluntario/Edit.html',
            controller: 'VoluntarioEditController',
            resolve: { isAuthenticated: isAuthenticated }
        })
         .when('/escola/home',
        {
            templateUrl: './Views/Escola/Index.html',
            controller: 'EscolaHomeController',
            resolve: { isAuthenticated: isAuthenticated }
        })
        .when('/escola/edit/:id', {
            templateUrl: './Views/Escola/Edit.html',
            controller: 'EscolaEditController',
            resolve: { isAuthenticated: isAuthenticated }
        })
         .when('/supervisor/home', {
             templateUrl: './Views/Supervisor/Index.html',
             controller: 'SupervisorHomeController'
         })
         .when('/supervisor/edit/:id', {
             templateUrl: './Views/Supervisor/New.html',
             controller: 'SupervisorEditController',
             resolve: { isAuthenticated: isAuthenticated }
         })
          .when('/supervisor/novo/:id', {
              templateUrl: './Views/Supervisor/New.html',
              controller: 'SupervisorNovoController',
              resolve: { isAuthenticated: isAuthenticated }
          })
        .when('/evento/novo/:id', {
            templateUrl: './Views/Evento/New.html',
            controller: 'EventoNewController',
            resolve: { isAuthenticated: isAuthenticated }
        })
        .when('/evento/edit/:id', {
            templateUrl: './Views/Evento/Edit.html',
            controller: 'EventoEditController',
            resolve: { isAuthenticated: isAuthenticated }
        })

     .otherwise({ redirectTo: '/home' });
}

run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

function run($rootScope, $location, $cookieStore, $http, $httpProvider) {
    $rootScope.repository = $cookieStore.get('repository') || {};

    if ($rootScope.repository.loggedUser) {
        $http.defaults.withCredentials = true;
        $http.defaults.headers.common['Authorization'] = 'Bearer ' + $rootScope.repository.loggedUser.authdata;

    }

}

isAuthenticated.$inject = ['MembershipService', '$rootScope', '$location'];

function isAuthenticated(membershipService, $rootScope, $location) {
    if (!membershipService.isUserLoggedIn()) {
        $rootScope.previousState = $location.path();
        $location.path('/login');
    }
}



