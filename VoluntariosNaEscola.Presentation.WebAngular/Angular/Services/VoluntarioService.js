appDataBase.factory('VoluntarioService', voluntarioService);

voluntarioService.$inject = ['AppService', '$http', '$cookieStore', '$rootScope', 'NotificationService'];

function voluntarioService(appService, $http, $cookieStore, $rootScope, notificationService) {

    var service = {
        getAll: getAll,
        getById: getById,
        insert: insert,
        update: update,
        remove: remove,
        vincularEscola: vincularEscola
    }

    function getAll(completed) {
        var result = appService.get('voluntarios/getall', null,
         completed,
         loadAllFalied);
        if (completed == undefined)
            return result;

    }

    function getById(id, completed) {
        appService.get('voluntarios/get/' + id, null,
        completed,
        loadSingleFalied);
    }

    function insert(entity, completed) {
        var url ='voluntarios/add';
        appService.post(url, entity,
        completed,
        insertFalied);
    }

    function update(entity, completed) {
        console.log('update', entity);
        appService.post('voluntarios/update', entity,
        completed,
        updateFalied);
    }

    function remove(id, completed) {
        appService.post('voluntarios/delete/' + id, null,
        completed,
        removeFalied);
    }

    function vincularEscola(idEscola, idVoluntario) {
        appService.post('voluntarios/vincularescola?idEscola=' + idEscola + '&idVoluntario=' + idVoluntario, null,
            function (result) {
                notificationService.displaySuccess('Escola vinculada com sucesso.');
            }, function (result) {
                notificationService.displayErrorWithTille('Falha ao tentar remover um voluntário', response.data.errors);
            })
    }


    function removeFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar remover um voluntário', response.data.errors);
    }

    function updateFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar atualizar um voluntário', response.data.errors);
    }

    function insertFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar inserir um voluntário', response.data.errors);
    }

    function loadSingleFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar um voluntário', response.data.errors);
    }

    function loadAllFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar lista de voluntários', response.data.errors);
    }

    return service;
}
