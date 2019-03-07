/// <reference path="../../../assets/admin/lib/angular/angular.js" />
(
    function () {
        angular.module("NanoLife.Menu", ['NanoLife.common']).config(configMenu);

        configMenu.$inject = ['$stateProvider', '$urlRouterProvider'];

        function configMenu($stateProvider, $urlRouterProvider) {

            $stateProvider.state({
                name: 'Menu',
                url: '/Menu',
                templateUrl: '/App/component/Menu/MenuList.html',
                controller: 'MenuListController',
                parent: 'base'
            }).state({
                name: 'MenuAdd',
                url: '/MenuAdd',
                templateUrl: '/App/component/Menu/MenuAdd.html',
                controller: 'MenuAddController',
                parent: 'base'
            }).state({
                name: 'MenuEdit',
                url: '/MenuEdit/:id',
                templateUrl: '/App/component/Menu/MenuEdit.html',
                controller: 'MenuEditController',
                parent: 'base'
            });
        }



    }
)()