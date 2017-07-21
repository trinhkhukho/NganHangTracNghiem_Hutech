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
    function DecentralizationCrt($scope, $http, $location, serviceChapterId,dialog) {
        $scope.ListDecentralization = [];
        $scope.Subject=[];
        $scope.Chapter=[];
        $http.get(hostapi + 'api/GetDecentralizationList').then(function (response) {
            debugger;
            $scope.ListDecentralization = response.data;
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
        $scope.FucClick = function (fuculties) {
            debugger;
            if (fuculties.child[0].Id != 0)
            {
                $scope.Subject = fuculties.child;
                $scope.Chapter = [];
            }
            else
            {
                $scope.Subject = []
                $scope.Chapter = [];

            }
        }
        $scope.SubClick = function (subject) {
            debugger;
            if (subject.child[0].Id != 0) {
                $scope.Chapter = subject.child;

            }
            else {
                $scope.chapter = []

            }
        }
        $scope.FucCheck = function (fuculties)
        {
            debugger;
            for(var i=0; i< $scope.ListDecentralization.length; i++)
            {
                
                if($scope.ListDecentralization[i].Id==fuculties.Id)
                {
                    var status = $scope.ListDecentralization[i].check;
                    for(var j =0; j<$scope.ListDecentralization[i].child.length; j++)
                    {
                        $scope.ListDecentralization[i].child[j].check = status;
                        for (var c = 0; c < $scope.ListDecentralization[i].child[j].child.length; c++)
                        {
                            $scope.ListDecentralization[i].child[j].child[c].check = status;
                            if (status == false)
                            {
                                for (var d = 0; d < $scope.Chapter.length; d++)
                                {
                                    if ($scope.Chapter[d].Id == $scope.ListDecentralization[i].child[j].child[c].Id)
                                    {
                                        $scope.Chapter.splice(d, 1);
                                    }
                                    
                                }
                                
                            }
                            else
                            {
                                $scope.Chapter.push($scope.ListDecentralization[i].child[j].child[c]);
                            }
                        }
                        if (status == false)
                        {
                            for (var d = 0; d < $scope.Subject.length; d++)
                            {
                                if ($scope.Subject[d].Id == $scope.ListDecentralization[i].child[j].Id)
                                {
                                    $scope.Subject.splice(d, 1);
                                }
                            }
                        }
                        else
                        {
                            $scope.Subject.push($scope.ListDecentralization[i].child[j]);

                        }
                    }
                }
            }
        }
    };
})(angular.module('myApp'));
