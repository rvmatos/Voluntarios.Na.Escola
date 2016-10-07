
appDataBase.factory('ContactService', contactService);

contactService.$inject = ['AppService', '$http', '$cookieStore', '$rootScope', 'NotificationService'];

function contactService(appService, $http, $cookieStore, $rootScope, notificationService) {

    var service = {
        getAll: getAll,
        getById: getById,
        update: update,
        insert: insert,
        remove: remove
    }

    function getAll(completed) {
        var result = appService.get('contact/getall', null,
        completed,
        loadAllFalied);
        if (completed == undefined)
            return result;

    }

    function getById(id, completed) {
        appService.get('contact/getbyid/' + id, null,
        completed,
        loadSingleFalied);
    }

    function insert(entity, completed) {
        appService.post('contact/insert', entity,
        completed,
        insertFalied);
    }

    function update(entity, completed) {
        appService.post('contact/update', entity,
        completed,
        updateFalied);
    }

    function remove(id, completed) {
        appService.post('contact/remove/' + id, null,
        completed,
        removeFalied);
    }


   
    function removeFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar remover um contato.', response.data.erros);
    }

    function updateFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar atualizar um contato.', response.data.erros);
    }

    function insertFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar inserir um contato.', response.data.erros);
    }

    function loadSingleFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar um contato.', response.data.erros);
    }

    function loadAllFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar lista de contatos', response.data.erros);
    }

    return service;
}
