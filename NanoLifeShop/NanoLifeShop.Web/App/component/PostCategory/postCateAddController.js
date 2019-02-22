(function (app) {
    app.controller('postCateAddController', postCateAddController);
    postCateAddController.$inject = ['$scope']

    function postCateAddController($scope) {
        $scope.value = "Đây là trang thêm sản phẩm !";
    }

})(angular.module('NanoLife.PostCategory'))