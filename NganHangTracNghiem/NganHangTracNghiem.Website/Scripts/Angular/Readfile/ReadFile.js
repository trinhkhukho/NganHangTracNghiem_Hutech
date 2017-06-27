
(function (app) {
    'use strict';
        //app.filter('startFrom', function () {
        //    return function (data, start) {
        //        return data.slice(start);
        //    }
        //});
    app.controller('fupController', fupCrt);
    fupCrt.$inject = ['$scope', '$sce', '$http', '$location', 'blockUI', 'toastr', 'serviceShareData'];
    function fupCrt($scope, $sce, $http, $location, blockUI, toastr, serviceShareData) {
    
        var LsQuestions_Success;
        var LsQuestions_Error;
            $scope.trustAsHtml = $sce.trustAsHtml;
            // GET THE FILE INFORMATION.
            $scope.getFileDetails = function (e) {
                $scope.files = [];
                $scope.$apply(function () {

                    // STORE THE FILE OBJECT IN AN ARRAY.
                    for (var i = 0; i < e.files.length; i++) {
                        $scope.files.push(e.files[i])
                    }

                });
            };

            // NOW UPLOAD THE FILES.
            $scope.uploadFiles = function () {
                //FILL FormData WITH FILE DETAILS.
                blockUI.start();
                var data = new FormData();

                for (var i in $scope.files) {
                    data.append("uploadedFile", $scope.files[i]);
                }

                // ADD LISTENERS.
                var objXhr = new XMLHttpRequest();
                objXhr.addEventListener("load", transferComplete, false);

                // SEND FILE DETAILS TO THE API.
                objXhr.open("POST", "/api/FileUpload/");
                objXhr.send(data);
            
            }
            // CONFIRMATION.
            function transferComplete() {
                alert("Up câu hỏi thành công");
                debugger
             
                serviceShareData.clearall('datareadfile');
                $scope.ListQuestions = JSON.parse(this.response);
                LsQuestions_Success = $scope.ListQuestions.Question_Success;
                LsQuestions_Error = $scope.ListQuestions.Question_Error;
                var SelectedValue = $scope.ListQuestions;
                serviceShareData.addData(SelectedValue,'datareadfile');
                blockUI.stop();
                $location.url('Result');
                $scope.$apply();
                //var hosts = window.location.origin;
                //var hostname = hosts + "/Scripts/Angular/Readfile/Result.html?val=";
                //window.location = hostname + SelectedValue;

            }
        }
 
})(angular.module('myApp'));



