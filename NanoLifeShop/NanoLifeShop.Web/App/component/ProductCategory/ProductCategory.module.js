(function () {
    angular.module('NanoLife.ProductCategory', ['NanoLife.common']).config(configProductCate);

    configProductCate.$inject = ['$stateProvider', '$urlRouterProvider']

    function configProductCate($stateProvider, $urlRouterProvider) {
        $stateProvider.state({
            name: 'productCategory',
            url: '/productCategory',
            templateUrl: '/App/component/ProductCategory/productCateList.html',
            controller: 'productCateListController',
            parent: 'base'
        }).state({
            name: 'productCategoryAdd',
            url: '/productCategoryAdd',
            templateUrl: '/App/component/ProductCategory/productCateAdd.html',
            controller: 'productCateAddController',
            parent: 'base'
        }).state({
            name: 'productCategoryEdit',
            url: '/productCategoryEdit/:id',
            templateUrl: '/App/component/ProductCategory/productCateEdit.html',
            controller: 'productCateEditController',
            parent: 'base'
        });

    }
})()