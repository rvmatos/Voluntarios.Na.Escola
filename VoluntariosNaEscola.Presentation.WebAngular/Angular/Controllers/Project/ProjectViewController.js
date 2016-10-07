appDataBase.controller('ProjectViewController', projectViewCtrl);

projectViewCtrl.$inject = ['$scope', 'Constants', '$location', '$routeParams', '$rootScope', '$cookieStore', 'ProjectService', 'GroupService', 'CategoryService', 'TechnologyService', 'ContactService', 'ngDialog'];
function projectViewCtrl($scope, Constants, $location, $routeParams, $rootScope, $cookieStore, ProjectService, GroupService, CategoryService, TechnologyService, contactService, ngDialog) {

    $scope.action = 'V';
    $scope.id = $routeParams.id;
    $scope.disableInput = true;

    $scope.listDevelopmentType = Constants.DevelopmentType;

    $scope.listCriticality = Constants.Criticality;

    $scope.listIdiom = Constants.Idiom;

    $scope.listLevel = Constants.Level;

    $scope.listSituation = Constants.Situation;


    ProjectService.getById($scope.id, completed);
    GroupService.getAll(completedLoadGroup);
    CategoryService.getAll(completedLoadCategory);
    TechnologyService.getAll(completedLoadTechnology);

    contactService.getAll(completedLoadContact);


    $scope.opentModalImportFile = function () {
        ngDialog.open({
            template: './Views/Modal/UploadFiles.html?id=12',
            controller: 'UploadController',
            className: 'ngdialog-theme-default contentImportFile',
            scope: $scope,
            closeByDocument: false
        });
    }

    function completed(result) {
        $scope.project = result.data;
        $scope.project.eIdiom = $scope.listIdiom[$scope.project.idiom];
        $scope.project.eDevelopmentType = $scope.listDevelopmentType[$scope.project.developmentType];
        $scope.project.eCriticality = $scope.listCriticality[$scope.project.criticality];
        $scope.project.eLevel = $scope.listLevel[$scope.project.level];
        $scope.project.group = { id: $scope.project.idGroup };
        $scope.project.technology = { id: $scope.project.idTechnology };
        $scope.project.category = { id: $scope.project.idCategory };
    }

    function completedchange(result) {
        $location.path('/home');

    }

    function completedLoadTechnology(object) {
        $scope.listTechnology = object.data;
    }

    function completedLoadCategory(object) {
        $scope.listCategory = object.data;
    }

    function completedLoadGroup(object) {
        $scope.listGroup = object.data;
    }

    function completedLoadContact(object) {
        $scope.names = object.data;
        $scope.resp = object.data;
    }
}