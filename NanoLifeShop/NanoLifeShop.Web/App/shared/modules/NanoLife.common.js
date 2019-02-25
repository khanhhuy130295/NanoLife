(function ()
{
    angular.module('NanoLife.common', ['ui.router', 'ngBootbox', 'ngCkeditor', 'angular-loading-bar']).config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
        cfpLoadingBarProvider.includeSpinner = false;
    }]);
})()