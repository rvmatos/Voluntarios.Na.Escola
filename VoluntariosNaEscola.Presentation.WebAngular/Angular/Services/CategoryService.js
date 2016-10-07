
appDataBase.factory('CategoryService', categoryService);

categoryService.$inject = ['AppService', '$http', '$cookieStore', '$rootScope', 'NotificationService'];

function categoryService(appService, $http, $cookieStore, $rootScope, notificationService) {

    var service = {
        getAll: getAll,
        getById: getById,
        update: update,
        insert: insert,
        remove: remove
    }

    function getAll(completed) {
        var result = appService.get('category/getall', null,
        completed,
        loadAllFalied);
        if (completed == undefined)
            return result;
    }

    function getById(id, completed) {
        appService.get('category/getbyid/' + id, null,
        completed,
        loadSingleFalied);
    }

    function insert(entity, completed) {
        appService.post('category/insert', entity,
        completed,
        insertFalied);
    }

    function update(entity, completed) {
        appService.post('category/update', entity,
        completed,
        updateFalied);
    }

    function remove(id, completed) {
        appService.post('category/remove/' + id, null,
        completed,
        removeFalied);
    }


    function removeFalied(response) {
        
        notificationService.displayErrorWithTille('Falha ao tentar remover uma categoria', response.data.errors);
    }

    function updateFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar atualizar uma categoria', response.data.errors);
    }

    function insertFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar inserir uma categoria', response.data.errors);
    }

    function loadSingleFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar uma categoria', response.data.errors);
    }

    function loadAllFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar lista de categorias', response.data.errors);
    }

    return service;
}
