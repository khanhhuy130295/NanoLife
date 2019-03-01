/// <reference path="../assets/admin/lib/angular/angular.js" />

(function () {
    angular.module("NanoLife", ['NanoLife.PostCategory', 'NanoLife.Post', 'NanoLife.ProductCategory', 'NanoLife.SupportOnline',
        'NanoLife.Product', 'NanoLife.MenuGroup', 'NanoLife.Menu', 'NanoLife.common']).config(configRouter).config(configAuthentication);

    configRouter.$inject = ['$stateProvider', '$urlRouterProvider']

    function configRouter($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state({
                name: 'base',
                templateUrl: '/App/shared/views/base.html',
                abstract: true,

            }).state({
                name: 'login',
                url: '/login',
                templateUrl: '/app/component/login/loginView.html',
                controller: 'loginController'
            }).state({
                name: 'home',
                url: '/admin',
                parent: 'base',
                templateUrl: '/App/component/home/homeView.html',
                controller: 'homeController',
            });

        $urlRouterProvider.otherwise('/login');

    }


    function configAuthentication($httpProvider) {

        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {
                    return config;
                },
                requestError: function (rejection) {

                    console.log(rejection);
                    console.log("Request Lỗi !");
                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == 401) {
                        console.log("Đây là lỗi yêu cầu đăng nhập của appconfig !");
                        $location.path('/login');
                    }
                    return response;
                },
                responseError: function (rejection) {
                    if (rejection.status == 401) {
                        console.log(rejection);
                        console.log("Đây là xử lý ngoại lệ  đăng nhập của appconfig !");

                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }

            };
        });
    }
})();