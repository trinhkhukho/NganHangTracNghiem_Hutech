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
    app.controller('Dashboard_Faculties', questionCrt);
    questionCrt.$inject = ['$scope', '$http', '$route', '$timeout', 'blockUI', 'toastr', 'serviceChapterId'];
    function questionCrt($scope, $http, $route, $timeout, blockUI, toastr, serviceChapterId) {
        //thống kê số lượng câu hỏi theo khoa, môn, chương phần.
        debugger;
        var datapoint = {
            y: 0,
            legendText: null,
            label: null
        };
        var array_point = new Array();
        $http.get(hostapi + 'api/pro_Subject_FacultyId_Question').then(function (response) {
            $scope.FacultiesQuestions = response.data;
            //for (var i = 0; i < $scope.FacultiesQuestions.length; i++)
            //{
            //    datapoint.y = $scope.FacultiesQuestions[i].NumberOfQuestion;
            //    datapoint.legendText = $scope.FacultiesQuestions[i].Name;
            //    datapoint.label = $scope.FacultiesQuestions[i].Name;
            //    array_point.push(datapoint);
            //}
           
            //$route.reload(true);
        });
         window.onload = function () {
                var chart = new CanvasJS.Chart("chartContainer",
                {
                    title: {
                        text: "Desktop Search Engine Market Share, Dec-2012"
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
                        //dataPoints: array_point
                        dataPoints: [
                            { y: 83.24, legendText: "Google", label: "Google" },
                            { y: 8.16, legendText: "Yahoo!", label: "Yahoo!" },
                            { y: 4.67, legendText: "Bing", label: "Bing" },
                            { y: 1.67, legendText: "Baidu", label: "Baidu" },
                            { y: 0.98, legendText: "Others", label: "Others" }
                        ]
                    }
                    ]
                });
                chart.render();
            }
    };
   
})(angular.module('myApp'));