(function (app) {
    app.controller('postListController', postListController);
    postListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function postListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.DataPost = [];

        //search
        $scope.keyword = '';
        $scope.searchClick = search;

        function search() {
            GetlistData();
        }

        //Get data
        $scope.GetlistData = GetlistData;

        function GetlistData(page) {
            page = page || 0;

            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 50,
                }
            };

            apiService.get("/api/post/getall", config, function (response) {
                if (response.data.TotalCount == 0) {
                    notificationService.DisplayWarning("Không có dữ liệu !");
                }
                $scope.DataPost = response.data.Items;
                $scope.page = response.data.Page;
                $scope.pagesCount = response.data.TotalPages;
                $scope.totalCount = response.data.TotalCount;
            }, function (error) {
                console.log(error);
            });
        }

        $scope.GetlistData();

        //Delete Single and Multi
        $scope.isSelectedAll = false;
        $scope.SelecteAll = SelecteAll;

        function SelecteAll() {
            if ($scope.isSelectedAll === false) {
                angular.forEach($scope.DataPost, function (item) {
                    item.check = true;
                });

                $scope.isSelectedAll = true;
            }
            else {
                angular.forEach($scope.DataPost, function (item) {
                    item.check = false;
                });

                $scope.isSelectedAll = false;
            }
        }

        $scope.CountItemSelected = 0;

        $scope.$watch("DataPost", function (n, o) {
            var checked = $filter("filter")(n, { check: true });
            if (checked.length) {
                $scope.selected = checked;
                $scope.CountItemSelected = $scope.selected.length;
                $('#btnDelete').removeAttr('disabled');
            }
            else {
                $('#btnDelete').attr('disabled', 'disabled');
                $scope.CountItemSelected = 0;
            }
        }, true);

        $scope.DeleteItem = DeleteItem;

        function DeleteItem(id) {
            $ngBootbox.confirm('Bạn muốn xóa bản tin này ?')
                .then(function () {
                    var config = {
                        params: {
                            ID: id
                        }
                    }
                    apiService.dele('/api/post/delete', config, function (result) {
                        notificationService.DisplayInformation('Xóa thành công bản tin ' + ' ' + result.data.Name);
                        search();
                    }, function () {
                        notificationService.DisplayError('Xóa thất bại !');
                    });
                }, function () {
                    notificationService.DisplayWarning('Bạn vừa hủy thao tác xóa bản ghi !');
                });
        }

        $scope.DeleMultiProCate = DeleMultiProCate;

        function DeleMultiProCate() {
            $ngBootbox.confirm('Bạn muốn xóa những bản tin này ?')
                .then(function () {
                    var ListItemDelete = [];
                    $.each($scope.selected, function (i, item) {
                        ListItemDelete.push(item.ID);
                    });

                    var config = {
                        params: {
                            ListItem: JSON.stringify(ListItemDelete)
                        }
                    };

                    apiService.dele('/api/post/deleteMulti', config, function (response) {
                        notificationService.DisplayInformation('Xóa thành công ' + response.data + 'Bản tin .');
                        search();
                    }, function () {
                        notificationService.DisplayError('Xóa thất bại !');
                    });
                }, function () {
                    notificationService.DisplayWarning('Bạn vừa hủy thao tác xóa bản ghi !');
                });
        }
    }
})(angular.module('NanoLife.Post'))