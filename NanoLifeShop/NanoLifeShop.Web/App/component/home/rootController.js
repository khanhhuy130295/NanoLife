(function (app) {
    app.controller('rootController', rootController);
    rootController.$inject = ['authData', 'authenticationService', 'loginService', 'notificationService', '$scope', '$state'];

    function rootController(authData, authenticationService, loginService, notificationService, $scope, $state) {
        $scope.Logout = function () {
            loginService.logOut();
            $state.go('login');
            notificationService.DisplayInformation("Bạn đã đăng xuất khỏi Trang quản trị !");
        };
        $scope.authentication = authData.authenticationData;

        ///authenticationService.validateRequest();


    }
})(angular.module('NanoLife'))