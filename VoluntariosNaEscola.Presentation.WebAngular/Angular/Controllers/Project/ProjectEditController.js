appDataBase.controller('ProjectEditController', projectCtrl);

projectCtrl.$inject = ['$scope', '$location', 'Constants', '$routeParams', '$rootScope', '$cookieStore', 'ProjectService', 'GroupService', 'CategoryService', 'TechnologyService', 'ContactService', 'ngDialog'];
function projectCtrl($scope, $location, Constants, $routeParams, $rootScope, $cookieStore, ProjectService, GroupService, CategoryService, TechnologyService, contactService, ngDialog) {
    $scope.project = { files: [], "eIdiom": "", "eLevel": "", "Group": "", "Category": "", "eCriticality": "", "Technology": "", "eDevelopmentType": "" };
    $scope.action = 'U';
    $scope.id = $routeParams.id;
    $scope.disableInput = false;
    $scope.uploadGuid = '';

    function loadData() {

        ProjectService.getById($scope.id, completed);

        $scope.loadDataGroup();
        $scope.loadDataCategory();
        $scope.loadDataTechnology();
        $scope.loadDataContact();
    }

    function completed(result) {
        $scope.project = result.data;
        $scope.project.eIdiom = $scope.listIdiom[$scope.project.idiom];
        $scope.project.eDevelopmentType = $scope.listDevelopmentType[$scope.project.developmentType];
        $scope.project.eCriticality = $scope.listCriticality[$scope.project.criticality];
        $scope.project.eLevel = $scope.listLevel[$scope.project.level];
        $scope.project.situation = $scope.listSituation[$scope.project.situation];
        $scope.project.group = { id: $scope.project.idGroup };
        $scope.project.technology = { id: $scope.project.idTechnology };
        $scope.project.category = { id: $scope.project.idCategory };
        console.log(result.data);
        console.log($scope.project);
    }

    $scope.listDevelopmentType = Constants.DevelopmentType;

    $scope.listCriticality = Constants.Criticality;

    $scope.listIdiom = Constants.Idiom;

    $scope.listLevel = Constants.Level;

    $scope.listSituation = Constants.Situation;

    $scope.loadDataGroup = function () {
        var result = GroupService.getAll();

        result.then(function (object) {
            $scope.listGroup = object.data;
        });
    }

    $scope.loadDataCategory = function () {

        var result2 = CategoryService.getAll();

        result2.then(function (object) {
            $scope.listCategory = object.data;
        });
    }


    $scope.loadDataTechnology = function () {

        var result3 = TechnologyService.getAll();

        result3.then(function (object) {
            $scope.listTechnology = object.data;
        });
    }

    $scope.loadDataContact = function () {

        var result4 = contactService.getAll();

        result4.then(function (object) {
            $scope.contacts = object.data;
            object.data.forEach(function (contact) {
                if (contact.id == $scope.project.idKeyUser)
                    $scope.project.keyUser = contact;
                if (contact.id == $scope.project.idTechnicalResponsible)
                    $scope.project.technicalResponsible = contact;
            });
        });

    }

    $scope.save = function (form) {

        if ($scope.project.eDevelopmentType.id == 0)
            form.dropDevelopmentTypes.$modelValue.id = "";

        if (form.$valid) {
            console.log($scope.project);
            $scope.project.idiom = $scope.project.eIdiom.id;
            $scope.project.developmentType = $scope.project.eDevelopmentType.id;
            $scope.project.criticality = $scope.project.eCriticality.id;
            $scope.project.level = $scope.project.eLevel.id;
            $scope.project.idCategory = $scope.project.category.id;
            $scope.project.idGroup = $scope.project.group.id;
            $scope.project.idTechnology = $scope.project.technology.id;
            $scope.project.idKeyUser = $scope.project.keyUser == undefined ? null : $scope.project.keyUser.id;
            $scope.project.idTechnicalResponsible = $scope.project.technicalResponsible == undefined ? null : $scope.project.technicalResponsible.id;
            $scope.project.group = null;
            $scope.project.category = null;
            $scope.project.technology = null;
            $scope.project.keyUser = null;
            $scope.project.technicalResponsible = null;
            $scope.project.eIdiom = null;
            $scope.project.eDevelopmentType = null;
            $scope.project.eCriticality = null;
            $scope.project.eLevel = null;
            $scope.project.situation = null;
            ProjectService.update($scope.project, completedchange);
        }
    }

    function completedchange(result) {
        $location.path('/home');

    }

    $scope.userKeySelectedFn9 = function (selected) {
        if (selected) {
            $scope.project.keyUser = selected.originalObject;
            $scope.project.idKeyUser = selected.originalObject.id;
        } else 
            $scope.project.keyUser = null;
            }

    $scope.technicalResponsibleSelectedFn9 = function (selected) {
        if (selected) {
            $scope.project.technicalResponsible = selected.originalObject;
            $scope.project.idTechnicalResponsible = selected.originalObject.id;
        } else 
            $scope.project.keyUser = null;
            }
    
    $scope.openModalUser = function () {

        ngDialog.open({
            template: './Views/Contact/Edit.html',
            controller: 'ModalContactAddController',
            className: 'ngdialog-theme-default',
            scope: $scope,
            cache: false
        });

    }

    $scope.openModalGroup = function () {

        ngDialog.open({
            template: './Views/Group/Edit.html?id=905',
            controller: 'ModalGroupAddController',
            className: 'ngdialog-theme-default',
            scope: $scope,
            cache: false
        });
    }


    $scope.openModalCategory = function () {

        ngDialog.open({
            template: './Views/Category/Edit.html',
            controller: 'ModalCategoryAddController',
            className: 'ngdialog-theme-default',
            scope: $scope
        });
    }

    $scope.openModalTechnology = function () {

        ngDialog.open({
            template: './Views/Technology/Edit.html',
            controller: 'ModalTechnologyAddController',
            className: 'ngdialog-theme-default',
            scope: $scope
        });
    }

    $scope.opentModalImportFile = function () {
        ngDialog.open({
            template: './Views/Modal/UploadFiles.html?id=12',
            controller: 'UploadController',
            className: 'ngdialog-theme-default contentImportFile',
            scope: $scope,
            closeByDocument: false
        });
    }

    loadData();
}