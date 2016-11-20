appDataBase.factory('ConviteAprovacaoService', conviteAprovacaoService);

conviteAprovacaoService.$inject = ['AppService', '$http', '$cookieStore', '$rootScope', 'NotificationService'];

function conviteAprovacaoService(appService, $http, $cookieStore, $rootScope, notificationService) {

    var service = {
        getAll: getAll,
        getById: getById,
        getByGuid: getByGuid,
        insert: insert,
        update: update,
        remove: remove,
        reenviarConvite: reenviarConvite,
        getConvitesBy: getConvitesBy
    }

    function getAll(completed) {
        var result = appService.get('conviteaprovacao/getall', null,
         completed,
         loadAllFalied);
        if (completed == undefined)
            return result;

    }

    function getByGuid(id, completed) {
        var result = appService.get('conviteaprovacao/getbyguid/' + id, null,
         completed,
         loadSingleFalied);
        if (completed == undefined)
            return result;

    }

    

    function getById(id, completed) {
        var result = appService.get('conviteaprovacao/get/' + id, null,
        completed,
        loadSingleFalied);
        if (completed == undefined)
            return result;
    }
    function getConvitesBy(id, completed) {
        var result = appService.get('conviteaprovacao/getconvitesby/?idDiretor=' + id, null,
       completed,
       loadAllFalied);
        if (completed == undefined)
            return result;
    }

    function insert(entity, completed) {
        var url = 'conviteaprovacao/add';
        appService.post(url, entity,
        completed,
        insertFalied);
    }

    function update(entity, completed) {
   
        appService.post('conviteaprovacao/update', entity,
        completed,
        updateFalied);
    }

    function reenviarConvite(id, reenviarSuccess) {
       
        appService.post('conviteaprovacao/reenviarconvite/' + id, null,
       reenviarSuccess,
       reenviarFalied);
    }

    


    function remove(id, completed) {
        appService.post('conviteaprovacao/delete/' + id, null,
        completed,
        removeFalied);
    }


    function removeFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar remover um convite aprovação', response.data.errors);
    }

    function updateFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar atualizar um convite aprovação', response.data.errors);
    }

    function reenviarFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar atualizar um convite aprovação', response.data.errors);
    }

    function insertFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar inserir um convite aprovação', response.data.errors);
    }

    function loadSingleFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar um convite aprovação', response.data.errors);
    }

    function loadAllFalied(response) {

        notificationService.displayErrorWithTille('Falha ao tentar carregar lista de convites para aprovação', response.data.errors);
    }

    return service;
}
