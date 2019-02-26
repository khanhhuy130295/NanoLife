(function (app) {
    app.controller('productCateEditController', productCateEditController);

    productCateEditController.$inject = ['$scope', 'apiService', 'notificationService', 'commonService', '$state','$stateParams']

    function productCateEditController($scope, apiService, notificationService, commonService, $state, $stateParams) {
        $scope.EditItem = EditItem;

        $scope.productCate = {
            Status: true,
            CreateDate: new Date()
        };

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCate.Alias = commonService.getSeoTitle($scope.productCate.Name);
        }


        $scope.ChooseImg = ChooseImg;

        function ChooseImg() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileURL) {
                $scope.$apply(function () {
                    $scope.productCate.Image = fileURL;
                });
            };

            finder.popup();

        }

        function EditItem() {
            apiService.put('/api/productCategory/update', $scope.productCate, function (response) {
                notificationService.DisplaySuccess("Danh mục " + response.data.Name + " đã được cập nhất");
                $state.go('productCategory');
            }, function (error) {
                notificationService.DisplayError("Cập nhật thất bại vui lòng kiểm tra lại thông tin!");
                console.log(error);
            });
        }

        function GetParent() {
            apiService.get('/api/productCategory/getparent', null, function (response) {
                $scope.parentCategories = response.data;
            }, function () {
                notificationService.DisplayError("Lỗi không load được danh mục cha!");
            });
        }
        function GetDetailEdit() {
            apiService.get('/api/productCategory/getdetail/' + $stateParams.id, null, function (response) {
                $scope.productCate = response.data;
            }, function (error) {
                notificationService.DisplayError(error.data);
            });
        }

        GetParent();
        GetDetailEdit();
    }

})(angular.module('NanoLife.ProductCategory'))