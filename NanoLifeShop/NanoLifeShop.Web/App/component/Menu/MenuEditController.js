(
    function (app) {
        app.controller("MenuEditController", MenuEditController);

        MenuEditController.$inject = ['$scope', 'notificationService', 'apiService', '$state','$stateParams'];

        function MenuEditController($scope, notificationService, apiService, $state, $stateParams) {

            $scope.menu = {
                Status: true
            }


            //Edit & get parent list
            $scope.EditItem = EditItem;

            function EditItem() {
                apiService.put('/api/menu/update', $scope.menu, function (response) {
                    notificationService.DisplaySuccess("Menu " + response.data.Name + " đã được cập nhật");
                    $state.go('Menu');
                }, function (error) {
                    notificationService.DisplayError("Thêm mới thất bại vui lòng kiểm tra lại thông tin!");
                    console.log(error);
                });
            }


            function GetParent() {
                apiService.get('/api/menuGroup/getparent', null, function (response) {
                    $scope.parentMenu = response.data;
                }, function () {
                    notificationService.DisplayError("Không lấy được danh mục tin tức !");
                });
            }


            function GetDetail(){
                apiService.get('/api/menu/getdetail/' + $stateParams.id, null, function (response) {
                    $scope.menu = response.data;
                }, function () {
                    notificationService.DisplayError("Chi tiết Menu không có dữ liệu !");
                });
            }

            GetParent();
            GetDetail();
        }
    }
)(angular.module("NanoLife.Menu"))