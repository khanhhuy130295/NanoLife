(function (app) {
    app.controller('rootController', rootController);
    rootController.$inject = ['authData', 'authenticationService', 'loginService', 'notificationService', '$scope', '$state', '$window'];

    function rootController(authData, authenticationService, loginService, notificationService, $scope, $state, $window) {
        $scope.Logout = function () {
            loginService.logOut();

            $state.go('login').then(() => {
                $window.location.reload();
            });
            notificationService.DisplayInformation("Bạn đã đăng xuất khỏi Trang quản trị !");
        };

        $scope.authentication = authData.authenticationData;

        ///authenticationService.validateRequest();


    }
})(angular.module('NanoLife'))