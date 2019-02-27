(
    function (app) {
        app.controller("MenuGroupEditController", MenuGroupEditController);

        MenuGroupEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state','$stateParams'];

        function MenuGroupEditController($scope, apiService, notificationService, $state, $stateParams) {

            $scope.EditItem = EditItem;

            $scope.menuGroup = {
                Status: true,
                CreateDate: new Date()
            };

            function EditItem() {
                apiService.put('/api/menuGroup/update', $scope.menuGroup, function (response) {
                    notificationService.DisplaySuccess("Danh mục " + response.data.Name + " đã được thêm mới");
                    $state.go('menuGroup');
                }, function (error) {
                    notificationService.DisplayError("Thêm mới thất bại vui lòng kiểm tra lại thông tin!");
                    console.log(error);
                });
            }



            function GetDetailEdit() {
                apiService.get('/api/menuGroup/getdetail/' + $stateParams.id, null, function (response) {
                    $scope.menuGroup = response.data;
                }, function (error) {
                    notificationService.DisplayError(error.data);
                });
            }


            GetDetailEdit();
        }
    }
)(angular.module('NanoLife.MenuGroup'))