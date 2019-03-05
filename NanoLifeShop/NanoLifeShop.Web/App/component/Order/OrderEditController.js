(
    function (app) {
        app.controller("OrderEditController", OrderEditController);

        OrderEditController.$inject = ['$scope', 'notificationService', 'apiService', '$state','$stateParams'];

        function OrderEditController($scope, notificationService, apiService, $state, $stateParams) {

            $scope.order = {
                Status: true
            }


            //Edit 
            $scope.EditItem = EditItem;

            function EditItem() {
                apiService.put('/api/order/update', $scope.order, function (response) {
                    notificationService.DisplaySuccess("Đơn hàng của " + response.data.CustomerName + " đã được cập nhật");
                    $state.go('Order');
                }, function (error) {
                    notificationService.DisplayError("Cập nhật thất bại vui lòng kiểm tra lại thông tin!");
                    console.log(error);
                });
            }

            function GetDetail() {
                apiService.get('/api/order/getdetail/' + $stateParams.id, null, function (response) {
                    $scope.order = response.data;
                }, function () {
                    notificationService.DisplayError("Không lấy được chi tiết bản tin vui lòng thử lại sau !");
                });
            }
            

            GetDetail();

        }
    }
)(angular.module("NanoLife.Order"))