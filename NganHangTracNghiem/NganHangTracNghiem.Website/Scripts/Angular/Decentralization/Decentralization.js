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
    DecentralizationCrt.$inject = ['$scope', '$http', '$location', 'serviceChapterId'];
    function DecentralizationCrt($scope, $http, $location, serviceChapterId) {
        $scope.ListDecentralization = [];
        $http.get(hostapi + 'api/GetDecentralizationList').then(function (response) {
            debugger;
            $scope.ListDecentralization = response.data.ListFuculties;
        });
        var data = {
            UserID: 10001,
            ChapterID: 0,
            SubjectID: 0,
            FacultiesID: 0,
            RoleID:0
        };
        $scope.save = function () {
            debugger;
            for(var i=0; i<$scope.ListDecentralization.length;i++)
            {
                debugger;
                if($scope.ListDecentralization[i].fucalties.check==true)
                {
                    data.ChapterID = 0;
                    data.SubjectID = 0;
                    data.RoleID = 0;
                    data.FacultiesID = $scope.ListDecentralization[i].fucalties.ID;
                    $http.post(hostapi + 'api/UserRoles',data).then(function (response) {
                        debugger;
                        
                    });
                }
                else
                {
                    for (var j = 0 ; j < $scope.ListDecentralization[i].subject_chapter.length; j++)
                    {
                        if($scope.ListDecentralization[i].subject_chapter[j].subject.check==true)
                        {
                            data.ChapterID = 0;
                            data.SubjectID = $scope.ListDecentralization[i].subject_chapter[j].subject.ID;
                            data.RoleID = 0;
                            data.FacultiesID = $scope.ListDecentralization[i].fucalties.ID;
                            $http.post(hostapi + 'api/UserRoles', data).then(function (response) {
                                debugger;

                            });
                        }
                        else
                        {
                            for (var h = 0; h < $scope.ListDecentralization[i].subject_chapter[j].chapter.length; h++) {
                                if ($scope.ListDecentralization[i].subject_chapter[j].chapter[h].check == true) {
                                    data.ChapterID = $scope.ListDecentralization[i].subject_chapter[j].chapter[h].ID;
                                    data.SubjectID = $scope.ListDecentralization[i].subject_chapter[j].subject.ID;
                                    data.RoleID = 0;
                                    data.FacultiesID = $scope.ListDecentralization[i].fucalties.ID;
                                    $http.post(hostapi + 'api/UserRoles', data).then(function (response) {
                                        debugger;

                                    });
                                }
                            }
                        }
                    }
                }
            }
        };
    };
})(angular.module('myApp'));
