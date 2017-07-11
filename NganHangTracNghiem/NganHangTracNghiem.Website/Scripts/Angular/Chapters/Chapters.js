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
        $http.get(hostapi + 'api/Chapters_SubjectID/' + id).then(function (response) {
            $scope.Chapters = response.data;
        });
        $http.get(hostapi + 'api/Subjects/' + id).then(function (response) {
            $scope.Subjects = response.data;
            $scope.NameSubjects = $scope.Subjects[0].Name;
        });
        //$scope.SelectSubjects = function (id) {
        //    serviceShareData.clearall("SubjectIDList");
        //    serviceShareData.addData(id, "SubjectIDList");
        //    $location.url('Subjects');
        //};
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