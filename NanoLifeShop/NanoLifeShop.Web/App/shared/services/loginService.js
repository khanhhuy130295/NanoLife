(function (app) {
    'use strict';
    app.service("loginService", loginService);

    loginService.$inject = ['$http', '$q', 'authenticationService', 'authData'];

    function loginService($http, $q, authenticationService, authData) {
        var userInfo;
        var deferred;

        this.login = function (userName, password) {
            deferred = $q.defer();

            var data = "grant_type=password&username=" + userName + "&password=" + password;

            $http.post('/oauth/token', data, {
                headers:
                    { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).then(function (response) {
                userInfo = {
                    accessToken: response.data.access_token,
                    userName: userName
                };

                authenticationService.setTokenInfo(userInfo);

                authData.authenticationData.UserName = userName;

                deferred.resolve(null);
            }, function (error) {
                authData.authenticationData.IsAuthenticated = false;

                authData.authenticationData.UserName = "";
                deferred.resolve(error);
            });
            return deferred.promise;
        }


        this.logOut = function () {
            authenticationService.removeToken();

            authData.authenticationData.IsAuthenticated = false;

            authData.authenticationData.UserName = "";
        }
    }

})(angular.module("NanoLife.common"))