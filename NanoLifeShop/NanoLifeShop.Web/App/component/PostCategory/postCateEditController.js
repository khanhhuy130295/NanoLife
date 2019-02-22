(function (app) {
    app.controller('postCateEditController', postCateEditController);
    postCateEditController.$inject = ['$scope']

    function postCateEditController($scope) {
        $scope.value = "Đây là trang Sửa sản phẩm !";
    }

})(angular.module('NanoLife.PostCategory'))