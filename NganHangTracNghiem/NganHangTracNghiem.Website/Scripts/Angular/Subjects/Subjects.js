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
    SubjectsCrt.$inject = ['$scope', '$http', '$location', 'serviceShareData'];
    function SubjectsCrt($scope, $http, $location, serviceShareData) {
        $scope.pageSize = 10;
        $scope.Subjects = [];
        $scope.currentPage = 1;
        var id = JSON.parse(serviceShareData.getData("FacultiesIDList"))[0];
        $http.get(hostapi + 'api/Subjects_FacultiesId/' + id).then(function (response) {
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
    };
})(angular.module('myApp'));