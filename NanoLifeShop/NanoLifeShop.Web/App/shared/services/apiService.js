/// <reference path="../../../assets/admin/lib/angular/angular.min.js" />

(function (app) {
    app.factory('apiService', apiService);

    apiService.$inject = ['$http', 'authenticationService','notificationService'];


    function apiService($http, authenticationService, notificationService) {

        function get(url, params, success, failure) {
            authenticationService.setHeader();
            $http.get(url, params).then(function (response) {
                success(response);
            }, function (error) {
                if (error.status == 401) {
                    notificationService.DisplayError("Authenticated is required !");
                }
                else {
                    failure(error);
                }

            });
        }

        function post(url, data, success, failure) {
            authenticationService.setHeader();
            $http.post(url, data).then(function (response) {
                success(response);
            }, function (error) {
                if (error.status == 401) {
                    notificationService.DisplayError("Authenticated is required !");
                }
                else {
                    failure(error);
                }

            });
        }


        function put(url, data, success, failure) {
            authenticationService.setHeader();
            $http.put(url, data).then(function (response) {
                success(response);
            }, function (error) {
                if (error.status == 401) {
                    notificationService.DisplayError("Authenticated is required !");
                }
                else {
                    failure(error);
                }

            });
        }

        function dele(url, data, success, failure) {
            authenticationService.setHeader();
            $http.delete(url, data).then(function (response) {
                success(response);
            }, function (error) {
                if (error.status == 401) {
                    notificationService.DisplayError("Authenticated is required !");
                }
                else {
                    failure(error);
                }

            });
        }


        return {
            get: get,
            post: post,
            put: put,
            dele: dele
        }
    }


})(angular.module("NanoLife.common"))