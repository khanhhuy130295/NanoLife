(
    function (app) {
        app.controller("FeedBackEditController", FeedBackEditController);

        FeedBackEditController.$inject = ['$scope', 'notificationService', 'apiService', '$state','$stateParams'];

        function FeedBackEditController($scope, notificationService, apiService, $state, $stateParams) {

            $scope.feedBack = {
                Status: true,
                CreateDate: new Date()
            }

            $scope.ckeditorOptions = {
                height: '200px'
            };

            //Edit & get parent list
            $scope.EditItem = EditItem;

            function EditItem() {
                apiService.put('/api/feedback/update', $scope.feedBack, function (response) {
                    notificationService.DisplaySuccess("Phản hồi"+" " + response.data.Name + " đã được cập nhật");
                    $state.go('FeedBack');
                }, function (error) {
                    notificationService.DisplayError("Thêm mới thất bại vui lòng kiểm tra lại thông tin!");
                    console.log(error);
                });
            }


            function GetDetail() {
                apiService.get('/api/feedback/getdetail/' + $stateParams.id, null, function (response) {
                    $scope.feedBack = response.data;
                }, function () {
                    notificationService.DisplayError("Chi tiết phản hồi không có dữ liệu !");
                });
            }

            GetDetail();
        }
    }
)(angular.module("NanoLife.FeedBack"))