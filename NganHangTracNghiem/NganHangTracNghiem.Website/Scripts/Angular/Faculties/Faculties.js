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
    app.controller('Faculties', FacultiesCrt);
    FacultiesCrt.$inject = ['$scope', '$http', '$location', 'serviceShareData', '$uibModal', 'blockUI'];
    function FacultiesCrt($scope, $http, $location, serviceShareData, $uibModal, blockUI) {
        $scope.pageSize = 10;
        $scope.currentPage = 1;
        $scope.Faculties = [];
        $http.get(hostapi + 'api/Faculties').then(function (response) {
            $scope.Faculties = response.data;
        });
        $scope.Block = function (faculties) {
            blockUI.start();
            var r = confirm("Bạn có chắc muốn khóa khoa  " + faculties.Name);
            if (r == false) {
                blockUI.stop();
            }
            if (r == true) {
                faculties.Deleted = true;
                $http.Post(hostapi + "api/Faculties", faculties).then(function (response) {
                        blockUI.stop();
                        debugger;
                    });
            }
        };
        $scope.SelectFaculties = function (id) {
            serviceShareData.clearall("FacultiesIDList");
            serviceShareData.addData(id, "FacultiesIDList");
            $location.url('Subjects');
        };
        $scope.editFaculties = function (faculties) {
            
            serviceShareData.clearall();
            serviceShareData.addData(faculties,"Faculties");
            $uibModal.open({
                templateUrl: 'Scripts/Angular/Faculties/EditFaculties.html',
                size: 'lg',
                backdrop: 'static',
                controller: 'EditFaculties',
                controllerAs: '$ctrl'

            });
        };
    };
})(angular.module('myApp'));