(function ()
{
	angular.module('NanoLife.PostCategory', ['NanoLife.common']).config(configPost);

	configPost.$inject = ['$stateProvider', '$urlRouterProvider']

	function configPost($stateProvider, $urlRouterProvider) {
		$stateProvider.state({
			name: 'postCategory',
			url: '/postCategory',
			templateUrl: '/App/component/PostCategory/postCateList.html',
			controller:'postCateListController',
			parent:'base'
		}).state({
			name: 'postCategoryAdd',
			url: '/postCategoryAdd',
			templateUrl: '/App/component/PostCategory/postCateAdd.html',
			controller: 'postCateAddController',
			parent: 'base'
		}).state({
			name: 'postCategoryEdit',
			url: '/postCategoryEdit',
			templateUrl: '/App/component/PostCategory/postCateEdit.html',
			controller: 'postCateEditController',
			parent: 'base'
		});
		
	}
})()