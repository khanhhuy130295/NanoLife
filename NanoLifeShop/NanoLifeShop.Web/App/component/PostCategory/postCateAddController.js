(function (app) {
    app.controller('postCateAddController', postCateAddController);

    postCateAddController.$inject = ['$scope', 'apiService', 'notificationService', 'commonService', '$state']

    function postCateAddController($scope, apiService, notificationService, commonService, $state) {
        $scope.AddItem = AddItem;

        $scope.postCate = {
            Status: true,
            CreateDate: new Date()
        };

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.postCate.Alias = commonService.getSeoTitle($scope.postCate.Name);
        }


        $scope.ChooseImg = ChooseImg;

        function ChooseImg() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileURL) {
                $scope.$apply(function () {
                    $scope.postCate.Image = fileURL;
                });
            };

            finder.popup();

        }

        function AddItem() {
            apiService.post('/api/postCategory/create', $scope.postCate, function (response) {
                notificationService.DisplaySuccess("Thêm mới danh mục " + response.data.Name + " đã được thêm mới");
                $state.go('postCategory');
            }, function (error) {
                notificationService.DisplayError("Thêm mới thất bại vui lòng kiểm tra lại thông tin!");
                console.log(error);
            });
        }

        function GetParent() {
            apiService.get('/api/postCategory/getparent', null, function (response) {
                $scope.parentCategories = response.data;
            }, function () {
                notificationService.DisplayError("Lỗi không load được danh mục cha!");
            });
        }

        GetParent();
    }

})(angular.module('NanoLife.PostCategory'))