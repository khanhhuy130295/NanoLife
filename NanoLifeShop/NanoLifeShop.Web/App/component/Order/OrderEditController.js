(
    function (app) {
        app.controller("OrderEditController", OrderEditController);

        OrderEditController.$inject = ['$scope', 'notificationService', 'apiService', '$state', '$stateParams'];

        function OrderEditController($scope, notificationService, apiService, $state, $stateParams) {

            $scope.order = {
                Status: true
            }

            $scope.orderDetail = {
                dataOrderDetail: [],            
            };


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



            var config = {
                params: {
                    idOrder: $stateParams.id,
                    page: 1,
                    pageSize: 50,
                }
            };

            $scope.getOrderDetailList = function () {
                apiService.get("/api/orderDetail/getall", config, function (response) {

                    if (response.data.TotalCount == 0) {
                        notificationService.DisplayWarning("Không có dữ liệu !");
                    }

                    console.log(response.data);
                    $scope.orderDetail.dataOrderDetail = response.data.Items;
                 
                }, function (error) {
                    console.log(error);
                });
            }


            function GetPaymentMethod() {
                apiService.get('/api/paymentMethod/getparent', null, function (response) {
                    $scope.paymentMethodList = response.data;
                }, function () {
                    notificationService.DisplayError("Không lấy được phương thức thanh toán !");
                });
            }


            GetDetail();
            GetPaymentMethod();

        }
    }
)(angular.module("NanoLife.Order"))