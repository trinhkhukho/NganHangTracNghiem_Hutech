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
            $http.post(hostapi + 'api/Login', $scope.user).then(function (response) {
                debugger;
                if (response.data != 0 && response.data != -1) {
                    $http.get(hostapi + 'api/Users/' + response.data).then(function (response) {
                        debugger;
                        var a = JSON.parse(response.data);
                        serviceShareData.clearall('UserLogin');
                        serviceShareData.addData(a.Name, 'UserLogin');
                    });
                    $http.get('api/Decentralization/' + response.data).then(function (response) {
                        debugger;
                        if (response.data == 0) {
                            alert("Tài khoản không có quyền truy cập !");
                        }
                        else {
                            if (response.data == -1) {
                                alert("Lỗi !");
                            }
                            else {
                                var a = JSON.parse(response.data);
                                serviceShareData.clearall('UserDecen');
                                serviceShareData.addData(a, 'UserDecen');
                                $location.url('home');
                            }
                        }
                    });

                }
                else {
                    if (response.data == 0) {
                        alert("Tên đăng nhập hoặc mật khẩu sai !");
                    }
                    else {
                        if (response.data == -1) {
                            alert("Lỗi !");
                        }
                    }
                }
            });


        };
    };
})(angular.module('myApp'));