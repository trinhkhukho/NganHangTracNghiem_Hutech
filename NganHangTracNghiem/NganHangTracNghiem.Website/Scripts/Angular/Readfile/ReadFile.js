
(function (app) {
    'use strict';
    app.controller('fupController', fupCrt);
    fupCrt.$inject = ['$scope', '$sce', '$http', '$location', 'blockUI', 'toastr', 'serviceShareData', 'serviceChapterId'];
    function fupCrt($scope, $sce, $http, $location, blockUI, toastr, serviceShareData, serviceChapterId) {
    
        debugger;
        //$scope.ChapterId = serviceChapterId.getChapterId();
        $scope.UserID = serviceShareData.getData("UserId");
        if ($scope.UserID != null)
        {
            $scope.UserID = JSON.parse($scope.UserID)[0];
        }
        $scope.ChapterId = JSON.parse(serviceShareData.getData("ChapterId"));
        $scope.ChapterId = $scope.ChapterId[0];
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
                    debugger;
                    data.append("uploadedFile", $scope.files[i]);
                    data.append("chapterid", $scope.ChapterId);
                    data.append("userid", $scope.UserID);
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
                debugger
                serviceShareData.clearall('datareadfile');
                if (this.response != 0)
                {
                    $scope.ListQuestions = JSON.parse(this.response);
                    LsQuestions_Success = $scope.ListQuestions.Question_Success;
                    LsQuestions_Error = $scope.ListQuestions.Question_Error;
                    var SelectedValue = $scope.ListQuestions;
                    serviceShareData.addData(SelectedValue, 'datareadfile');
                    blockUI.stop();
                    $location.url('Result');
                    $scope.$apply();
                }
                else
                {
                    blockUI.stop();
                    alert("Lỗi kiểm tra định dạng file của bạn,  file hợp lệ là zip hoặc file docx")
                }
                
            }
        }
 
})(angular.module('myApp'));



