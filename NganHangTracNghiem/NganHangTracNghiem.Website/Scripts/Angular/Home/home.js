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
    app.controller('CheckDecentralization', CheckDecentralizationCrt);
    CheckDecentralizationCrt.$inject = ['$scope', '$http', '$location', 'serviceShareData'];
    function CheckDecentralizationCrt($scope, $http, $location, serviceShareData) {
        debugger;
        $scope.decentralization = serviceShareData.getData('UserDecen');
       
        debugger;
        if ($scope.decentralization.length <= 0)
        {
            $location.url('login');
        }
        else
        {
            $scope.username =JSON.parse(serviceShareData.getData('UserLogin'))[0];
            $scope.decentralizations = JSON.parse($scope.decentralization)[0];
            $scope.Admin = false;
            $scope.DanhMuc = false;
            $scope.PhanQuyen = false;
            $scope.ThongKe = false;
            debugger;
            for(var i=0; i<$scope.decentralizations.length; i++)
            {
                if ($scope.decentralizations[i].Id == 29)
                {
                    $scope.Admin = true;
                    $scope.DanhMuc = true;
                    $scope.PhanQuyen = true;
                    $scope.ThongKe = true;
                }
                if ($scope.decentralizations[i].Id == 26)
                {
                    $scope.DanhMuc = true;
                }
                if ($scope.decentralizations[i].Id == 27) {
                    $scope.ThongKe = true;
                }
                if ($scope.decentralizations[i].Id == 28) {
                    $scope.PhanQuyen = true;
                }
            }
        }
        $scope.Logout = function () {
            debugger;
            serviceShareData.clearall('UserDecen');
            $location.url('login');
        };
    };
})(angular.module('myApp'));