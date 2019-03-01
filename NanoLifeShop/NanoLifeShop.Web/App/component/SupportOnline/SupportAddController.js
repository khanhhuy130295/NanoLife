(
    function (app) {
        app.controller("SupportAddController", SupportAddController);

        SupportAddController.$inject = ['$scope', 'notificationService', 'apiService', '$state'];

        function SupportAddController($scope, notificationService, apiService, $state) {

            $scope.support = {
                Status: true
            }


            //Add & get parent list
            $scope.AddItem = AddItem;

            function AddItem() {
                apiService.post('/api/supportonline/create', $scope.support, function (response) {
                    notificationService.DisplaySuccess("Danh sách" +' ' + response.data.Name + " đã được thêm mới");
                    $state.go('Support');
                }, function (error) {
                    notificationService.DisplayError("Thêm mới thất bại vui lòng kiểm tra lại thông tin!");
                    console.log(error);
                });
            }

        }
    }
)(angular.module('NanoLife.SupportOnline'))