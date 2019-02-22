(function (app) {
    app.controller('postCateListController', postCateListController);
    postCateListController.$inject = ['$scope']

    function postCateListController($scope) {
        $scope.value = "Đây là trang danh sách tin tức !";
    }

})(angular.module('NanoLife.PostCategory'))