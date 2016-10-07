

appDataBase.factory('NotificationService', notificationService);

function notificationService() {

    toastr.options = {
        "debug": false,
        "positionClass": "toast-top-right",
        "onclick": null,
        "fadeIn": 300,
        "fadeOut": 1000,
        "timeOut": 3000,
        "extendedTimeOut": 1000
    };

    var service = {
        displaySuccess: displaySuccess,
        displayError: displayError,
        displayWarning: displayWarning,
        displayInfo: displayInfo,
        displayErrorWithTille: displayErrorWithTille
    };

    return service;

    function displaySuccess(message) {
        toastr.success(message);
    }

    function displayErrorWithTille(title, error) {

        if (Array.isArray(error)) {
            error.forEach(function (err) {

                toastr.error(err.message, title);
            });
        } else {
            toastr.error(error, title);
        }
    }

    function displayError(error) {
        if (Array.isArray(error)) {
            error.forEach(function (err) {
                toastr.error(err.mensagem);
            });
        } else {
            toastr.error(error);
        }
    }

    function displayWarning(message) {
        toastr.warning(message);
    }

    function displayInfo(message) {
        toastr.info(message);
    }

}

