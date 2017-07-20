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
        var data = [
          {
              "id": 1,
              "title": "node1",
              "nodes": [
                {
                    "id": 11,
                    "title": "node1.1",
                    "nodes": [
                      {
                          "id": 111,
                          "title": "node1.1.1",
                          "nodes": []
                      }
                    ]
                },
                {
                    "id": 12,
                    "title": "node1.2",
                    "nodes": []
                }
              ]
          },
          {
              "id": 2,
              "title": "node2",
              "nodrop": true,
              "nodes": [
                {
                    "id": 21,
                    "title": "node2.1",
                    "nodes": []
                },
                {
                    "id": 22,
                    "title": "node2.2",
                    "nodes": []
                }
              ]
          },
          {
              "id": 3,
              "title": "node3",
              "nodes": [
                {
                    "id": 31,
                    "title": "node3.1",
                    "nodes": []
                }
              ]
          }
        ];
        var a = data;
        $scope.ChaptersIns = {
            'Id': 0,
            'Name': null,
            'Content': null,
            'Order': null,
            'ParentId': null,
            'Deleted': false,
            'SubjectId': 0,
            'ManagementOrder': null
        };
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
        //$scope.DeleteChapter = function (chapter) {
        //    debugger;
        //    blockUI.start();
        //    var r = confirm("Bạn chắc chắn xóa phần " + chapter.Name);
        //    if (r == false) {
        //        blockUI.stop();
        //    }
        //    if (r == true) {
        //        $http.post("api/Chapters/delete", chapter)
        //            .then(function (response) {
        //                debugger;
        //                if (response.data == 1) {
        //                    alert("xóa thành công");
        //                    blockUI.stop();
        //                }
        //                else {
        //                    alert("không thể xóa");
        //                    blockUI.stop();
        //                }
        //                $route.reload(true);
        //            });
        //    }
        //};
        $scope.Block = function (user) {
            blockUI.start();
            if (user.Deleted == true) {
                var r = confirm("Mở khóa user " + user.UserName);
                user.Deleted = false;
            }
            else {
                var r = confirm("khóa user " + user.UserName);
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
    };
})(angular.module('myApp'));