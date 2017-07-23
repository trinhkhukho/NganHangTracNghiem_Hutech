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
    app.controller('GetBasicController', chapterCrt);
    chapterCrt.$inject = ['$scope', '$http', '$location', 'serviceChapterId', 'serviceShareData'];
    function chapterCrt($scope, $http, $location, serviceChapterId, serviceShareData) {
        //kiểm tra login
        $scope.decentralization;
        $scope.decentralizations = serviceShareData.getData('UserDecen');
        if ($scope.decentralizations.length <= 0) {
            $location.url('login');
        }
        else
        {
            $scope.decentralization = JSON.parse($scope.decentralizations)[0];
            var data_decen_faculties = [];
            var data_decen_subject = [];
            var data_decen_chapter = [];
            debugger;
            for(var i=0; i<$scope.decentralization.length; i++)
            {
                if($scope.decentralization[i].FacultiesId!=null)
                {
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
                if($scope.decentralization[i].SubjectId!=null)
                {
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
                if($scope.decentralization[i].ChapterId!=null)
                {
                    data_decen_chapter.push($scope.decentralization[i].ChapterId);
                }
            }
        }
        debugger;
        $scope.dataFaculties = {
            "Id": "",
            "Name": "",
            "Deleted": "",
            "Comment": ""
        };
        $scope.dataSubjects = {
            "Id": "",
            "Code": "",
            "Name": "",
            "Deleted": "",
            "FacultyId": "",
            "ManagementOrder": ""
        };
        $scope.dataChapters = {
            "Id": "",
            "Name": "",
            "Content": "",
            "Order": "",
            "ParentId": "",
            "Deleted": "",
            "SubjectId": "",
            "ManagementOrder": ""
        };
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
            debugger;
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
        $scope.submit = function () {
            debugger;
            serviceChapterId.clearall();
            serviceChapterId.addChapterId($scope.Selected.ChapterSelected);
            $location.url('TypeQuestions');
        }
    };
})(angular.module('myApp'));