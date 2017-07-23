(function (app) {
    'use strict';
    app.controller('editQuestionController', questionCrt);
    questionCrt.$inject = ['$scope', '$http', '$route', '$timeout', '$sce', '$uibModal', 'blockUI', 'toastr', 'serviceGetId', '$filter', 'serviceShareData', '$location'];
    function questionCrt($scope, $http, $route, $timeout, $sce, $uibModal, blockUI, toastr, serviceGetId, $filter, serviceShareData, $location) {
        //kiểm tra đăng nhập.
        $scope.decentralization;
        $scope.decentralizations = serviceShareData.getData('UserDecen');
        if ($scope.decentralizations.length <= 0) {
            $location.url('login');
        }
        else {
            $scope.decentralization = JSON.parse($scope.decentralizations)[0];
            var data_decen_faculties = [];
            var data_decen_subject = [];
            var data_decen_chapter = [];
            debugger;
            for (var i = 0; i < $scope.decentralization.length; i++) {
                if ($scope.decentralization[i].FacultiesId != null) {
                    var status_f = 0;
                    for (var j = 0; j < data_decen_faculties.length; j++) {
                        if (data_decen_faculties[j] == $scope.decentralization[i].FacultiesId) {
                            status_f = 1;
                        }
                    }
                    if (status_f == 0) {
                        data_decen_faculties.push($scope.decentralization[i].FacultiesId);
                    }
                }
                if ($scope.decentralization[i].SubjectId != null) {
                    var status_s = 0;
                    for (var j = 0; j < data_decen_subject.length; j++) {
                        if (data_decen_subject[j] == $scope.decentralization[i].SubjectId) {
                            status_s = 1;
                        }
                    }
                    if (status_s == 0) {
                        data_decen_subject.push($scope.decentralization[i].SubjectId);
                    }
                }
                if ($scope.decentralization[i].ChapterId != null) {
                    data_decen_chapter.push($scope.decentralization[i].ChapterId);
                }
            }
        }


        $scope.trustAsHtml = $sce.trustAsHtml;
        $scope.ListQuestions = [];


        //truyền dữ liệu vào dropdowlist
        $scope.Selected = {
            FacultiesSelected: "",
            SubjectsSelected: "",
            ChapterSelected: ""
        };
        $http.post(hostapi + 'api/GetDecentralizationFaculties', data_decen_faculties).then(function (response) {
            debugger;
            $scope.Faculties = response.data;

        });
        $http.post(hostapi + 'api/GetDecentralizationSubject', data_decen_subject).then(function (response) {
            debugger;
            $scope.Subjects = response.data;
        });
        $http.post(hostapi + 'api/GetDecentralizationChapter', data_decen_chapter).then(function (response) {
            debugger;
            $scope.chapters = response.data;
        });
        $scope.SelectFacultie = function () {
            if ($scope.Subjects != null) {
                $scope.Selected.FacultiesSelected = document.getElementById("faculties").value;
                $scope.SubjectResult = $scope.Subjects.filter(function (s) {
                    return (s.FacultyId == $scope.Selected.FacultiesSelected);
                });
            }

        };
        $scope.SelectSubject = function () {

            if ($scope.chapters != null) {
                $scope.Selected.SubjectsSelected = document.getElementById("subjects").value;
                $scope.ChapterResult = $scope.chapters.filter(function (s) {
                    return (s.SubjectId == $scope.Selected.SubjectsSelected);
                });
            }
        };
        $scope.SelectChapter = function () {
            $scope.Selected.ChapterSelected = document.getElementById("chapters").value;
        };
        $scope.datatime1 = new Date();
        $scope.openDataPicker1 = function () {
            $scope.popup1.opened = true;
        };
        $scope.popup1 = {
            opened: false
        };
        $scope.datatime2 = new Date();
        $scope.openDataPicker2 = function () {
            $scope.popup2.opened = true;
        };
        $scope.popup2 = {
            opened: false
        };
        $scope.QuestionSearch = {
            "FacultiesSelected": 0,
            "SubjectsSelected": 0,
            "ChapterSelected": 0
        };




        //nhấn nút search

        $scope.Search = function () {
            var dataSearch = {
                "chapterId": $scope.QuestionSearch.ChapterSelected,
                "subjectId": $scope.QuestionSearch.SubjectsSelected,
                "facultiesId": $scope.QuestionSearch.FacultiesSelected,
                "starDate": new Date(),
                "endDate": new Date()
            };
            debugger;
            dataSearch.starDate = new Date("2017-07-22");
            dataSearch.endDate = new Date("2017-07-23");
            dataSearch.starDate = $scope.datatime1;
            dataSearch.endDate = $scope.datatime2;
            blockUI.start();
            $http.post(hostapi + "api/SearchQuestion", dataSearch).then(function (response) {
                blockUI.stop();
                debugger
                var ketqua = response.data;
                if (ketqua != null) {
                    debugger;
                    $scope.ListQuestions = ketqua;
                    $scope.pageSize = 10;
                    $scope.currentPage = 1;
                } else {
                    toastr.error('', 'Lỗi khi tải danh sách câu hỏi ');
                }
            });
            //$http.get("api/Question/get").then(function (response) {
            //    blockUI.stop();
            //    var ketqua = response.data;

            //    if (ketqua != null) {
            //        debugger;
            //        $scope.ListQuestions = ketqua;
            //        $scope.pageSize = 10;
            //        $scope.currentPage = 1;
            //    } else {
            //        toastr.error('', 'Lỗi khi tải danh sách câu hỏi ');

            //    }
            //});
        }

        //bật pop chỉnh sửa câu hỏi
        $scope.editQuestion = function (Id) {
            serviceGetId.clearall();
            serviceGetId.addData(Id);
            $uibModal.open({
                templateUrl: 'Scripts/Angular/Questions/popQuestion.html',
                size: 'lg',
                backdrop: 'static',
                controller: 'popQuestionController',
                controllerAs: '$ctrl'

            });
        };

        $scope.deleteQuestion = function (Id) {
            blockUI.start();

            var IdAnswerA = null;
            var IdAnswerB = null;
            var IdAnswerC = null;
            var IdAnswerD = null;

            var r = confirm("Bạn có chắc muốn xóa câu hỏi " + Id);
            if (r == false) {
                blockUI.stop();
            }
            if (r == true) {
                $http.get(hostapi + 'api/AnswersQuestion/' + Id).then(function (response) {
                    debugger
                    var lsAnswer = response.data;
                    IdAnswerA = lsAnswer[0].Id;
                    IdAnswerB = lsAnswer[1].Id;
                    IdAnswerC = lsAnswer[2].Id;
                    IdAnswerD = lsAnswer[3].Id;
                    var data = {
                        'IdQuestion': Id,
                        'IdAnswerA': IdAnswerA,
                        'IdAnswerB': IdAnswerB,
                        'IdAnswerC': IdAnswerC,
                        'IdAnswerD': IdAnswerD

                    }
                    $http.post("api/Question/delete", data).then(function (response) {
                        blockUI.stop();
                        var ketqua = response.data;
                        if (ketqua != null) {
                            toastr.success('', 'Xóa câu hỏi thành công');
                            $route.reload(true);
                        } else {
                            toastr.error('', 'Đã có lỗi xảy ra');

                        }
                    });
                });


            }

        };

    };


    app.controller('popQuestionController', popCrt);
    popCrt.$inject = ['$uibModalInstance', '$scope', 'blockUI', 'toastr', '$route', '$http', '$location', 'serviceGetId'];
    function popCrt($uibModalInstance, $scope, blockUI, toastr, $route, $http, $location, serviceGetId) {
        var Id = serviceGetId.getData();
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
        $http.get(hostapi + 'api/Questions/' + Id).then(function (response) {
            $scope.Question = response.data;

            $('#CauHoi').val($scope.Question.Content);
            $scope.CauHoi.Diem = $scope.Question.Mark;
            $scope.CauHoi.DoKho = $scope.Question.Discrimination;
            $scope.CauHoi.DoPhanCach = $scope.Question.ObjectiveDifficulty;
            $http.get(hostapi + 'api/AnswersQuestion/' + Id).then(function (response) {
                var lsAnswer = response.data;
                AnswerA = lsAnswer[0];
                $('#CauA').val(AnswerA.Content);
                if (AnswerA.Correct == true) {
                    $('#CauAda').prop('checked', true);
                }
                if (AnswerA.Interchange == true) {
                    $('#CauAhv').prop('checked', true);
                }
                AnswerB = lsAnswer[1];
                $('#CauB').val(AnswerB.Content);
                if (AnswerB.Correct == true) {
                    $('#CauBda').prop('checked', true);
                }
                if (AnswerB.Interchange == true) {
                    $('#CauBhv').prop('checked', true);
                }
                AnswerC = lsAnswer[2];
                $('#CauC').val(AnswerC.Content);
                if (AnswerC.Correct == true) {
                    $('#CauCda').prop('checked', true);
                }
                if (AnswerC.Interchange == true) {
                    $('#CauChv').prop('checked', true);
                }
                AnswerD = lsAnswer[3];
                $('#CauD').val(AnswerD.Content);
                if (AnswerD.Correct == true) {
                    $('#CauDda').prop('checked', true);
                }
                if (AnswerD.Interchange == true) {
                    $('#CauDhv').prop('checked', true);
                }
            });


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
                'IdQuestion': $scope.Question.Id,
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

            $http.post("api/Question/edit", data).then(function (response) {
                blockUI.stop();
                var ketqua = response.data;
                if (ketqua == 1) {
                    toastr.success('', 'Thêm câu hỏi mới thành công');
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