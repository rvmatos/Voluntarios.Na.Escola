appDataBase.factory('UploadService', uploadService);

uploadService.$inject = ['AppService', '$http', '$rootScope', 'NotificationService'];

function uploadService(appService, $http, $rootScope, notificationService) {
    var service = {
        removeFile: removeFile,       
        removeFileFailed: removeFileFailed,
        downloadFile: downloadFile,
        downloadFileFailed: downloadFileFailed
    };

    function removeFile(file, completed) {
        console.log(file);
        appService.post('FileInfo/Remove/' + file.id , null, function (data) { completed(file) }, removeFileFailed);
    }
    
   

    function removeFileFailed(response) {
        notificationService.displayError('Falha ao remover um arquivo.');
    }

    function downloadFile(file, completed) {
        appService.get('FileInfo/DownloadFile/' + file.id, { responseType:'arraybuffer',  headers: {
            'Content-Type': 'application/json; charset=utf-8'}}, function (response) { completed(response, file) }, downloadFileFailed);
    }

    function downloadFileFailed() {
        notificationService.displayError('Falha ao baixar arquivo.')
    }
    return service;
}