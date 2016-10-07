appDataBase.controller('HomeController', homeCtrl);

homeCtrl.$inject = ['$scope', '$rootScope', '$location', 'ngDialog', 'ProjectService', 'CategoryService', '$filter'];
function homeCtrl($scope, $rootScope, $location, ngDialog, ProjectService, CategoryService, $filter) {

    $scope.listProjects = [];
    $scope.pager = {};

    $scope.delete = function (project) {
        $scope.project = project;

        $scope.name = project.name;

        $scope.domain = "o projeto";

        $scope.callback = function () {
            $scope.setPage(1);
        };

        ngDialog.open({
            template: './Views/Modal/_Delete.html',
            controller: 'HomeController',
            className: 'ngdialog-theme-default',
            scope: $scope
        });
    }

    $scope.confirmDelete = function () {
        ProjectService.remove($scope.project.id, completed);
    }

    function completed(result) {
        ngDialog.closeAll();
        if ($scope.callback) {
            $scope.callback();
        }
    }

    $scope.close = function () {
        ngDialog.closeAll();
    }

    $scope.loadDataCategory = function () {

        var result2 = CategoryService.getAll();

        result2.then(function (object) {
            $scope.listCategory = object.data;
        });
    }

    $scope.loadDataCategory();

    $scope.search = function (pesq) {

        if (pesq == undefined || pesq == null)
            $scope.setPage(1);
        else {

            var name = "";
            var description = "";
            var category = "";

            if (pesq.name != null)
                name = pesq.name;

            if (pesq.description != null)
                description = pesq.description;

            if (pesq.category != null)
                category = pesq.category;

            if (name == "" && description == "" && category == "")
                $scope.setPage(1);
            else
                $scope.listProjects = $filter('filter')($scope.listProjects, pesq);
        }
    }

    $scope.clear = function () {
        $scope.pesq = null;
    }

    $scope.setPage = function (page) {

        if (page < 1 || page > $scope.pager.totalPages) {
            return;
        }

        var result = ProjectService.getAll();

        result.then(function (object) {
            $scope.listProjects = object.data;

            $scope.pager = $scope.getPager($scope.listProjects.length, page);

            $scope.items = $scope.listProjects.slice($scope.pager.startIndex, $scope.pager.endIndex);
        });
    }

    $scope.getPager = function (totalItems, currentPage, pageSize) {

        currentPage = currentPage || 1;

        pageSize = pageSize || 9;

        var totalPages = Math.ceil(totalItems / pageSize);

        var startPage, endPage;
        if (totalPages <= 10) {
            // less than 10 total pages so show all
            startPage = 1;
            endPage = totalPages;
        } else {
            // more than 10 total pages so calculate start and end pages
            if (currentPage <= 6) {
                startPage = 1;
                endPage = 10;
            } else if (currentPage + 4 >= totalPages) {
                startPage = totalPages - 9;
                endPage = totalPages;
            } else {
                startPage = currentPage - 5;
                endPage = currentPage + 4;
            }
        }

        var startIndex = (currentPage - 1) * pageSize;
        var endIndex = startIndex + pageSize;

        var pages = _.range(startPage, endPage + 1);

        return {
            totalItems: totalItems,
            currentPage: currentPage,
            pageSize: pageSize,
            totalPages: totalPages,
            startPage: startPage,
            endPage: endPage,
            startIndex: startIndex,
            endIndex: endIndex,
            pages: pages
        };
    }
};





