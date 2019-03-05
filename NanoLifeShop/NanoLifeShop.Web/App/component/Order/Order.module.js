/// <reference path="../../../assets/admin/lib/angular/angular.min.js" />

(function () {
    angular.module('NanoLife.Order', ['NanoLife.common']).config(configOrder);

    configOrder.$inject = ['$stateProvider', '$urlRouterProvider'];

    function configOrder($stateProvider, $urlRouterProvider) {

        $stateProvider.state({
            name: 'Order',
            url: '/Order',
            templateUrl: '/App/component/Order/OrderList.html',
            controller: 'OrderListController',
            parent: 'base'
        }).state({
            name: 'OrderAdd',
            url: '/OrderAdd',
            templateUrl: '/App/component/Order/OrderAdd.html',
            controller: 'OrderAddController',
            parent: 'base'
        }).state({
            name: 'OrderEdit',
            url: '/OrderEdit/:id',
            templateUrl: '/App/component/Order/OrderEdit.html',
            controller: 'OrderEditController',
            parent: 'base'
        });
    }
}
)()