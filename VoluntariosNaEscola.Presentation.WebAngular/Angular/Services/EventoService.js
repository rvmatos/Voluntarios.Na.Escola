appDataBase.factory('EventoService', eventoService);

eventoService.$inject = ['AppService', '$http', '$cookieStore', '$rootScope', 'NotificationService'];

function eventoService(appService, $http, $cookieStore, $rootScope, notificationService) {

    var service = {
        getAll: getAll,
        getById: getById,
        insert: insert,
        update: update,
        remove: remove,
        getByIdEscola: getByIdEscola
    }

    function getAll(completed) {
        var result = appService.get('eventos/getall', null,
         completed,
         loadAllFalied);
        if (completed == undefined)
            return result;

    }

    function getById(id, completed) {
        appService.get('eventos/get/' + id, null,
        completed,
        loadSingleFalied);
    }

    function insert(entity, completed) {
        var url = 'eventos/add';
        appService.post(url, entity,
        completed,
        insertFalied);
    }

    function update(entity, completed) {
        console.log('update', entity);
        appService.post('eventos/update', entity,
        completed,
        updateFalied);
    }

    function remove(id, completed) {
        appService.post('eventos/delete/' + id, null,
        completed,
        removeFalied);
    }

    function getByIdEscola(id, completed) {
        appService.get('eventos/getByIdEscola/' + id, null, completed, loadAllFalied);
    }

    function removeFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar remover um evento', response.data.errors);
    }

    function updateFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar atualizar um evento', response.data.errors);
    }

    function insertFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar inserir uma evento', response.data.errors);
    }

    function loadSingleFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar um diretor(a)', response.data.errors);
    }

    function loadAllFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar lista de eventos', response.data.errors);
    }

    return service;
}
