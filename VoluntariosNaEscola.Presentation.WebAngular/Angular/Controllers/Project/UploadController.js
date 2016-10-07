'use strict';
appDataBase.controller('UploadController', uploadController);

uploadController.$inject = ['$scope', 'FileUploader', 'Constants', 'ngDialog', 'UploadService', 'NotificationService'];

function uploadController($scope, FileUploader, Constants, ngDialog, uploadService, notificationService) {
    // Uploader Plugin Code
    $scope.acceptsFiles = ['pdf', 'doc', 'docx', 'xls', 'xlsx', 'ppt', 'pptx', 'txt'];
    $scope.action = $scope.$parent.action;
    $scope.ngDialog = ngDialog;
    if ($scope.$parent.project.files.length > 0) {


        var uploader = $scope.uploader = new FileUploader({
            url: Constants.HostHttp + 'fileinfo/importfile',
            withCredentials: true,
            scope: $scope,
        });

        $scope.$parent.project.files.forEach(function (item, index) {
            item.IndexFile = index;
            uploader.queue.push({
                file: {
                    name: item.name,
                    type: item.type,
                    size: item.size,
                    id: item.id
                },
                isUploaded: true,
                isSuccess: true,
                isUploading: false
            });
        });
    }
    else {
        var uploader = $scope.uploader = new FileUploader({
            url: Constants.HostHttp + 'fileinfo/importfile',
            withCredentials: true,
            scope: $scope,
        });
    }

    // FILTERS

    uploader.filters.push({
        name: 'extensionFilter',
        fn: function (item, options) {
            var filename = item.name;
            var fileType = item.type.substring(0, item.type.lastIndexOf('/')).toLowerCase();

            var extension = filename.substring(filename.lastIndexOf('.') + 1).toLowerCase();
            if ($scope.acceptsFiles.indexOf(extension) > -1 || fileType == 'image') {
                return true;
            }
            else {

                notificationService.displayError('Arquivo com formato inv&aacute;lido. S&atilde;o permitidos somente os seguintes formatos: pdf, doc, docx, xls, xlsx, ppt, pptx, txt e imagem.');
                return false;
            }
        }
    });

    uploader.filters.push({
        name: 'sizeFilter',
        fn: function (item, options) {
            var fileSize = item.size;
            fileSize = parseInt(fileSize) / (1024 * 1024 * 1024);
            if (fileSize <= 4)
                return true;
            else {
                notificationService.displayError('Arquivo selecionado excede o tamanho limite de 4GB. Por favor, escolha um novo arquivo e tente novamente.');
                return false;
            }
        }
    });

    uploader.filters.push({
        name: 'itemResetFilter',
        fn: function (item, options) {
            if (this.queue.length < 10)
                return true;
            else {
                notificationService.displayError('Nv&uacute;mero mv&aacute;ximo de arquivos na fila excedido.');
                return false;
            }
        }
    });

    // CALLBACKS

    uploader.onSuccessItem = function (fileItem, response, status, headers) {

        var fileInfo = response;
        fileInfo.IndexFile = $scope.uploader.getIndexOfItem(fileItem)
        $scope.$parent.project.files.push(fileInfo);

    };

    uploader.onBeforeUploadItem = function (item) {

        //cria o objeto fileInfo
        var data = {
            name: item.file.name,
            size: item.file.size,
            type: item.file.type,
            idProject: $scope.$parent.project.id == undefined ? 0 : $scope.$parent.project.id,
            IndexFile: null,
            path: null,
            hashName: null,
            extension: null

        };

        var formData = [{ model: angular.toJson(data) }];

        Array.prototype.push.apply(item.formData, formData);

    };



    uploader.onCompleteAll = function () {
        notificationService.displaySuccess('Arquivos importados com sucesso.');
    };


    $scope.removeItem = function (item) {

        if (item.IndexFile > 0 && $scope.$parent.project.files.length > 0) {
            var indexFile = $scope.uploader.getIndexOfItem(item);


            $scope.$parent.project.files.forEach(function (file) {

                if (file.IndexFile == indexFile) {

                    if (file.id > 0)
                        uploadService.removeFile(file, removeItemCompleted);
                    else
                        removeItemCompleted(file);

                }
            });
        }
        else {
            $scope.uploader.removeFromQueue(item);
            angular.element("input[type='file']").val(null);
        }

    }

    $scope.removeAll = function () {

        if ($scope.$parent.project.files.length > 0) {

            $scope.$parent.project.files.forEach(function (file) {
                if (file.id > 0) {
                    uploadService.removeFile(file, removeItemCompleted);
                }
                else removeItemCompleted(file);
            });
        }
        else {
            $scope.uploader.queue = [];
            angular.element("input[type='file']").val(null);
        }

    }

    function removeItemCompleted(file) {

        $scope.$parent.project.files = $.grep($scope.$parent.project.files, function (item) {

            return item.IndexFile != file.IndexFile;
        });

        $scope.uploader.queue.splice(file.IndexFile, 1);
        $scope.uploader.progress = $scope.uploader.getTotalProgress();
        angular.element("input[type='file']").val(null);
        notificationService.displaySuccess('Arquivo removido com sucesso.');

    }

    $scope.download = function download(file) {

        uploadService.downloadFile(file, completeDonwload);
    }

    function completeDonwload(response, file) {
        console.log(response);

        var url = URL.createObjectURL(new Blob([response.data]));
        var a = document.createElement('a');
        a.href = url;
        a.download = file.name;
        a.target = '_blank';
        a.click();
    }
};
