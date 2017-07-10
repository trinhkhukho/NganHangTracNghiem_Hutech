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
    EditFacultiesCrt.$inject = ['$scope', '$http', '$location', 'serviceShareData', '$uibModalInstance','$route'];
    function EditFacultiesCrt($scope, $http, $location, serviceShareData, $uibModalInstance, $route) {
        var $ctrl = this;
        debugger
        $scope.Faculties = JSON.parse(serviceShareData.getData("Faculties"));
        $scope.Facultie = $scope.Faculties[0];
        $ctrl.cancel = function () {
            
            $uibModalInstance.dismiss('cancel');
        };
        $ctrl.Submit = function () {
            if($scope.Facultie.Name==""||$scope.Facultie.Name==null)
            {
                alert("Tên khoa không được để trống");
            }
            else
            {
                var data = {
                    'Id': null,
                    'Name': null,
                    'Deleted': null,
                    'Comment': null
                };
                data.Id = $scope.Facultie.Id;
                data.Name = $scope.Facultie.Name;
                data.Comment = $scope.Facultie.Comment;
                data.Deleted = $scope.Facultie.Deleted;
                $http.put(hostapi + "api/Faculties/" + $scope.Facultie.Id, data).then(function (response) {
                    
                    debugger;
                    $route.reload(true);
                    $uibModalInstance.dismiss('cancel');
                });
            }
        };

    };
})(angular.module('myApp'));