(function (app) {
    app.controller('postCateEditController', postCateEditController);

    postCateEditController.$inject = ['$scope', 'apiService', 'notificationService', 'commonService', '$state', '$stateParams'];

    function postCateEditController($scope, apiService, notificationService, commonService, $state, $stateParams) {

        $scope.EditItem = EditItem;

        $scope.postCate = {
            UpdateDate: new Date(),
            Status:  true
        }

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


        function EditItem() {
            apiService.put('/api/postCategory/update', $scope.postCate, function (response) {
                notificationService.DisplaySuccess("Danh mục " + response.data.Name + " đã được cập nhật");
                $state.go('postCategory');
            }, function (error) {
                notificationService.DisplayError("Cập nhật thất bại vui lòng kiểm tra lại thông tin!");
                console.log(error);
            });
        }

        function GetDetailEdit() {
            apiService.get('/api/postCategory/getdetail/' + $stateParams.id, null, function (response) {
                $scope.postCate = response.data;
            }, function (error) {
                notificationService.DisplayError(error.data);
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

        GetDetailEdit();

    }

})(angular.module('NanoLife.PostCategory'))