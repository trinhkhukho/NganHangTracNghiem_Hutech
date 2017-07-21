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
    app.controller('Decentralization', DecentralizationCrt);
    DecentralizationCrt.$inject = ['$scope', '$http', '$location', 'serviceShareData'];
    function DecentralizationCrt($scope, $http, $location, serviceShareData, dialog) {
        debugger;
        var userId_registers = serviceShareData.getData("UserId_Register");
        var userId_exists = serviceShareData.getData("UserId_Exist");
        if (userId_exists != null && userId_exists.length > 0) {
            var userId_exist = JSON.parse(userId_exists)[0];
            $scope.ListDecentralization = [];
            $scope.ListDecentralizationUser;
            $scope.Subject = [];
            $scope.Chapter = [];
            $http.get(hostapi + 'api/GetDecentralizationList').then(function (response) {
                debugger;
                $scope.ListDecentralization = response.data;
                $http.get(hostapi + 'api/GetUserRole_UserId/' + userId_exist).then(function (response) {
                    debugger;
                    $scope.ListDecentralizationUser = response.data;
                    if ($scope.ListDecentralizationUser != null && $scope.ListDecentralizationUser.length > 0) {
                        for (var i = 0; i < $scope.ListDecentralizationUser.length; i++) {
                            for (var j = 0; j < $scope.ListDecentralization.length; j++) {
                                for (var s = 0; s < $scope.ListDecentralization[j].child.length; s++) {
                                    for (var c = 0; c < $scope.ListDecentralization[j].child[s].child.length; c++) {
                                        if ($scope.ListDecentralization[j].child[s].child[c].Id == $scope.ListDecentralizationUser[i].ChapterId) {
                                            $scope.ListDecentralization[j].child[s].child[c].check = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                });
            });

            var data = {
                UserID: userId_exist,
                ChapterID: 0,
                RoleID: 0
            };
            $scope.save = function () {
                debugger;
                var array = [];
                for (var i = 0; i < $scope.Chapter.length; i++) {
                    data = {
                        UserID: userId_exist,
                        ChapterID: 0,
                        RoleID: 0
                    };
                    if ($scope.Chapter[i].check == true) {
                        debugger;
                        data.ChapterID = $scope.Chapter[i].Id;
                        array.push(data);

                    }
                }
                $http.post(hostapi + 'api/UserRoles', array).then(function (response) {
                    alert("Phân quyền thanh công");
                    $location.url('ListUser');
                });
            };
            $scope.FucCheck = function (fuculties) {
                debugger;
                for (var i = 0; i < $scope.ListDecentralization.length; i++) {

                    if ($scope.ListDecentralization[i].Id == fuculties.Id) {
                        var status = $scope.ListDecentralization[i].check;
                        for (var j = 0; j < $scope.ListDecentralization[i].child.length; j++) {
                            $scope.ListDecentralization[i].child[j].check = status;
                            for (var c = 0; c < $scope.ListDecentralization[i].child[j].child.length; c++) {
                                if (status == false) {
                                    for (var d = 0; d < $scope.Chapter.length; d++) {
                                        if ($scope.Chapter[d].Id == $scope.ListDecentralization[i].child[j].child[c].Id) {
                                            $scope.Chapter.splice(d, 1);
                                        }
                                    }
                                }
                                else {
                                    $scope.Chapter.push($scope.ListDecentralization[i].child[j].child[c]);
                                }
                            }
                            if (status == false) {
                                for (var d = 0; d < $scope.Subject.length; d++) {
                                    if ($scope.Subject[d].Id == $scope.ListDecentralization[i].child[j].Id) {
                                        $scope.Subject.splice(d, 1);
                                    }
                                }
                            }
                            else {
                                $scope.Subject.push($scope.ListDecentralization[i].child[j]);

                            }
                        }
                    }
                }
            }
        }
        else {
            if (userId_registers != null && userId_registers.length > 0) {
                var userId_register = JSON.parse(userId_registers)[0];
                $scope.ListDecentralization = [];
                $scope.Subject = [];
                $scope.Chapter = [];
                $http.get(hostapi + 'api/GetDecentralizationList').then(function (response) {
                    debugger;
                    $scope.ListDecentralization = response.data;
                });
                var data = {
                    UserID: userId_register,
                    ChapterID: 0,
                    RoleID: 0
                };
                $scope.save = function () {
                    debugger;
                    var array = [];
                    for (var i = 0; i < $scope.Chapter.length; i++) {
                        data = {
                            UserID: userId_register,
                            ChapterID: 0,
                            RoleID: 0
                        };
                        if ($scope.Chapter[i].check == true) {
                            debugger;
                            data.ChapterID = $scope.Chapter[i].Id;
                            array.push(data);

                        }
                    }
                    $http.post(hostapi + 'api/UserRoles', array).then(function (response) {
                        alert("Phân quyền thanh công");
                        $location.url('ListUser');
                    });
                };
                $scope.FucCheck = function (fuculties) {
                    debugger;
                    for (var i = 0; i < $scope.ListDecentralization.length; i++) {

                        if ($scope.ListDecentralization[i].Id == fuculties.Id) {
                            var status = $scope.ListDecentralization[i].check;
                            for (var j = 0; j < $scope.ListDecentralization[i].child.length; j++) {
                                $scope.ListDecentralization[i].child[j].check = status;
                                for (var c = 0; c < $scope.ListDecentralization[i].child[j].child.length; c++) {
                                    if (status == false) {
                                        for (var d = 0; d < $scope.Chapter.length; d++) {
                                            if ($scope.Chapter[d].Id == $scope.ListDecentralization[i].child[j].child[c].Id) {
                                                $scope.Chapter.splice(d, 1);
                                            }
                                        }
                                    }
                                    else {
                                        $scope.Chapter.push($scope.ListDecentralization[i].child[j].child[c]);
                                    }
                                }
                                if (status == false) {
                                    for (var d = 0; d < $scope.Subject.length; d++) {
                                        if ($scope.Subject[d].Id == $scope.ListDecentralization[i].child[j].Id) {
                                            $scope.Subject.splice(d, 1);
                                        }
                                    }
                                }
                                else {
                                    $scope.Subject.push($scope.ListDecentralization[i].child[j]);

                                }
                            }
                        }
                    }
                }
            }
            else {

            }
        }
    };
})(angular.module('myApp'));
