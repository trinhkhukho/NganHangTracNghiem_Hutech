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
    chapterCrt.$inject = ['$scope', '$http', '$location', 'serviceChapterId'];
    function chapterCrt($scope, $http,$location, serviceChapterId) {
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
        $http.get(hostapi + 'api/Faculties').then(function (response) {
            $scope.Faculties = response.data;

        });
        $http.get(hostapi + 'api/Subjects').then(function (response) {
            $scope.Subjects = response.data;
        });
        $http.get(hostapi + 'api/Chapters').then(function (response) {
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
        $scope.submit = function () {
            debugger;
            serviceChapterId.clearall();
            serviceChapterId.addChapterId($scope.Selected.ChapterSelected);
            $location.url('TypeQuestions');
        }
    };
})(angular.module('myApp'));