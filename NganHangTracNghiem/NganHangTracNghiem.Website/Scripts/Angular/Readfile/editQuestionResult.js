﻿//(function (app) {
//    'use strict';
//    app.controller('editQuestionController', questionCrt);
//    questionCrt.$inject = ['$scope', '$http', '$route', '$timeout', '$sce', '$uibModal', 'blockUI', 'toastr', 'serviceGetId'];
//    function questionCrt($scope, $http, $route, $timeout, $sce, $uibModal, blockUI, toastr, serviceGetId) {
//        blockUI.start();
//        debugger
//        $scope.trustAsHtml = $sce.trustAsHtml;
//        //lấy dữ liệu
//        $http.get("api/Question/get").then(function (response) {
//            blockUI.stop();
//            var ketqua = response.data;
//            if (ketqua != null) {
//                $scope.ListQuestions = ketqua;

//            } else {
//                toastr.error('', 'Lỗi khi tải danh sách câu hỏi ');

//            }
//        });
//        //bật pop chỉnh sửa câu hỏi
//        $scope.editQuestion = function (Id) {
//            serviceGetId.clearall();
//            serviceGetId.addData(Id);
//            $uibModal.open({
//                templateUrl: 'Scripts/Angular/Questions/popQuestion.html',
//                size: 'lg',
//                backdrop: 'static',
//                controller: 'popQuestionController',
//                controllerAs: '$ctrl'

//            });
//        };

//        $scope.deleteQuestion = function (Id) {
//            blockUI.start();

//            var IdAnswerA = null;
//            var IdAnswerB = null;
//            var IdAnswerC = null;
//            var IdAnswerD = null;

//            var r = confirm("Bạn có chắc muốn xóa câu hỏi " + Id);
//            if (r == true) {
//                $http.get(hostapi + 'api/AnswersQuestion/' + Id).then(function (response) {
//                    debugger
//                    var lsAnswer = response.data;
//                    IdAnswerA = lsAnswer[0].Id;
//                    IdAnswerB = lsAnswer[1].Id;
//                    IdAnswerC = lsAnswer[2].Id;
//                    IdAnswerD = lsAnswer[3].Id;
//                    var data = {
//                        'IdQuestion': Id,
//                        'IdAnswerA': IdAnswerA,
//                        'IdAnswerB': IdAnswerB,
//                        'IdAnswerC': IdAnswerC,
//                        'IdAnswerD': IdAnswerD

//                    }
//                    $http.post("api/Question/delete", data).then(function (response) {
//                        blockUI.stop();
//                        var ketqua = response.data;
//                        if (ketqua != null) {
//                            toastr.success('', 'Xóa câu hỏi thành công');
//                            $route.reload(true);
//                        } else {
//                            toastr.error('', 'Đã có lỗi xảy ra');

//                        }
//                    });
//                });


//            }
//        };
//    };


//    app.controller('popQuestionController', popCrt);
//    popCrt.$inject = ['$uibModalInstance', '$scope', 'blockUI', 'toastr', '$route', '$http', '$location', 'serviceGetId'];
//    function popCrt($uibModalInstance, $scope, blockUI, toastr, $route, $http, $location, serviceGetId) {
//        var Id = serviceGetId.getData();
//        var $ctrl = this;
//        var AnswerA = null;
//        var AnswerB = null;
//        var AnswerC = null;
//        var AnswerD = null;
//        $scope.CauHoi = {
//            'Diem': null,
//            'DoKho': null,
//            'DoPhanCach': null
//        }
//        $http.get(hostapi + 'api/Questions/' + Id).then(function (response) {
//            $scope.Question = response.data;

//            $('#CauHoi').val($scope.Question.Content);
//            $scope.CauHoi.Diem = $scope.Question.Mark;
//            $scope.CauHoi.DoKho = $scope.Question.Discrimination;
//            $scope.CauHoi.DoPhanCach = $scope.Question.ObjectiveDifficulty;
//            $http.get(hostapi + 'api/AnswersQuestion/' + Id).then(function (response) {
//                var lsAnswer = response.data;
//                AnswerA = lsAnswer[0];
//                $('#CauA').val(AnswerA.Content);
//                if (AnswerA.Correct == true) {
//                    $('#CauAda').prop('checked', true);
//                }
//                if (AnswerA.Interchange == true) {
//                    $('#CauAhv').prop('checked', true);
//                }
//                AnswerB = lsAnswer[1];
//                $('#CauB').val(AnswerB.Content);
//                if (AnswerB.Correct == true) {
//                    $('#CauBda').prop('checked', true);
//                }
//                if (AnswerB.Interchange == true) {
//                    $('#CauBhv').prop('checked', true);
//                }
//                AnswerC = lsAnswer[2];
//                $('#CauC').val(AnswerC.Content);
//                if (AnswerC.Correct == true) {
//                    $('#CauCda').prop('checked', true);
//                }
//                if (AnswerC.Interchange == true) {
//                    $('#CauChv').prop('checked', true);
//                }
//                AnswerD = lsAnswer[3];
//                $('#CauD').val(AnswerD.Content);
//                if (AnswerD.Correct == true) {
//                    $('#CauDda').prop('checked', true);
//                }
//                if (AnswerD.Interchange == true) {
//                    $('#CauDhv').prop('checked', true);
//                }
//            });


//        });
//        $ctrl.Submit = function () {

//            blockUI.start();
//            var hvA = false, hvB = false, hvC = false, hvD = false;
//            var daA = false, daB = false, daC = false, daD = false;
//            //lấy giá trị câu hỏi trong cleditor
//            var deBai = CKEDITOR.instances.CauHoi.getData();
//            var cauA = CKEDITOR.instances.CauA.getData();
//            var cauB = CKEDITOR.instances.CauB.getData();
//            var cauC = CKEDITOR.instances.CauC.getData();
//            var cauD = CKEDITOR.instances.CauD.getData();

//            //lấy hoán vị
//            if ($('#CauAhv').is(':checked')) {
//                hvA = true;
//            }
//            if ($('#CauBhv').is(':checked')) {
//                hvB = true;
//            }
//            if ($('#CauChv').is(':checked')) {
//                hvC = true;
//            }
//            if ($('#CauDhv').is(':checked')) {
//                hvD = true;
//            }
//            //lấy hoán vị
//            if ($('#CauAda').is(':checked')) {
//                daA = true;
//            }
//            if ($('#CauBda').is(':checked')) {
//                daB = true;
//            }
//            if ($('#CauCda').is(':checked')) {
//                daC = true;
//            }
//            if ($('#CauDda').is(':checked')) {
//                daD = true;
//            }

//            var data = {
//                'IdQuestion': $scope.Question.Id,
//                'IdAnswerA': AnswerA.Id,
//                'IdAnswerB': AnswerB.Id,
//                'IdAnswerC': AnswerC.Id,
//                'IdAnswerD': AnswerD.Id,
//                'DeBai': deBai,
//                'CauA': cauA,
//                'CauB': cauB,
//                'CauC': cauC,
//                'CauD': cauD,
//                'HoanViA': hvA,
//                'HoanViB': hvB,
//                'HoanViC': hvC,
//                'HoanViD': hvD,
//                'Diem': $scope.CauHoi.Diem,
//                'DoPhanCach': $scope.CauHoi.DoPhanCach,
//                'DoKho': $scope.CauHoi.DoKho,
//                'DapAnA': daA,
//                'DapAnB': daB,
//                'DapAnC': daC,
//                'DapAnD': daD


//            };

//            $http.post("api/Question/edit", data).then(function (response) {
//                blockUI.stop();
//                var ketqua = response.data;
//                if (ketqua == 1) {
//                    toastr.success('', 'Thêm câu hỏi mới thành công');
//                    $route.reload(true);
//                    $uibModalInstance.dismiss('cancel');
//                }
//                if (ketqua == 0) {
//                    toastr.error('', 'Thêm câu hỏi thất bại');
//                }

//            });

//        }

//        $ctrl.cancel = function () {
//            debugger
//            $uibModalInstance.dismiss('cancel');
//        };
//    };

//})(angular.module('myApp'));