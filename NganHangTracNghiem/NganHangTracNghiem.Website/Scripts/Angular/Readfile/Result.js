//var LsQuestions_Success;
//var LsQuestions_Error;
(function (app) {
    'use strict';

    app.controller('Result', resultCrt);
    resultCrt.$inject = ['$scope', '$sce', '$http', '$location', 'blockUI', 'toastr', 'serviceShareData', '$uibModal', '$route', '$timeout'];
    function resultCrt($scope, $sce, $http, $location, blockUI, toastr, serviceShareData, $uibModal, $route, $timeout) {
        $scope.from = {};
        $scope.pageSize = 3;
        $scope.currentPage = 1;
        $scope.pageSizeErr = 3;
        $scope.currentPageErr = 1;
        $scope.trustAsHtml = $sce.trustAsHtml;
        $scope.ListQuestions = null;
        $scope.ListQuestions = serviceShareData.getData('datareadfile');
        var ListQuestions = JSON.parse($scope.ListQuestions);
        $scope.Question_Successs = ListQuestions[0].Question_Success;
        debugger;
        $scope.Question_Errors = ListQuestions[0].Question_Error;
        $scope.editQuestion = function (question,id) {
            serviceShareData.clearall('id');
            serviceShareData.addData(id, 'id');
            serviceShareData.clearall('dataeditquestion');
            serviceShareData.addData(question, 'dataeditquestion');
            $uibModal.open({
                templateUrl: 'Scripts/Angular/Readfile/editQuestionResult.html',
                size: 'lg',
                backdrop: 'static',
                controller: 'popQuestionResultController',
                controllerAs: '$ctrl'
            });
        };
        $scope.deleteQuestion = function (Id) {
            var r = confirm("Bạn có chắc muốn xóa câu hỏi này");
            if (r == true) {
                
                var question_delete = ListQuestions[0].Question_Error[Id];
                $scope.ListQuestions = ListQuestions;
                $scope.ListQuestions[0].Question_Error.splice(question_delete,1);
                toastr.success('', 'Xóa câu hỏi thành công');
                serviceShareData.clearall('datareadfile');

                var SelectedValue = $scope.ListQuestions[0];
                serviceShareData.addData(SelectedValue, 'datareadfile');
                $route.reload(true);
            }
        };

    }
    app.controller('popQuestionResultController', popCrt);
    popCrt.$inject = ['$uibModalInstance', '$scope', 'blockUI', 'toastr', '$route', '$http', '$location', 'serviceGetId', 'serviceShareData'];
    function popCrt($uibModalInstance, $scope, blockUI, toastr, $route, $http, $location, serviceGetId, serviceShareData) {
        var $ctrl = this;
        var AnswerA = null;
        var AnswerB = null;
        var AnswerC = null;
        var AnswerD = null;
        $scope.CauHoi = {
            'Diem': null,
            'DoKho': null,
            'DoPhanCach': null
        }
        $scope.Question = JSON.parse(serviceShareData.getData('dataeditquestion'));
        $scope.Question = $scope.Question[0];

        $scope.CauHoi.Diem = $scope.Question.Question.Mark;
        $scope.CauHoi.DoKho = $scope.Question.Question.Discrimination;
        $scope.CauHoi.DoPhanCach = $scope.Question.Question.SubjectiveDifficulty;
        AnswerA = $scope.Question.Answer[0];
        $(document).ready(function () {
            $('#CauHoi').val($scope.Question.Question.Content);

            $('#CauA').val(AnswerA.Content);
            if (AnswerA.Correct == true) {
                $('#CauAda').prop('checked', true);
            }
            if (AnswerA.Interchange == true) {
                $('#CauAhv').prop('checked', true);
            }
            AnswerB = $scope.Question.Answer[1];
            $('#CauB').val(AnswerB.Content);
            if (AnswerB.Correct == true) {
                $('#CauBda').prop('checked', true);
            }
            if (AnswerB.Interchange == true) {
                $('#CauBhv').prop('checked', true);
            }
            AnswerC = $scope.Question.Answer[2];
            $('#CauC').val(AnswerC.Content);
            if (AnswerC.Correct == true) {
                $('#CauCda').prop('checked', true);
            }
            if (AnswerC.Interchange == true) {
                $('#CauChv').prop('checked', true);
            }
            AnswerD = $scope.Question.Answer[3];
            $('#CauD').val(AnswerD.Content);
            if (AnswerD.Correct == true) {
                $('#CauDda').prop('checked', true);
            }
            if (AnswerD.Interchange == true) {
                $('#CauDhv').prop('checked', true);
            }
        });
        
     
        $ctrl.Submit = function () {

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
                'IdQuestion': $scope.Question.Question.Id,
                'IdAnswerA': AnswerA.Id,
                'IdAnswerB': AnswerB.Id,
                'IdAnswerC': AnswerC.Id,
                'IdAnswerD': AnswerD.Id,
                'DeBai': deBai,
                'CauA': cauA,
                'CauB': cauB,
                'CauC': cauC,
                'CauD': cauD,
                'HoanViA': hvA,
                'HoanViB': hvB,
                'HoanViC': hvC,
                'HoanViD': hvD,
                'Diem': $scope.CauHoi.Diem,
                'DoPhanCach': $scope.CauHoi.DoPhanCach,
                'DoKho': $scope.CauHoi.DoKho,
                'DapAnA': daA,
                'DapAnB': daB,
                'DapAnC': daC,
                'DapAnD': daD


            };
            debugger;
            $http.post("api/Question/add", data).then(function (response) {
                blockUI.stop();
                var ketqua = response.data;
                if (ketqua == 1) {
                    toastr.success('', 'Thêm câu hỏi mới thành công');
                    $scope.ListQuestions = null;
                    $scope.ListQuestions = serviceShareData.getData('datareadfile');
                    var ListQuestions = JSON.parse($scope.ListQuestions);
                    var id = JSON.parse(serviceShareData.getData('id'));
                    var question_delete = ListQuestions[0].Question_Error[id];
                    $scope.ListQuestions = ListQuestions;
                    $scope.ListQuestions[0].Question_Error.splice(question_delete, 1);
                    $scope.ListQuestions[0].Question_Success.push(question_delete);
                    serviceShareData.clearall('datareadfile');
                    var SelectedValue = $scope.ListQuestions[0];
                    serviceShareData.addData(SelectedValue, 'datareadfile');
                    $route.reload(true);
                    $uibModalInstance.dismiss('cancel');
                }
                if (ketqua == 0) {
                    toastr.error('', 'Thêm câu hỏi thất bại');
                }

            });

        }

        $ctrl.cancel = function () {
            debugger
            $uibModalInstance.dismiss('cancel');
        };
    };

})(angular.module('myApp'));



