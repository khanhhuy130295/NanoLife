(function (app) {
    app.controller('postAddController', postAddController);

    postAddController.$inject = ['$scope', 'notificationService','commonService','apiService','$state']

    function postAddController($scope, notificationService, commonService, apiService, $state) {

        $scope.post = {
            CreateDate: new Date(),
            Status: true
        }

        $scope.ckeditorOptions = {
            height: '200px'
        };

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.post.Alias = commonService.getSeoTitle($scope.post.Name);
        }


        $scope.ChooseImg = ChooseImg;

        function ChooseImg() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileURL) {
                $scope.$apply(function () {
                    $scope.post.Image = fileURL;
                });
            };

            finder.popup();

        }


        //Add & get parent list
        $scope.AddItem = AddItem;

        function AddItem() {
            apiService.post('/api/post/create', $scope.post, function (response) {
                notificationService.DisplaySuccess("Bản tin " + response.data.Name + " đã được thêm mới");
                $state.go('post');
            }, function (error) {
                notificationService.DisplayError("Thêm mới thất bại vui lòng kiểm tra lại thông tin!");
                console.log(error);
            });
        }

      
        function GetParentCate() {
            apiService.get('/api/postCategory/getparent', null, function (response) {
                $scope.parentCategories = response.data;
            }, function () {
                notificationService.DisplayError("Không lấy được danh mục tin tức !");
            });
        }


        GetParentCate();

    }
})(angular.module('NanoLife.Post'))