/// <reference path="../../../assets/admin/lib/angular/angular.min.js" />

(function (app) {
    app.factory('apiService', apiService);

    apiService.$inject = ['$http'];


    function apiService($http) {

        function get(url, params, success, failure) {
            $http.get(url, params).then(function (response) {
                success(response);
            }, function (error) {
                if (error.status == 401) {
                    console.log("Authenticated is required !");
                }
                else {
                    failure(error);
                }

            });
        }

        function post(url, data, success, failure) {
            $http.post(url, data).then(function (response) {
                success(response);
            }, function (error) {
                if (error.status == 401) {
                    console.log("Authenticated is required !");
                }
                else {
                    failure(error);
                }

            });
        }


        function put(url, data, success, failure) {
            $http.put(url, data).then(function (response) {
                success(response);
            }, function (error) {
                if (error.status == 401) {
                    console.log("Authenticated is required !");
                }
                else {
                    failure(error);
                }

            });
        }

        function dele(url, data, success, failure) {
            $http.delete(url, data).then(function (response) {
                success(response);
            }, function (error) {
                if (error.status == 401) {
                    console.log("Authenticated is required !");
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