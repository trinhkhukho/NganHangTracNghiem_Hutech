//get host of web API
var xml = new XMLHttpRequest();
xml.open('GET', 'Scripts/XML/ClinicInfo.xml', false)
xml.send();
var xmlData = xml.responseXML;
var host;
xmlData = (new DOMParser()).parseFromString(xml.responseText, 'text/xml');
var clinic = xmlData.getElementsByTagName("clinic");
hostapi = clinic[0].getElementsByTagName("host")[0].firstChild.data;
(function (app) {
    'use strict';
    app.controller('Chapters', ChaptersCrt);
    ChaptersCrt.$inject = ['$scope', '$http', '$location', 'serviceShareData', '$uibModal', 'blockUI', '$route'];
    function ChaptersCrt($scope, $http, $location, serviceShareData, $uibModal, blockUI, $route) {
        //kiểm tra đăng nhập
        $scope.decentralization;
        $scope.decentralizations = serviceShareData.getData('UserDecen');
        if ($scope.decentralizations.length <= 0) {
            $location.url('login');
        }
        else {
            $scope.Admin = false;
            $scope.DanhMuc = false;
            $scope.decentralization = JSON.parse($scope.decentralizations)[0];
            var data_decen_faculties = [];
            var data_decen_subject = [];
            var data_decen_chapter = [];
            debugger;
            for (var i = 0; i < $scope.decentralization.length; i++) {
                if ($scope.decentralization[i].Id == 29) {
                    $scope.Admin = true;
                    $scope.DanhMuc = true;
                }
                if ($scope.decentralization[i].Id == 26) {
                    $scope.DanhMuc = true;
                }
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

        $scope.pageSize = 10;
       
        $scope.currentPage = 1;
        $scope.ChaptersIns = {
            'Id': 0,
            'Name': null,
            'Content': null,
            'Order': null,
            'ParentId': null,
            'Deleted': false,
            'SubjectId': 0,
            'ManagementOrder': null
        };
        var id = JSON.parse(serviceShareData.getData("SubjectIDList"))[0];
        if ($scope.Admin == true || $scope.DanhMuc == true)
        {
            $http.get(hostapi + 'api/Chapters_SubjectID/' + id).then(function (response) {
                $scope.Chapters = response.data;
            });
        }
        else
        {
            $http.post(hostapi + 'api/Chapters_SubjectID', data_decen_chapter).then(function (response) {
                $scope.Chapters = response.data;
            });
        }
        
        $http.get(hostapi + 'api/Subjects/' + id).then(function (response) {
            $scope.Subjects = response.data;
            $scope.NameSubjects = $scope.Subjects[0].Name;
        });
        $scope.insert = function () {
            if ($scope.ChaptersIns.Name == null || $scope.ChaptersIns.Name == '') {
                alert("Tên phần không được để trống");
            }
            else {
                $scope.ChaptersIns.SubjectId = id;
                $http.post(hostapi + 'api/Chapters', $scope.ChaptersIns).then(function (response) {
                    alert("thêm phần thành công");
                    $route.reload(true);
                });
            }
        };
        $scope.DeleteChapter = function (chapter) {
            debugger;
            blockUI.start();
            var r = confirm("Bạn chắc chắn xóa phần " + chapter.Name);
            if (r == false) {
                blockUI.stop();
            }
            if (r == true) {
                $http.post("api/Chapters/delete", chapter)
                    .then(function (response) {
                        debugger;
                        if (response.data == 1) {
                            alert("xóa thành công");
                            blockUI.stop();
                        }
                        else {
                            alert("không thể xóa");
                            blockUI.stop();
                        }
                        $route.reload(true);
                    });
            }
        };
        $scope.Block = function (chapters) {
            blockUI.start();
            if (chapters.Deleted == true) {
                var r = confirm("Mở khóa phần " + chapters.Name);
            }
            else {
                var r = confirm("khóa phần " + chapters.Name);
            }

            if (r == false) {
                blockUI.stop();
            }
            if (r == true) {
                var data = {
                    'Id': 0,
                    'Name': null,
                    'Content': null,
                    'Order': null,
                    'ParentId': null,
                    'Deleted': false,
                    'SubjectId': 0,
                    'ManagementOrder': null
                };
                if (chapters.Deleted == true) {
                    data.Deleted = false;
                }
                else {
                    data.Deleted = true;
                }
                data.Name = chapters.Name;
                data.Id = chapters.Id;
                data.Content = chapters.Content;
                data.Order = chapters.Order;
                data.ParentId = chapters.ParentId;
                data.SubjectId = chapters.SubjectId;
                data.ManagementOrder = chapters.ManagementOrder;
                $http.put(hostapi + "api/Chapters/" + chapters.Id, data).then(function (response) {
                    blockUI.stop();
                    debugger;
                    $route.reload(true);
                });
            }
        };
        //$scope.editSubjects = function (subject) {
        //    debugger;
        //    serviceShareData.clearall();
        //    serviceShareData.addData(subject, "Subjects");
        //    $uibModal.open({
        //        templateUrl: 'Scripts/Angular/Subjects/EditSubjects.html',
        //        size: 'lg',
        //        backdrop: 'static',
        //        controller: 'EditSubject',
        //        controllerAs: '$ctrl'
        //    });
        //};
    };
})(angular.module('myApp'));