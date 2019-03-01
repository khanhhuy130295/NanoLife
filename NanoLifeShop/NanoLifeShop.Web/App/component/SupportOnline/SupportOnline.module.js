(
    function () {
        angular.module("NanoLife.SupportOnline", ['NanoLife.common']).config(configSupport);

        configSupport.$inject = ['$stateProvider', '$urlRouterProvider']

        function configSupport($stateProvider, $urlRouterProvider) {

            $stateProvider.state({
                name: 'Support',
                url: '/Support',
                templateUrl: '/App/component/SupportOnline/SupportList.html',
                parent: 'base',
                controller: 'SupportListController'
            }).state({
                name: 'SupportAdd',
                url: '/SupportAdd',
                templateUrl: '/App/component/SupportOnline/SupportAdd.html',
                parent: 'base',
                controller: 'SupportAddController'
            }).state({
                name: 'SupportEdit',
                url: '/SupportEdit/:id',
                templateUrl: '/App/component/SupportOnline/SupportEdit.html',
                parent: 'base',
                controller: 'SupportEditController'
            });

        }
    }
)()