appDataBase.factory('ProjectService', projectService);

projectService.$inject = ['AppService', '$http', '$cookieStore', '$rootScope', 'NotificationService'];

function projectService(appService, $http, $cookieStore, $rootScope, notificationService) {

    var service = {
        getAll: getAll,
        getById: getById,
        insert: insert,
        update: update,
        remove: remove
    }

    function getAll(completed) {
        var result = appService.get('project/getall', null,
         completed,
         loadAllFalied);
        if (completed == undefined)
            return result;

    }

    function getById(id, completed) {
        appService.get('project/getbyid/' + id, null,
        completed,
        loadSingleFalied);
    }

    function insert(entity, completed) {
        appService.post('project/insert', entity,
        completed,
        insertFalied);
    }

    function update(entity, completed) {
        console.log('update', entity);
        appService.post('project/update', entity,
        completed,
        updateFalied);
    }

    function remove(id, completed) {
        appService.post('project/remove/' + id, null,
        completed,
        removeFalied);
    }


    function removeFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar remover um projeto', response.data.errors);
    }

    function updateFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar atualizar um projeto', response.data.errors);
    }

    function insertFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar inserir um projeto', response.data.errors);
    }

    function loadSingleFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar um projeto', response.data.errors);
    }

    function loadAllFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar lista de projetos', response.data.errors);
    }

    return service;
}
