appDataBase.factory('DiretorService', diretorService);

diretorService.$inject = ['AppService', '$http', '$cookieStore', '$rootScope', 'NotificationService'];

function diretorService(appService, $http, $cookieStore, $rootScope, notificationService) {

    var service = {
        getAll: getAll,
        getById: getById,
        insert: insert,
        update: update,
        remove: remove
    }

    function getAll(completed) {
        var result = appService.get('diretores/getall', null,
         completed,
         loadAllFalied);
        if (completed == undefined)
            return result;

    }

    function getById(id, completed) {
        appService.get('diretores/get/' + id, null,
        completed,
        loadSingleFalied);
    }

    function insert(entity, completed) {
        var url = 'diretores/add';
        appService.post(url, entity,
        completed,
        insertFalied);
    }

    function update(entity, completed) {
        console.log('update', entity);
        appService.post('diretores/update', entity,
        completed,
        updateFalied);
    }

    function remove(id, completed) {
        appService.post('diretores/delete/' + id, null,
        completed,
        removeFalied);
    }


    function removeFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar remover um(a) diretor(a)', response.data.errors);
    }

    function updateFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar atualizar um(a) diretor(a)', response.data.errors);
    }

    function insertFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar inserir uma escolum(a) diretor(a)', response.data.errors);
    }

    function loadSingleFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar um(a) diretor(a)', response.data.errors);
    }

    function loadAllFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar lista de diretores', response.data.errors);
    }

    return service;
}
