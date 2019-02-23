(function (app) {
    app.factory('notificationService', notificationService);



    function notificationService() {

        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": true,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };

        function displaySuccess(message) {
            toastr.success(message);
        };
        function displayInformation(message) {
            toastr.info(message);
        };
        function displayWarning(message) {
            toastr.warning(message);
        };
        function displayError(error) {
            if (Array.isArray(error)) {
                error.each(function (err) {
                    toastr.error(err);
                });
            }
            else {
                toastr.error(error);

            }
        };

        return {
            DisplaySuccess: displaySuccess,
            DisplayInformation: displayInformation,
            DisplayWarning: displayWarning,
            DisplayError: displayError,
        };
    }
})(angular.module('NanoLife.common'))