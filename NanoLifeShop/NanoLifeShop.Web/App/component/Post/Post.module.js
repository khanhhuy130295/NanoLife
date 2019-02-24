/// <reference path="../../../assets/admin/lib/angular/angular.min.js" />

(function () {
    angular.module('NanoLife.Post', ['NanoLife.common']).config(configRouter);

    configRouter.$inject = ['$stateProvider','$urlRouterProvider'];

    function configRouter($stateProvider, $urlRouterProvider) {
        $stateProvider.state({
            name: 'post',
            url: '/post',
            templateUrl: '/App/component/Post/postList.html',
            controller: 'postListController',
            parent: 'base'
        }).state({
            name: 'postAdd',
            url: '/postAdd',
            templateUrl: '/App/component/Post/postAdd.html',
            controller: 'postAddController',
            parent: 'base'
        }).state({
            name: 'postEdit',
            url: '/postEdit/:id',
            templateUrl: '/App/component/Post/postEdit.html',
            controller: 'postEditController',
            parent: 'base'
        });
    }
})()