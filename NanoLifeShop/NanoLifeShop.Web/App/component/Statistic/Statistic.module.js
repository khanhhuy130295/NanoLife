/// <reference path="../../../assets/admin/lib/angular/angular.js" />

(
    function () {
    	angular.module("NanoLife.Statistic", ['NanoLife.common']).config(configStatistic);

    	configStatistic.$inject = ['$stateProvider', '$urlRouterProvider'];

    	function configStatistic($stateProvider, $urlRouterProvider) {
    		$stateProvider.state({
    			name: 'Statistic',
    			url: '/Statistic',
    			templateUrl: '/App/component/Statistic/StatisticList.html',
                controller: 'StatisticController',
    			parent: 'base'
    		})
    	}
    }
)()