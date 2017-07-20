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
    app.controller('Subjects', SubjectsCrt);
    SubjectsCrt.$inject = ['$scope', '$http', '$location', 'serviceShareData', '$uibModal', 'blockUI', '$route'];
    function SubjectsCrt($scope, $http, $location, serviceShareData, $uibModal, blockUI, $route) {
        $scope.pageSize = 10;
        $scope.Subjects = [];
        $scope.currentPage = 1;
        $scope.SubjectsIns = {
            'Id': 0,
            'Code': null,
            'Name': null,
            'Deleted': false,
            'FacultyId': 0,
            'ManagementOrder': null
        };
        var id = JSON.parse(serviceShareData.getData("FacultiesIDList"))[0];
        $http.get(hostapi + 'api/Subjects_FacultiesID/' + id).then(function (response) {
            $scope.Subjects = response.data;
        });
        $http.get(hostapi + 'api/Faculties').then(function (response) {
            $scope.Faculties = response.data;
            for (var i = 0; i < $scope.Faculties.length; i++)
            {
                var FacultiesId=$scope.Faculties[i].Id;
                if (FacultiesId == id)
                {
                    
                    $scope.NameFaculties = $scope.Faculties[i].Name;
                }
            }
            
        });
        $scope.SelectSubjects = function (id) {
            serviceShareData.clearall("SubjectIDList");
            serviceShareData.addData(id, "SubjectIDList");
            $location.url('Subjects');
        };
        $scope.insert = function () {
            if($scope.SubjectsIns.Name==null|| $scope.SubjectsIns.Name=='')
            {
                alert("Tên môn không được để trống");
            }
            else
            {
                $scope.SubjectsIns.FacultyId = id;
                $http.post(hostapi + 'api/Subjects', $scope.SubjectsIns).then(function (response) {
                    alert("thêm môn học thành công");
                    $route.reload(true);
                });
            }
        };
        $scope.DeleteSubject = function (subject) {
            debugger;
            blockUI.start();
            var r = confirm("Bạn chắc chắn xóa môn " + subject.Name);
            if (r == false) {
                blockUI.stop();
            }
            if (r == true) {
                $http.post("api/Subject/delete", subject)
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
        $scope.Block = function (subject) {
            blockUI.start();
            if (subject.Deleted == true) {
                var r = confirm("Mở khóa môn " + subject.Name);
            }
            else {
                var r = confirm("khóa môn " + subject.Name);
            }

            if (r == false) {
                blockUI.stop();
            }
            if (r == true) {
                var data = {
                    'Id': null,
                    'Name': null,
                    'Deleted': null,
                    'Code': null,
                    'FacultyId': null,
                    'ManagementOrder': null
                };
                if (subject.Deleted == true) {
                    data.Deleted = false;
                }
                else {
                    data.Deleted = true;
                }
                data.Name = subject.Name;
                data.Id = subject.Id;
                data.Code = subject.Code;
                data.FacultyId = subject.FacultyId;
                data.ManagementOrder = subject.ManagementOrder;
                $http.put(hostapi + "api/Subjects/" + subject.Id, data).then(function (response) {
                    blockUI.stop();
                    debugger;
                    $route.reload(true);
                });
            }
        };
        $scope.SelectSubjects = function (id) {
            serviceShareData.clearall("SubjectIDList");
            serviceShareData.addData(id, "SubjectIDList");
            $location.url('Chapters');
        };
        $scope.editSubjects = function (subject) {
            debugger;
            serviceShareData.clearall();
            serviceShareData.addData(subject, "Subjects");
            $uibModal.open({
                templateUrl: 'Scripts/Angular/Subjects/EditSubjects.html',
                size: 'lg',
                backdrop: 'static',
                controller: 'EditSubject',
                controllerAs: '$ctrl'
            });
        };
    };
})(angular.module('myApp'));