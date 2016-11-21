appDataBase.config(function ($routeProvider) {

});
appDataBase.config(config)
       .run(run);

function config($routeProvider, $httpProvider) {

    $httpProvider.interceptors.push('loadingStatusInterceptor');

    $routeProvider
        .when('/home', {
            templateUrl: './Views/Home.html',
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
             controller: 'SupervisorEditController'
         })
          .when('/supervisor/novo/:id', {
              templateUrl: './Views/Supervisor/New.html',
              controller: 'SupervisorNovoController'
          })

       
        //  .when('/project/view/:id', {
        //      templateUrl: './Views/Project.html',
        //      controller: 'ProjectViewController',
        //      resolve: { isAuthenticated: isAuthenticated }
        //  })
        //.when('/project/new', {
        //    templateUrl: './Views/Project.html',
        //    controller: 'ProjectAddController',
        //    resolve: { isAuthenticated: isAuthenticated }
        //})
        //.when('/categories',
        //{
        //    templateUrl: './Views/Category/Index.html',
        //    controller: 'CategoryController',
        //    resolve: { isAuthenticated: isAuthenticated }
        //})
        //.when('/categories/new', {
        //    templateUrl: './Views/Category/Edit.html',
        //    controller: 'CategoryAddController',
        //    resolve: { isAuthenticated: isAuthenticated }
        //})
        //.when('/categories/edit/:id', {
        //    templateUrl: './Views/Category/Edit.html',
        //    controller: 'CategoryEditController',
        //    resolve: { isAuthenticated: isAuthenticated }
        //})
        // .when('/groups',
        //{
        //    templateUrl: './Views/Group/Index.html',
        //    controller: 'GroupController',
        //    resolve: { isAuthenticated: isAuthenticated }
        //})
        //.when('/groups/new', {
        //    templateUrl: './Views/Group/Edit.html',
        //    controller: 'GroupAddController',
        //    resolve: { isAuthenticated: isAuthenticated }
        //})
        //.when('/groups/edit/:id', {
        //    templateUrl: './Views/Group/Edit.html',
        //    controller: 'GroupEditController',
        //    resolve: { isAuthenticated: isAuthenticated }
        //})
        // .when('/technologies',
        //{
        //    templateUrl: './Views/Technology/Index.html',
        //    controller: 'TechnologyController',
        //    resolve: { isAuthenticated: isAuthenticated }
        //})
        //.when('/technologies/new', {
        //    templateUrl: './Views/Technology/Edit.html',
        //    controller: 'TechnologyAddController',
        //    resolve: { isAuthenticated: isAuthenticated }
        //})
        //.when('/technologies/edit/:id', {
        //    templateUrl: './Views/Technology/Edit.html',
        //    controller: 'TechnologyEditController',
        //    resolve: { isAuthenticated: isAuthenticated }
        //})
        //  .when('/contacts',
        //{
        //    templateUrl: './Views/Contact/Index.html',
        //    controller: 'ContactController',
        //    resolve: { isAuthenticated: isAuthenticated }
        //})
        //.when('/contacts/new', {
        //    templateUrl: './Views/Contact/Edit.html',
        //    controller: 'ContactAddController',
        //    resolve: { isAuthenticated: isAuthenticated }
        //})
        //.when('/contacts/edit/:id', {
        //    templateUrl: './Views/Contact/Edit.html',
        //    controller: 'ContactEditController',
        //    resolve: { isAuthenticated: isAuthenticated }
        //})

     .otherwise({ redirectTo: '/home' });
}

run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

function run($rootScope, $location, $cookieStore, $http, $httpProvider) {
    $rootScope.repository = $cookieStore.get('repository') || {};

    if ($rootScope.repository.loggedUser) {
        $http.defaults.withCredentials = true;
        $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;

    }

}

isAuthenticated.$inject = ['MembershipService', '$rootScope', '$location'];

function isAuthenticated(membershipService, $rootScope, $location) {
    if (!membershipService.isUserLoggedIn()) {
        $rootScope.previousState = $location.path();
        $location.path('/login');
    }
}



