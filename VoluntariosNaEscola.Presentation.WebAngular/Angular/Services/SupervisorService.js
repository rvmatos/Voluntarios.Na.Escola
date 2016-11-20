appDataBase.factory('SupervisorService', aprovadorService);

aprovadorService.$inject = ['AppService', '$http', '$cookieStore', '$rootScope', 'NotificationService'];

function aprovadorService(appService, $http, $cookieStore, $rootScope, notificationService) {

    var service = {
        getAll: getAll,
        getById: getById,
        insert: insert,
        update: update,
        remove: remove
    }

    function getAll(completed) {
        var result = appService.get('supervisor/getall', null,
         completed,
         loadAllFalied);
        if (completed == undefined)
            return result;

    }



    function getById(id, completed) {
        appService.get('supervisor/get/' + id, null,
        completed,
        loadSingleFalied);
    }

    function insert(entity, completed) {
        var url = 'supervisor/add';
        appService.post(url, entity,
        completed,
        insertFalied);
    }

    function update(entity, completed) {
        console.log('update', entity);
        appService.post('supervisor/update', entity,
        completed,
        updateFalied);
    }

    function remove(id, completed) {
        appService.post('supervisor/delete/' + id, null,
        completed,
        removeFalied);
    }


    function removeFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar remover uma escola', response.data.errors);
    }

    function updateFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar atualizar uma escola', response.data.errors);
    }

    function insertFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar inserir uma escola', response.data.errors);
    }

    function loadSingleFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar uma escola', response.data.errors);
    }

    function loadAllFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar lista de escolas', response.data.errors);
    }

    return service;
}
