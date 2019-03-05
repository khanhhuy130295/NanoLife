(function (app) {
    app.controller('productAddController', productAddController);

    productAddController.$inject = ['$scope', 'notificationService','commonService','apiService','$state']

    function productAddController($scope, notificationService, commonService, apiService, $state) {

        $scope.product = {
            CreateDate: new Date(),
            Status: true
        }

        $scope.ckeditorOptions = {
            height: '200px',
            
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
        $scope.AddItem = AddItem;

        function AddItem() {

            $scope.product.MoreImage = JSON.stringify($scope.moreImg);

            apiService.post('/api/product/create', $scope.product, function (response) {
                notificationService.DisplaySuccess("Sản phẩm " + response.data.Name + " đã được thêm mới");
                $state.go('product');
            }, function (error) {
                notificationService.DisplayError("Thêm mới thất bại vui lòng kiểm tra lại thông tin!");
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


        GetParentCate();

    }
})(angular.module('NanoLife.Product'))