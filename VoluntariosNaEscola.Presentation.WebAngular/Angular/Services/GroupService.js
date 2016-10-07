
appDataBase.factory('GroupService', groupService);

groupService.$inject = ['AppService', '$http', '$cookieStore', '$rootScope', 'NotificationService'];

function groupService(appService, $http, $cookieStore, $rootScope) {

    var service = {
        getAll: getAll,
        getById: getById,
        update: update,
        insert: insert,
        remove: remove
    }

    function getAll(completed) {
        var result = appService.get('group/getall', null,
          completed,
          loadAllFalied);
        if (completed == undefined)
            return result;
    }

    function getById(id, completed) {
        appService.get('group/getbyid/' + id, null,
        completed,
        loadSingleFalied);
    }

    function insert(entity, completed) {
        appService.post('group/insert', entity,
        completed,
        insertFalied);
    }

    function update(entity, completed) {
        appService.post('group/update', entity,
        completed,
        updateFalied);
    }

    function remove(id, completed) {
        appService.post('group/remove/' + id, null,
        completed,
        removeFalied);
    }

    function removeFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar remover um grupo', response.data.errors);
    }

    function updateFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar atualizar um grupo', response.data.errors);
    }

    function insertFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar inserir um grupo', response.data.errors);
    }

    function loadSingleFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar um grupo', response.data.errors);
    }

    function loadAllFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar lista de grupos', response.data.errors);
    }



    return service;
}
