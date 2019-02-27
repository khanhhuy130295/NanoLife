/// <reference path="../../../assets/admin/lib/angular/angular.js" />


(
    function () {
        angular.module("NanoLife.MenuGroup", ['NanoLife.common']).config(configMenuGroup);

        configMenuGroup.$inject = ['$stateProvider', '$urlRouterProvider']

        function configMenuGroup($stateProvider, $urlRouterProvider) {

            $stateProvider.state({
                name: 'menuGroup',
                url: '/menuGroup',
                templateUrl: '/App/component/MenuGroup/MenuGroupList.html',
                controller: 'MenuGroupListController',
                parent: 'base'
            }).state({  
                name: 'MenuGroupAdd',
                url: '/MenuGroupAdd',
                templateUrl: '/App/component/MenuGroup/MenuGroupAdd.html',
                controller: 'MenuGroupAddController',
                parent: 'base'
            }).state({
                name: 'MenuGroupEdit',
                url: '/MenuGroupEdit/:id',
                templateUrl: '/App/component/MenuGroup/MenuGroupEdit.html',
                controller: 'MenuGroupEditController',
                parent: 'base'
            });
        }
    }
)()