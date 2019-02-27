(
    function (app) {
        app.controller("MenuGroupAddController", MenuGroupAddController);

        MenuGroupAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state'];

        function MenuGroupAddController($scope, apiService, notificationService, $state) {

            $scope.AddItem = AddItem;

            $scope.menuGroup = {
                Status: true,
                CreateDate: new Date()
            };

            function AddItem() {
                apiService.post('/api/menuGroup/create', $scope.menuGroup, function (response) {
                    notificationService.DisplaySuccess("Danh mục " + response.data.Name + " đã được thêm mới");
                    $state.go('menuGroup');
                }, function (error) {
                    notificationService.DisplayError("Thêm mới thất bại vui lòng kiểm tra lại thông tin!");
                    console.log(error);
                });
            }

        }
    }
)(angular.module('NanoLife.MenuGroup'))