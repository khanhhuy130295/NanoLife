(
    function (app) {
        app.controller("SlideAddController", SlideAddController);

        SlideAddController.$inject = ['$scope', 'notificationService', 'apiService', '$state'];

        function SlideAddController($scope, notificationService, apiService, $state) {

            $scope.slide = {
                Status: true
            }

            $scope.ckeditorOptions = {
                height: '200px'
            };

            //Add & get parent list
            $scope.AddItem = AddItem;

            function AddItem() {
                apiService.post('/api/slide/create', $scope.slide, function (response) {
                    notificationService.DisplaySuccess("Slide " + response.data.Name + " đã được thêm mới");
                    $state.go('Slide');
                }, function (error) {
                    notificationService.DisplayError("Thêm mới thất bại vui lòng kiểm tra lại thông tin!");
                    console.log(error);
                });
            }

          
        }
    }
)(angular.module('NanoLife.Slide'))