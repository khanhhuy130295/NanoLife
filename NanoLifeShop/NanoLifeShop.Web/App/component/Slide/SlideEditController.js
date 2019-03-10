(
    function (app) {
        app.controller("SlideEditController", SlideEditController);

        SlideEditController.$inject = ['$scope', 'notificationService', 'apiService', '$state','$stateParams'];

        function SlideEditController($scope, notificationService, apiService, $state, $stateParams) {

            $scope.slide = {
                Status: true
            }

            $scope.ckeditorOptions = {
                height: '200px'
            };

            //Edit 
            $scope.EditItem = EditItem;

            function EditItem() {
                apiService.put('/api/slide/update', $scope.slide, function (response) {
                    notificationService.DisplaySuccess("Slide " + response.data.Name + " đã được cập nhật");
                    $state.go('Slide');
                }, function (error) {
                    notificationService.DisplayError("Cập nhật thất bại vui lòng kiểm tra lại thông tin!");
                    console.log(error);
                });
            }


            function GetDetail() {
                apiService.get('/api/slide/getdetail/' + $stateParams.id, null, function (response) {
                    $scope.slide = response.data;
              
                }, function (error) {
                    notificationService.DisplayError("Không tìm thấy chi tiết Slide!");
                    console.log(error);
                });
            }

            GetDetail();


        }
    }
)(angular.module('NanoLife.Slide'))