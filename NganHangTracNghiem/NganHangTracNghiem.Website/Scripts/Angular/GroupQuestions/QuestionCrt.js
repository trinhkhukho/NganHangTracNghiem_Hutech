
(function (app) {
    'use strict';
    app.controller('QuestionGroupChilController', questionCrt);
    questionCrt.$inject = ['$scope', '$http', '$route', '$timeout', '$sce', 'blockUI', 'toastr', 'serviceGetId'];
    function questionCrt($scope, $http, $route, $timeout, $sce, blockUI, toastr, serviceGetId) {
        //var DapAn;
        $scope.trustAsHtml = $sce.trustAsHtml;
        debugger;
        var parentId = serviceGetId.getData();
        var ListUserId = JSON.parse(serviceShareData.getData("UserId"));
        var userid = ListUserId[0];
        //serviceGetId.clearall();
        $http.get(hostapi + 'api/Questions/' + parentId).then(function (response) {

            $scope.Parent = response.data.Content;
            debugger;
        });
        $scope.addQuestion = function () {
            blockUI.start();
            var hvA = false, hvB = false, hvC = false, hvD = false;
            var daA = false, daB = false, daC = false, daD = false;
            //lấy giá trị câu hỏi trong cleditor
            var deBai = CKEDITOR.instances.CauHoi.getData();
            var cauA = CKEDITOR.instances.CauA.getData();
            var cauB = CKEDITOR.instances.CauB.getData();
            var cauC = CKEDITOR.instances.CauC.getData();
            var cauD = CKEDITOR.instances.CauD.getData();
            //lấy hoán vị
            if ($('#CauAhv').is(':checked')) {
                hvA = true;
            }
            if ($('#CauBhv').is(':checked')) {
                hvB = true;
            }
            if ($('#CauChv').is(':checked')) {
                hvC = true;
            }
            if ($('#CauDhv').is(':checked')) {
                hvD = true;
            }
            //lấy hoán vị
            if ($('#CauAda').is(':checked')) {
                daA = true;
            }
            if ($('#CauBda').is(':checked')) {
                daB = true;
            }
            if ($('#CauCda').is(':checked')) {
                daC = true;
            }
            if ($('#CauDda').is(':checked')) {
                daD = true;
            }
            var data = {
                'DeBai': deBai,
                'CauA': cauA,
                'CauB': cauB,
                'CauC': cauC,
                'CauD': cauD,
                'HoanViA': hvA,
                'HoanViB': hvB,
                'HoanViC': hvC,
                'HoanViD': hvD,
                'DapAnA': daA,
                'DapAnB': daB,
                'DapAnC': daC,
                'DapAnD': daD,
                'ParentId': parentId,
                'UserId': userid
            };
            $http.post("api/Question/addGroupChil", data).then(function (response) {
                blockUI.stop();
                var ketqua = response.data;
                if (ketqua === 1) {
                    toastr.success('', 'Thêm câu hỏi nhóm thành công');
                    var abd = data.ParentId;
                    serviceGetId.addData(parentId);
                    $route.reload(true);
                }
                if (ketqua === 0) {
                    toastr.success('', 'Thêm câu hỏi nhóm thất bại');
                }

            });

        }

    };
})(angular.module('myApp'));