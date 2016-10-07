appDataBase.controller('ProjectAddController', projectCtrl);

projectCtrl.$inject = ['$scope', '$location', 'Constants', '$rootScope', '$cookieStore', 'ngDialog', 'ProjectService', 'GroupService', 'CategoryService', 'TechnologyService', 'ContactService'];
function projectCtrl($scope, $location, Constants, $rootScope, $cookieStore, ngDialog, ProjectService, GroupService, CategoryService, TechnologyService, contactService) {

    $scope.action = 'I';
    $scope.disableInput = false;
    $scope.project = { files: [], "eIdiom": "", "eLevel": "", "Group": "", "Category": "", "eCriticality": "", "Technology": "", "eDevelopmentType": "0" };

    $scope.validSubmitted = false;

    $scope.listDevelopmentType = Constants.DevelopmentType;
    $scope.project.eDevelopmentType = $scope.listDevelopmentType[0];

    $scope.listCriticality = Constants.Criticality;
    $scope.project.eCriticality = $scope.listCriticality[0];

    $scope.listIdiom = Constants.Idiom;
    $scope.project.eIdiom = $scope.listIdiom[0];

    $scope.listLevel = Constants.Level;
    $scope.project.eLevel = $scope.listLevel[0];

    $scope.loadDataContact = function () {

        var result4 = contactService.getAll();

        result4.then(function (object) {
            $scope.contacts = object.data;
        });
    }

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

    $scope.loadDataContact();
    $scope.loadDataGroup();
    $scope.loadDataCategory();
    $scope.loadDataTechnology();


    $scope.save = function (form) {

        if ($scope.project.eDevelopmentType.id == 0)
            form.dropDevelopmentTypes.$modelValue.id = "";

        if (form.$valid) {

            if ($scope.project.eIdiom != "")
                $scope.project.idiom = $scope.project.eIdiom.id
            if ($scope.project.eDevelopmentType != "")
                $scope.project.developmentType = $scope.project.eDevelopmentType.id;
            if ($scope.project.eCriticality != "")
                $scope.project.criticality = $scope.project.eCriticality.id;
            if ($scope.project.eLevel != "")
                $scope.project.level = $scope.project.eLevel.id;

            ProjectService.insert($scope.project, completedchange);
        }
    }

    function completedchange(result) {
        $location.path('/home');

    }

    $scope.openModalUser = function () {

        ngDialog.open({
            template: './Views/Contact/Edit.html',
            controller: 'ModalContactAddController',
            className: 'ngdialog-theme-default',
            scope: $scope
        });
    }

    $scope.openModalGroup = function () {

        ngDialog.open({
            template: './Views/Group/Edit.html',
            controller: 'ModalGroupAddController',
            className: 'ngdialog-theme-default',
            scope: $scope
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
            template: './Views/Modal/UploadFiles.html',
            controller: 'UploadController',
            className: 'ngdialog-theme-default contentImportFile',
            scope: $scope,
            closeByDocument: false
        });
    }
}