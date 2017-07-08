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
    FacultiesCrt.$inject = ['$scope', '$http', '$location', 'serviceShareData', '$uibModal', 'blockUI', '$route'];
    function FacultiesCrt($scope, $http, $location, serviceShareData, $uibModal, blockUI, $route) {
        $scope.pageSize = 10;
        $scope.currentPage = 1;
        $scope.Faculties = [];
        $http.get(hostapi + 'api/Faculties').then(function (response) {
            $scope.Faculties = response.data;
        });
        $scope.Block = function (faculties) {
            blockUI.start();
            if (faculties.Deleted == true)
                {
                    var r = confirm("Mở khóa khoa " + faculties.Name);
                }
                else
                {
                    var r = confirm("khóa khoa " + faculties.Name);
                }
            
            if (r == false) {
                blockUI.stop();
            }
            if (r == true) {
                var data = {
                    'Id': null,
                    'Name': null,
                    'Deleted': null,
                    'Comment':null
                };
                if (faculties.Deleted == true)
                {
                    data.Deleted = false;
                }
                else
                {
                    data.Deleted = true;
                }
                data.Id = faculties.Id;
                data.Name = faculties.Name;
                data.Comment = faculties.Comment;
                $http.put(hostapi + "api/Faculties/" + faculties.Id, data).then(function (response) {
                        blockUI.stop();
                        debugger;
                        $route.reload(true);
                    });
            }
        };
        $scope.SelectFaculties = function (id) {
            serviceShareData.clearall("FacultiesIDList");
            serviceShareData.addData(id, "FacultiesIDList");
            $location.url('Subjects');
        };
        $scope.editFaculties = function (faculties) {
            debugger;
            serviceShareData.clearall();
            serviceShareData.addData(faculties, "Faculties");
            $uibModal.open({
                templateUrl: 'Scripts/Angular/Faculties/EditFaculties.html',
                size: 'lg',
                backdrop: 'static',
                controller: 'EditFaculties',
                controllerAs: '$ctrl'

            });
        };
        $scope.DeleteFaculties = function (faculties) {
            debugger;
            blockUI.start();
            var r = confirm("Bạn chắc chắn xóa khoa " + faculties.Name);
            if (r == false) {
                blockUI.stop();
            }
            if (r == true) {
                $http.delete(hostapi + "api/Faculties/" + faculties.Id).then(function (response) {
                    blockUI.stop();
                    debugger;
                    $route.reload(true);
                });
            }
        };
    };
})(angular.module('myApp'));