/// <reference path="../../../assets/admin/lib/angular/angular.js" />

(
    function () {
        angular.module("NanoLife.Slide", ['NanoLife.common']).config(configSlide);

        configSlide.$inject = ['$stateProvider', '$urlRouterProvider'];

        function configSlide($stateProvider, $urlRouterProvider) {
            $stateProvider.state({
                name: 'Slide',
                url: '/Slide',
                templateUrl: '/App/component/Slide/SlideList.html',
                controller: 'SlideListController',
                parent: 'base'
            }).state({
                name: 'SlideAdd',
                url: '/SlideAdd',
                templateUrl: '/App/component/Slide/SlideAdd.html',
                controller: 'SlideAddController',
                parent: 'base'
            }).state({
                name: 'SlideEdit',
                url: '/SlideEdit/:id',
                templateUrl: '/App/component/Slide/SlideEdit.html',
                controller: 'SlideEditController',
                parent: 'base'
            });
        }
    }
)()