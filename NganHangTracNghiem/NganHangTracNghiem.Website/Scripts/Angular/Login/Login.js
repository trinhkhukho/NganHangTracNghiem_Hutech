//get host of web API
var xml = new XMLHttpRequest();
xml.open('GET', '/Scripts/XML/ClinicInfo.xml', false)
xml.send();
var xmlData = xml.responseXML;
var host;
xmlData = (new DOMParser()).parseFromString(xml.responseText, 'text/xml');
var clinic = xmlData.getElementsByTagName("clinic");
hostapi = clinic[0].getElementsByTagName("host")[0].firstChild.data;



(function (app) {
    'use strict';
    app.controller('getlogin', fupCrt);
    fupCrt.$inject = ['$scope', 'serviceShareData', '$http', '$location'];
    function fupCrt($scope, serviceShareData, $http, $location) {
        debugger;
        $scope.user = {
            UserName: "",
            PassWord: ""
        };
        $scope.message = "";

        $scope.submit = function () {
            debugger;

            alert("Tên đăng nhập hoặc mật khẩu sai !");

        };
    };
})(angular.module('myApp'));