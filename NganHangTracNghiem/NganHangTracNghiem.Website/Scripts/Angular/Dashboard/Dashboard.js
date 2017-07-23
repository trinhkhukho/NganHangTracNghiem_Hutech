//get host of web API
var xml = new XMLHttpRequest();
xml.open('GET', 'Scripts/XML/ClinicInfo.xml', false)
xml.send();
var xmlData = xml.responseXML;
var host;
xmlData = (new DOMParser()).parseFromString(xml.responseText, 'text/xml');
var clinic = xmlData.getElementsByTagName("clinic");
hostapi = clinic[0].getElementsByTagName("host")[0].firstChild.data;
var reload = 0;
(function (app) {
    'use strict';
    app.controller('Dashboard_Faculties', questionCrt);
    questionCrt.$inject = ['$scope', '$http', '$route', '$timeout', 'blockUI', 'toastr', 'serviceChapterId', 'serviceShareData', '$location'];
    function questionCrt($scope, $http, $route, $timeout, blockUI, toastr, serviceChapterId, serviceShareData, $location) {
        //kiem tra dang nhap
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
        //thống kê số lượng câu hỏi theo khoa, môn, chương phần.
        debugger;
        $scope.pageSize = 10;
        $scope.currentPage = 1;
        var datapoint = {
            y: 0,
            legendText: null,
            label: null
        };
        
        var array_point = new Array();
        $http.post(hostapi + 'api/GetDecentralizationFaculties', data_decen_faculties).then(function (response) {
            $scope.FacultiesQuestions = response.data;
            debugger;
            var parsedAppData = [];
            var total = 0;
            if ($scope.FacultiesQuestions != null) {
                reload = reload + 1;
            }
            for (var i = 0; i < $scope.FacultiesQuestions.length; i++) {
                
                total = total + $scope.FacultiesQuestions[i].NumberOfQuestion;
            }
            for(var i=0; i< $scope.FacultiesQuestions.length; i++)
            {
                parsedAppData.push({
                    y: ($scope.FacultiesQuestions[i].NumberOfQuestion/total)*100,
                    legendText: $scope.FacultiesQuestions[i].Name,
                    label: $scope.FacultiesQuestions[i].Name
                });
            }
            $scope.chart = new CanvasJS.Chart("chartContainer",
            {
                title: {
                    text: ""
                },
                animationEnabled: true,
                legend: {
                    verticalAlign: "center",
                    horizontalAlign: "left",
                    fontSize: 20,
                    fontFamily: "Helvetica"
                },
                theme: "theme2",
                data: [
                {
                    type: "pie",
                    indexLabelFontFamily: "Garamond",
                    indexLabelFontSize: 20,
                    indexLabel: "{label} {y}%",
                    startAngle: -20,
                    showInLegend: true,
                    toolTipContent: "{legendText} {y}%",
                    dataPoints: []
                }
                ]
            });
            $scope.chart.options.data[0].dataPoints = parsedAppData;
            $scope.chart.render();
           

        });
        
        $scope.SelectFaculties = function (id) {
            serviceShareData.clearall("FacultiesID");
            serviceShareData.addData(id, "FacultiesID");
            $location.url('Dashboard_Faculties');
        };
    };
})(angular.module('myApp'));