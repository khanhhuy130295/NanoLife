(
    function (app) {
        app.controller("MenuGroupListController", MenuGroupListController);

        MenuGroupListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

        function MenuGroupListController($scope, apiService, notificationService, $ngBootbox, $filter) {
            $scope.DataGroup = [];
            $scope.GetlistData = GetlistData;
            $scope.keyword = '';

            $scope.searchClick = search;

            //Search
            function search() {
                GetlistData();
            }

            $('#txtSearch').off('keypress').on('keypress', function (e) {
                if (e.which == 13) {
                    search();
                }
            })

            //Show data
            function GetlistData(page) {
                page = page || 0;

                var config = {
                    params: {
                        keyword: $scope.keyword,
                        page: page,
                        pageSize: 50,
                    }
                };

                apiService.get("/api/menuGroup/getall", config, function (response) {

                    if (response.data.TotalCount == 0) {
                        notificationService.DisplayWarning("Không có dữ liệu !");
                    }
                    $scope.DataGroup = response.data.Items;
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
                    angular.forEach($scope.DataGroup, function (item) {
                        item.check = true;
                    });

                    $scope.isSelectedAll = true;
                }
                else {
                    angular.forEach($scope.DataGroup, function (item) {
                        item.check = false;
                    });

                    $scope.isSelectedAll = false;
                }
            }

            $scope.$watch("DataGroup", function (n, o) {
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


            $scope.CountItemSelected = 0;

            $scope.DeleteItem = DeleteItem;

            function DeleteItem(id) {

                $ngBootbox.confirm('Bạn muốn xóa danh mục này ?')
                    .then(function () {
                        var config = {
                            params: {
                                ID: id
                            }
                        }
                        apiService.dele('/api/menuGroup/delete', config, function (result) {
                            notificationService.DisplayInformation('Xóa thành công danh mục ' + ' ' + result.data.Name);
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

                $ngBootbox.confirm('Bạn muốn xóa những danh mục này ?')
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

                        apiService.dele('/api/menuGroup/deleteMulti', config, function (response) {
                            notificationService.DisplayInformation('Xóa thành công ' + response.data + ' Danh mục.');
                            search();
                        }, function () {
                            notificationService.DisplayError('Xóa thất bại !');
                        });
                    }, function () {
                        notificationService.DisplayWarning('Bạn vừa hủy thao tác xóa bản ghi !');
                    });
            }

        }
    }
)(angular.module('NanoLife.MenuGroup'))