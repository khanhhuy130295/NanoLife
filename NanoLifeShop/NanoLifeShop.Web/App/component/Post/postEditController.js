(function (app) {
    app.controller('postEditController', postEditController);

    postEditController.$inject = ['$scope', 'notificationService', 'commonService', 'apiService', '$state','$stateParams']

    function postEditController($scope, notificationService, commonService, apiService, $state, $stateParams) {

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


        //Edit & get parent list
        $scope.EditItem = EditItem;

        function EditItem() {
            apiService.put('/api/post/update', $scope.post, function (response) {
                notificationService.DisplayInformation("Bản tin " + response.data.Name + " đã được cập nhật");
                $state.go('post');
            }, function (error) {
                notificationService.DisplayError("Cập nhất thất bại vui lòng kiểm tra lại thông tin!");
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


        function GetDetail() {
            apiService.get('/api/post/getdetail/' + $stateParams.id, null, function (response) {
                $scope.post = response.data;
            }, function () {
                notificationService.DisplayError("Không lấy được chi tiết bản tin vui lòng thử lại sau !");
            });
        }
 
        GetParentCate();
        GetDetail();

    }
})(angular.module('NanoLife.Post'))