
var LsQuestions_Success;
var LsQuestions_Error;
var myApp = angular.module('fupApp', ['ngAnimate', 'ngSanitize', 'ui.bootstrap']);
myApp.filter('startFrom', function () {
    return function(data,start)
    {
        return data.slice(start);
    }
});
myApp.controller('fupController', function ($scope, $sce, serviceShareData) {
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
    function transferComplete(e) {
        alert("Up câu hỏi thành công");
        serviceShareData.clearall();
        $scope.ListQuestions = JSON.parse(this.response);
        LsQuestions_Success = $scope.ListQuestions.Question_Success;
        LsQuestions_Error = $scope.ListQuestions.Question_Error;
        var SelectedValue = $scope.ListQuestions
        serviceShareData.addData(SelectedValue);
        var hosts = window.location.origin;
        var hostname = hosts + "/View/Result.html?val=";
        window.location = hostname + SelectedValue;
    }
});

////
myApp.controller('fupzipController', function ($scope) {

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
        debugger 
        //FILL FormData WITH FILE DETAILS.
        var data = new FormData();
        for (var i in $scope.files) {
            data.append("uploadedFile", $scope.files[i]);
        }

        // ADD LISTENERS.
        var objXhr = new XMLHttpRequest();
        objXhr.addEventListener("load", transferComplete, false);

        // SEND FILE DETAILS TO THE API.
        objXhr.open("POST", "/api/FileUploadZip/");
        objXhr.send(data);
    }
    // CONFIRMATION.
    function transferComplete(e) {
        alert("Files uploaded successfully.");
    }
});
myApp.controller('Result', function ($scope, $sce, serviceShareData) {
    $scope.from = {};
    $scope.pagesize = 5;
    $scope.currentpage = 1;
    $scope.trustAsHtml = $sce.trustAsHtml;
    $scope.ListQuestions = null;
    $scope.ListQuestions = serviceShareData.getData();
    var ListQuestions = JSON.parse($scope.ListQuestions);
    $scope.Question_Successs = ListQuestions[0].Question_Success;
    $scope.Question_Errors = ListQuestions[0].Question_Error;
    debugger;
});


// share data between pages
myApp.service('serviceShareData', function ($window) {
    var KEY = 'App.SelectedValue';

    var addData = function (newObj) {
        var mydata = $window.sessionStorage.getItem(KEY);
        if (mydata) {
            mydata = JSON.parse(mydata);
        } else {
            mydata = [];
        }
        mydata.push(newObj);
        $window.sessionStorage.setItem(KEY, JSON.stringify(mydata));
    };

    var getData = function () {
        var mydata = $window.sessionStorage.getItem(KEY);
        if (mydata) {
            mydata = mydata;
        }
        return mydata || [];
    };
    var clearall = function clearAll() {
        $window.sessionStorage.clear();
    }
    return {
        addData: addData,
        getData: getData,
        clearall: clearall
    };
});