(
    function (app) {
        app.controller("StatisticController", StatisticController);

        StatisticController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

        function StatisticController($scope, apiService, notificationService, $ngBootbox, $filter) {

            var config = {
                param: {

                    fromDate: '',
                    toDate: ''
                }
            }

            //Config DatePicker with momentjs
            var start = moment().subtract(29, 'days');
            var end = moment();

            function cb(start, end) {
                $('#daterange-btn span').html(start.format('L') + ' - ' + end.format('L'));

                config.param.fromDate = start.format('YYYY-MM-DD');
                config.param.toDate = end.format('YYYY-MM-DD');
            }

            $('#daterange-btn').daterangepicker({
                "showWeekNumbers": true,
                ranges: {
                    'Hôm nay': [moment(), moment()],
                    'Hôm qua': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                    '7 Ngày': [moment().subtract(6, 'days'), moment()],
                    '30 Ngày': [moment().subtract(29, 'days'), moment()],
                    'Tháng này': [moment().startOf('month'), moment().endOf('month')],
                    'Tháng trước': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                },
                "locale": {
                    "format": "MM-DD-YYYY",
                    "separator": " - ",
                    "applyLabel": "Đồng ý",
                    "cancelLabel": "Hủy",
                    "fromLabel": "From",
                    "toLabel": "To",
                    "customRangeLabel": "Custom",
                    "firstDay": 1
                },
                startDate: start,
                endDate: end,
                "opens": "center",
            }, cb);

            //end

            $scope.applySettingEvent = getListRevenues;

                function getListRevenues() {
                    if (config.param.fromDate == '' || config.param.toDate == '') {
                        notificationService.displayWarning('Vui lòng chọn khoảng thời gian cần thống kê!');
                        return;
                    }
                    apiService.get('/api/revenues/getlist?fromDate=' + config.param.fromDate + '&toDate=' + config.param.toDate, null,
                        function (response) {
                            console.log(response);
                        }, function () {
                            notificationService.DisplayError('Không thể tải dữ liệu!');
                        });
                }

            cb(start, end);
            getListRevenues();
        }
    }
)(angular.module("NanoLife.Statistic"))