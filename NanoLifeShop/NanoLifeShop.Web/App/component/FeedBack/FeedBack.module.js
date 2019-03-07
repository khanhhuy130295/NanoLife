/// <reference path="../../../assets/admin/lib/angular/angular.js" />

(
function () {
    angular.module("NanoLife.FeedBack", ['NanoLife.common']).config(configFeedBack);

    configFeedBack.$inject = ['$stateProvider','$urlRouterProvider'];

	function configFeedBack($stateProvider, $urlRouterProvider) {
        $stateProvider.state({
			name: 'FeedBack',
			url: '/FeedBack',
			templateUrl: '/App/component/FeedBack/FeedBackList.html',
			controller: 'FeedBackListController',
			parent: 'base'
		}).state({
			name: 'FeedBackAdd',
			url: '/FeedBackAdd',
			templateUrl: '/App/component/FeedBack/FeedBackAdd.html',
			controller: 'FeedBackAddController',
			parent: 'base'
		}).state({
			name: 'FeedBackEdit',
			url: '/FeedBackEdit/:id',
			templateUrl: '/App/component/FeedBack/FeedBackEdit.html',
			controller: 'FeedBackEditController',
			parent: 'base'
		});
	}
}
)()