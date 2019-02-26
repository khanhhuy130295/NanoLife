(function (app) {
    app.controller('productCateAddController', productCateAddController);

    productCateAddController.$inject = ['$scope', 'apiService', 'notificationService', 'commonService', '$state']

    function productCateAddController($scope, apiService, notificationService, commonService, $state) {
        $scope.AddItem = AddItem;

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

        function AddItem() {
            apiService.post('/api/productCategory/create', $scope.productCate, function (response) {
                notificationService.DisplaySuccess("Thêm mới danh mục " + response.data.Name + " đã được thêm mới");
                $state.go('productCategory');
            }, function (error) {
                notificationService.DisplayError("Thêm mới thất bại vui lòng kiểm tra lại thông tin!");
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

        GetParent();
    }

})(angular.module('NanoLife.ProductCategory'))