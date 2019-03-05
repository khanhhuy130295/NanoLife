(
    function (app) {
        app.controller("OrderAddController", OrderAddController);

        OrderAddController.$inject = ['$scope', 'notificationService', 'apiService', '$state'];

        function OrderAddController($scope, notificationService, apiService, $state) {

            $scope.order = {
                Status: true
            }


            //Add & get parent list
            $scope.AddItem = AddItem;

            function AddItem() {
                apiService.post('/api/order/create', $scope.order, function (response) {
                    notificationService.DisplaySuccess("Đơn hàng " + response.data.Name + " đã được thêm mới");
                    $state.go('Order');
                }, function (error) {
                    notificationService.DisplayError("Thêm mới thất bại vui lòng kiểm tra lại thông tin!");
                    console.log(error);
                });
            }


          
        }
    }
)(angular.module("NanoLife.Order"))