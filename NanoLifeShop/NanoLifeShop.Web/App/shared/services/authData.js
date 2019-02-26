(function (app) {
    'use strict';

    app.factory('authData', authData);

    function authData() {
        var authDataFactory = {};

        var authentication = {
            IsAuthenticated: false,
            UserName: ""
        };

        authDataFactory.authenticationData = authentication;

        return authDataFactory;
    }

})(angular.module('NanoLife.common'))