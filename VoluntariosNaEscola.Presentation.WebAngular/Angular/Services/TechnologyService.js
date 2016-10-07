
appDataBase.factory('TechnologyService', technologyService);

technologyService.$inject = ['AppService', '$http', '$cookieStore', '$rootScope'];

function technologyService(appService, $http, $cookieStore, $rootScope) {

    var service = {
        getAll: getAll,
        getById: getById,
        update: update,
        insert: insert,
        remove: remove
    }

    function getAll(completed) {
        var result = appService.get('technology/getall', null,
       completed,
       loadAllFalied);
        if (completed == undefined)
            return result;
    }

    function getById(id, completed) {
        appService.get('technology/getbyid/' + id, null,
        completed,
        loadSingleFalied);
    }

    function insert(entity, completed) {
        appService.post('technology/insert', entity,
        completed,
        insertFalied);
    }

    function update(entity, completed) {
        appService.post('technology/update', entity,
        completed,
        updateFalied);
    }

    function remove(id, completed) {
        appService.post('technology/remove/' + id, null,
        completed,
        removeFalied);
    }

    function removeFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar remover uma tecnologia', response.data.errors);
    }

    function updateFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar atualizar uma tecnologia', response.data.errors);
    }

    function insertFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar inserir uma tecnologia', response.data.errors);
    }

    function loadSingleFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar uma tecnologia', response.data.errors);
    }

    function loadAllFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar lista de tecnologias', response.data.errors);
    }

    return service;
}
