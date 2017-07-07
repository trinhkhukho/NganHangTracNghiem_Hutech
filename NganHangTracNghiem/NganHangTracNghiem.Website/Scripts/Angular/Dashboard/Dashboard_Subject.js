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
    app.controller('Dashboard_Subject', Dashboard_FacultiesCrt);
    Dashboard_FacultiesCrt.$inject = ['$scope', '$http', '$route', '$timeout', 'blockUI', 'toastr', 'serviceChapterId', 'serviceShareData', '$location'];
    function Dashboard_FacultiesCrt($scope, $http, $route, $timeout, blockUI, toastr, serviceChapterId, serviceShareData, $location) {
        debugger;

        var id = JSON.parse(serviceShareData.getData("SubjectID"))[0];
        $http.get(hostapi + 'api/pro_Get_Subject_Question/' + id).then(function (response) {
            debugger;
            $scope.FacultiesQuestions = response.data;
            var parsedAppData = [];
            var total = 0;
            for (var i = 0; i < $scope.FacultiesQuestions.length; i++) {
                total = total + $scope.FacultiesQuestions[i].NumberOfQuestion;
            }
            for (var i = 0; i < $scope.FacultiesQuestions.length; i++) {
                parsedAppData.push({
                    y: ($scope.FacultiesQuestions[i].NumberOfQuestion / total) * 100,
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

    };

})(angular.module('myApp'));