/// <reference path="../assets/admin/lib/angular/angular.js" />

(function () {
    angular.module("NanoLife", ['NanoLife.PostCategory','NanoLife.common']).config(configRouter);

    configRouter.$inject = ['$stateProvider', '$urlRouterProvider']

    function configRouter($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state({
                name: 'base',
                templateUrl: '/App/shared/views/base.html',
                abstract: true,

            }).state({
                name: 'home',
                url: '/admin',
                parent: 'base',
                templateUrl: '/App/component/home/homeView.html',
                controller: 'homeController',
            });

        $urlRouterProvider.otherwise('/admin');

    }

})();