(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['$scope', 'notificationService', 'commonService', 'apiService', '$state','$stateParams']

    function productEditController($scope, notificationService, commonService, apiService, $state, $stateParams) {

        $scope.product = {
            CreateDate: new Date(),
            Status: true
        }

        $scope.ckeditorOptions = {
            height: '200px'
        };

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }


        $scope.ChooseImg = ChooseImg;

        function ChooseImg() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileURL) {
                $scope.$apply(function () {
                    $scope.product.Image = fileURL;
                });
            };

            finder.popup();

        }

        $scope.RemoveIndexImg = RemoveIndexImg;

        $scope.ChooseImgList = ChooseImgList;

        $scope.moreImg = [];

        function ChooseImgList() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileURL) {
                $scope.$apply(function () {
                    $scope.moreImg.push(fileURL);
                });

            };

            finder.popup();
        }

        function RemoveIndexImg(input) {

            var index = $scope.moreImg.indexOf(input);

            $scope.moreImg.splice(index, 1);

            notificationService.DisplayInformation("Ảnh" + " " + input + " " + "đã được xóa !");

        }


        //Add & get parent list
        $scope.EditItem = EditItem;

        function EditItem() {

            $scope.product.MoreImage = JSON.stringify($scope.moreImg);

            apiService.put('/api/product/update', $scope.product, function (response) {
                notificationService.DisplaySuccess("Sản phẩm " + response.data.Name + " đã được cập nhật");
                $state.go('product');
            }, function (error) {
                notificationService.DisplayError("Cập nhật thất bại vui lòng kiểm tra lại thông tin!");
                console.log(error);
            });
        }


        function GetParentCate() {
            apiService.get('/api/productCategory/getparent', null, function (response) {
                $scope.parentCategories = response.data;
            }, function () {
                notificationService.DisplayError("Không lấy được danh mục sản phẩm !");
            });
        }


        function GetDetail() {
            apiService.get('/api/product/getdetail/' + $stateParams.id, null, function (response) {
                $scope.product = response.data;
                $scope.moreImg = JSON.parse(response.data.MoreImage);
            }, function (error) {
                console.log(error);
                notificationService.DisplayError("Không lấy được chi tiết bản tin vui lòng thử lại sau !");
            });
        }


        GetParentCate();

        GetDetail();

    }
})(angular.module('NanoLife.Post'))