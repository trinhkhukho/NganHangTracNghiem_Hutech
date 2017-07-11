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
    app.controller('EditSubject', EditSubjectCrt);
    EditSubjectCrt.$inject = ['$scope', '$http', '$location', 'serviceShareData', '$uibModalInstance', '$route'];
    function EditSubjectCrt($scope, $http, $location, serviceShareData, $uibModalInstance, $route) {
        var $ctrl = this;
        debugger
        $scope.Subjects = JSON.parse(serviceShareData.getData("Subjects"));
        $scope.Subject = $scope.Subjects[0];
        $ctrl.cancel = function () {

            $uibModalInstance.dismiss('cancel');
        };
        $ctrl.Submit = function () {
            if ($scope.Subject.Name == "" || $scope.Subject.Name == null) {
                alert("Tên khoa không được để trống");
            }
            else {
                var data = {
                    'Id': null,
                    'Name': null,
                    'Deleted': null,
                    'Code': null,
                    'FacultyId': null,
                    'ManagementOrder': null
                };
                data.Name = $scope.Subject.Name;
                data.Id = $scope.Subject.Id;
                data.Code = $scope.Subject.Code;
                data.FacultyId = $scope.Subject.FacultyId;
                data.ManagementOrder = $scope.Subject.ManagementOrder;
                data.Deleted = $scope.Subject.Deleted;
                $http.put(hostapi + "api/Subjects/" + $scope.Subject.Id, data).then(function (response) {

                    debugger;
                    $route.reload(true);
                    $uibModalInstance.dismiss('cancel');
                });
            }
        };

    };
})(angular.module('myApp'));