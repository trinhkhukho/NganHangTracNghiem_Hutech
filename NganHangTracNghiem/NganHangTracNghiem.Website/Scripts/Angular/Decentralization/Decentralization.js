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
    app.controller('Decentralization', DecentralizationCrt);
    DecentralizationCrt.$inject = ['$scope', '$http', '$location', 'serviceChapterId'];
    function DecentralizationCrt($scope, $http, $location, serviceChapterId) {
       
        $http.get(hostapi + 'api/GetDecentralizationList').then(function (response) {
            debugger;
            $scope.ListDecentralization = response.data.ListFuculties;
            $scope.Fuculties = $scope.ListDecentralization.fucalties;
        });
        
    };
})(angular.module('myApp'));
