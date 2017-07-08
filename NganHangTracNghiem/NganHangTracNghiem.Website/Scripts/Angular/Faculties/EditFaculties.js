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
    app.controller('EditFaculties', EditFacultiesCrt);
    EditFacultiesCrt.$inject = ['$scope', '$http', '$location', 'serviceShareData', '$uibModalInstance'];
    function EditFacultiesCrt($scope, $http, $location, serviceShareData, $uibModalInstance) {
        var $ctrl = this;
        debugger
        $scope.Faculties = JSON.parse(serviceShareData.getData("Faculties"));
        $scope.Facultie = $scope.Faculties[0];
        $ctrl.cancel = function () {
            
            $uibModalInstance.dismiss('cancel');
        };
    };
})(angular.module('myApp'));