/// <reference path="../../../assets/admin/lib/angular/angular.min.js" />

(function () {
    angular.module('NanoLife.Product', ['NanoLife.common']).config(configRouter);

    configRouter.$inject = ['$stateProvider','$urlRouterProvider'];

    function configRouter($stateProvider, $urlRouterProvider) {
        $stateProvider.state({
            name: 'product',
            url: '/product',
            templateUrl: '/App/component/Product/productList.html',
            controller: 'productListController',
            parent: 'base'
        }).state({
            name: 'productAdd',
            url: '/productAdd',
            templateUrl: '/App/component/Product/productAdd.html',
            controller: 'productAddController',
            parent: 'base'
        }).state({
            name: 'productEdit',
            url: '/productEdit/:id',
            templateUrl: '/App/component/Product/productEdit.html',
            controller: 'productEditController',
            parent: 'base'
        });
    }
})()