(
    function (app) {
        app.controller("SupportEditController", SupportEditController);

        SupportEditController.$inject = ['$scope', 'notificationService', 'apiService', '$state','$stateParams'];

        function SupportEditController($scope, notificationService, apiService, $state, $stateParams) {

            $scope.support = {
                Status: true
            }


            //Add & get parent list
            $scope.EditItem = EditItem;

            function EditItem() {
                apiService.put('/api/supportonline/update', $scope.support, function (response) {
                    notificationService.DisplaySuccess("Danh sách" +' ' +response.data.Name + " đã được cập nhật");
                    $state.go('Support');
                }, function (error) {
                    notificationService.DisplayError("Thêm mới thất bại vui lòng kiểm tra lại thông tin!");
                    console.log(error);
                });
            }

            function GetDetail() {
                apiService.get('/api/supportonline/getdetail/' + $stateParams.id, null, function (response) {
                    $scope.support = response.data;
                }, function () {
                    notificationService.DisplayError("Chi tiết nhân viên hỗ trợ không có dữ liệu !");
                });
            }

            GetDetail();

        }
    }
)(angular.module('NanoLife.SupportOnline'))