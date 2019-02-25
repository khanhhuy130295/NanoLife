(function (app) {
    app.controller("loginController", loginController);

    loginController.$inject = ['$scope', 'loginService', '$injector', 'notificationService']

    function loginController($scope, loginService, $injector, notificationService) {
        $scope.loginData = {
            userName: "",
            password: ""
        };

        $scope.loginSubmit = function () {
            loginService.login($scope.loginData.userName, $scope.loginData.password)
                .then(function (response) {
                    console.log(response);
                    if (response != null && response.status == 400) {
                        notificationService.DisplayError("Sai tài khoản hoặc mật khẩu vui lòng kiểm tra lại !");
                    }
                    else {
                        var stateService = $injector.get('$state');
                        notificationService.DisplaySuccess("Bạn đã đăng nhập thành công !");
                        stateService.go('home');
                    }
                });
        }
    }
})(angular.module("NanoLife"))