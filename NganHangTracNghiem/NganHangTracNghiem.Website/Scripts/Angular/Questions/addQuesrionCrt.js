
(function (app) {
    'use strict';
    app.controller('QuestionController', questionCrt);
    questionCrt.$inject = ['$scope', '$http', '$route', '$timeout', 'blockUI', 'toastr', 'serviceShareData'];
    function questionCrt($scope, $http, $route, $timeout, blockUI, toastr, serviceShareData) {
        //var DapAn;
        debugger;
        $scope.CauHoi = {
            Diem: 0.5,
            DoKho: 0.5,
            DoPhanCach: 0.5
        };
        //$scope.ChapterId = serviceChapterId.getChapterId();
        $scope.ChapterId = JSON.parse(serviceShareData.getData("ChapterId"));
        $scope.ChapterId = $scope.ChapterId[0];
        $scope.submit = function () {
            debugger;
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
                'HoanViS': hvD,
                'Diem': $scope.CauHoi.Diem,
                'DoPhanCach': $scope.CauHoi.DoPhanCach,
                'DoKho': $scope.CauHoi.DoKho,
                'DapAnA': daA,
                'DapAnB': daB,
                'DapAnC': daC,
                'DapAnD': daD


            };
          
            $http.post("api/Question/add", data).then(function(response) {
            
                blockUI.stop();
                var ketqua = response.data;
                if (ketqua == 1) {
                    debugger;
             
                    toastr.success('', 'Thêm câu hỏi mới thành công');
                    $route.reload(true);
                }
                if (ketqua == 0) {
                    toastr.success('', 'Thêm câu hỏi thất bại');
                }
                
            });
            
        }

    };
})(angular.module('myApp'));