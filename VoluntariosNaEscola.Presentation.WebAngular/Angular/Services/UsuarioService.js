appDataBase.factory('UsuarioService', usuarioService);

usuarioService.$inject = ['AppService', '$http', '$cookieStore', '$rootScope', 'NotificationService'];

function usuarioService(appService, $http, $cookieStore, $rootScope, notificationService) {

    var service = {
        getAll: getAll,
        getById: getById,
        insert: insert,
        update: update,
        remove: remove
    }

    function getAll(completed) {
        var result = appService.get('usuarios/getall', null,
         completed,
         loadAllFalied);
        if (completed == undefined)
            return result;

    }

    function getById(id, completed) {
        appService.get('usuarios/get/' + id, null,
        completed,
        loadSingleFalied);
    }

    function insert(entity, completed) {
        var url = entity.isVoluntario ? 'voluntarios/add' : 'escolas/add';
        appService.post(url, entity,
        completed,
        insertFalied);
    }

    function update(entity, completed) {
        console.log('update', entity);
        appService.post('usuarios/update', entity,
        completed,
        updateFalied);
    }

    function remove(id, completed) {
        appService.post('usuarios/delete/' + id, null,
        completed,
        removeFalied);
    }


    function removeFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar remover um usuario', response.data.errors);
    }

    function updateFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar atualizar um usuario', response.data.errors);
    }

    function insertFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar inserir um usuario', response.data.errors);
    }

    function loadSingleFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar um usuario', response.data.errors);
    }

    function loadAllFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar lista de usuarios', response.data.errors);
    }

    return service;
}
