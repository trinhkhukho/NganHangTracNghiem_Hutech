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
    app.controller('User', UserCrt);
    UserCrt.$inject = ['$scope', '$http', '$location', 'serviceShareData', '$uibModal', 'blockUI', '$route'];
    function UserCrt($scope, $http, $location, serviceShareData, $uibModal, blockUI, $route) {
        $scope.pageSize = 10;
        $scope.currentPage = 1;
        debugger;
        $http.get(hostapi + 'api/Users').then(function (response) {
            $scope.Users = response.data;
        });
        //$scope.SelectSubjects = function (id) {
        //    serviceShareData.clearall("SubjectIDList");
        //    serviceShareData.addData(id, "SubjectIDList");
        //    $location.url('Subjects');
        //};
        //$scope.insert = function () {
        //    if ($scope.ChaptersIns.Name == null || $scope.ChaptersIns.Name == '') {
        //        alert("Tên phần không được để trống");
        //    }
        //    else {
        //        $scope.ChaptersIns.SubjectId = id;
        //        $http.post(hostapi + 'api/Chapters', $scope.ChaptersIns).then(function (response) {
        //            alert("thêm phần thành công");
        //            $route.reload(true);
        //        });
        //    }
        //};
        $scope.DeleteUser = function (user) {
            debugger;
            
            var r = confirm("Bạn chắc chắn xóa user " + user.Name);
            if (r == false) {
                
            }
            if (r == true) {
                $http.post("api/User/delete", user)
                    .then(function (response) {
                        debugger;
                        if (response.data == 1) {
                            alert("xóa thành công");
                        }
                        else {
                            alert("không thể xóa");
                        }
                        $http.get(hostapi + 'api/Users').then(function (response) {
                            $scope.Users = response.data;
                        });
                    });
            }
        };
        $scope.Block = function (user) {
            blockUI.start();
            if (user.Deleted == true) {
                var r = confirm("Mở khóa user " + user.Username);
                user.Deleted = false;
            }
            else {
                var r = confirm("khóa user " + user.Username);
                user.Deleted = true;
            }

            if (r == false) {
                blockUI.stop();
            }
            if (r == true) {
                
                $http.put(hostapi + "api/User/" + user.Id, user).then(function (response) {
                    blockUI.stop();
                    debugger;
                    $route.reload(true);
                });
            }
        };
        $scope.PhanQuyen = function (user) {
            debugger;
            serviceShareData.clearall("UserId_Exist");
            serviceShareData.addData(user.Id, "UserId_Exist");
            $location.url('Decentralization');
        };
    };
})(angular.module('myApp'));