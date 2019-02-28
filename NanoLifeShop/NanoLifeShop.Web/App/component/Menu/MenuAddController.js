(
    function (app) {
        app.controller("MenuAddController", MenuAddController);

        MenuAddController.$inject = ['$scope', 'notificationService', 'apiService', '$state'];

        function MenuAddController($scope, notificationService, apiService, $state) {

            $scope.menu = {
                Status: true
            }


            //Add & get parent list
            $scope.AddItem = AddItem;

            function AddItem() {
                apiService.post('/api/menu/create', $scope.menu, function (response) {
                    notificationService.DisplaySuccess("Menu " + response.data.Name + " đã được thêm mới");
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


            GetParent();
        }
    }
)(angular.module("NanoLife.Menu"))