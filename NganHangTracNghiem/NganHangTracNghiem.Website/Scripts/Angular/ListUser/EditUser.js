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
    app.controller('EditUser', EditUserCrt);
    EditUserCrt.$inject = ['$scope', '$http', '$location', 'serviceShareData', '$uibModalInstance', '$route'];
    function EditUserCrt($scope, $http, $location, serviceShareData, $uibModalInstance, $route) {
        var $ctrl = this;
        $scope.user = JSON.parse(serviceShareData.getData("UserEdit"));
        $scope.user = $scope.user[0];
        $ctrl.cancel = function () {

            $uibModalInstance.dismiss('cancel');
        };
        $ctrl.Submit = function () {

            $http.get(hostapi + 'api/Users/' + $scope.user.Id).then(function (response) {
                if (response.data != null) {
                    var data = response.data;
                    data.Name = $scope.user.Name;
                    data.Username = $scope.user.Username;
                    $http.put(hostapi + "api/Users/" + $scope.user.Id, data).then(function (response) {

                        $route.reload(true);
                        $uibModalInstance.dismiss('cancel');
                    });
                }
            });

        };
        $ctrl.defautPass = function () {

            var r = confirm("Bạn chắc chắn muốn đặt lại password của " + $scope.user.Name + " là 123456");
            if (r == false) {
            }
            if (r == true) {
                $http.get(hostapi + 'api/Users/' + $scope.user.Id).then(function (response) {
                    if (response.data != null) {
                        var data = response.data;
                        data.Password = "123456";
                        $http.put(hostapi + "api/Users/" + $scope.user.Id, data).then(function (response) {
                            $route.reload(true);
                            $uibModalInstance.dismiss('cancel');
                        });
                    }
                });
            }
        };
    };
})(angular.module('myApp'));