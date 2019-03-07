(
    function (app) {
        app.controller("FeedBackAddController", FeedBackAddController);

        FeedBackAddController.$inject = ['$scope', 'notificationService', 'apiService', '$state'];

        function FeedBackAddController($scope, notificationService, apiService, $state) {

            $scope.feedBack = {
                Status: true,
                CreateDate: new Date()
            }

            $scope.ckeditorOptions = {
                height: '200px'
            };



            //Add & get parent list
            $scope.AddItem = AddItem;

            function AddItem() {
                apiService.post('/api/feedback/create', $scope.feedBack, function (response) {
                    notificationService.DisplaySuccess("Phản hồi" + response.data.Name + " đã được thêm mới");
                    $state.go('FeedBack');
                }, function (error) {
                    notificationService.DisplayError("Thêm mới thất bại vui lòng kiểm tra lại thông tin!");
                    console.log(error);
                });
            }

       
        }
    }
)(angular.module("NanoLife.FeedBack"))