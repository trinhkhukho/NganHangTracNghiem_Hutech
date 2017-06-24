//get host of web API
var xml = new XMLHttpRequest();
xml.open('GET', 'ClinicInfo.xml', false)
xml.send();
var xmlData = xml.responseXML;
var host;
xmlData = (new DOMParser()).parseFromString(xml.responseText, 'text/xml');
var clinic = xmlData.getElementsByTagName("clinic");
host = clinic[0].getElementsByTagName("host")[0].firstChild.data;
var myApp = angular.module('NganHangTracNghiem', ['ngAnimate', 'ngSanitize', 'ui.bootstrap']);

//Show popup ReadFile
myApp.controller('UploadControler', function ($uibModal, $scope, $document) {


    $scope.animationsEnabled = true;
    $scope.open = function () {

        $uibModal.open({

            templateUrl: 'ReadFile.html',
            size: 'lg',
            backdrop: 'static',
            controller: 'buttonController',
            controllerAs: '$ctrl'

        });


    };


});
//Get infomation Khoa
myApp.controller('GetKhoa', function ($scope, $http) {
    $http.get(host+'api/Faculties').then(function (response) {

        $scope.Khoas = response.data;
    });
});
//Get infomation môn học
myApp.controller('GetMonHoc', function ($scope, $http) {
    $http.get(host+'api/Subjects').then(function (response) {
        $scope.MonHocs = response.data;
    });
});
//Get infomation phần
myApp.controller('GetPhan', function ($scope, $http) {
    $http.get(host + 'api/Chapters').then(function (response) {
        $scope.Phans = response.data;
    });
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
        objXhr.open("POST", "/api/FileUpload/");


        objXhr.send(data);
        debugger;
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
    $scope.trustAsHtml = $sce.trustAsHtml;
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


myApp.controller('buttonController',
    function ($uibModalInstance) {
        var $ctrl = this;
        $ctrl.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
    });
myApp.controller('QuestionAddController', function ($uibModal, $scope, $document) {


    $scope.animationsEnabled = true;
    $scope.open = function () {

        $uibModal.open({

            templateUrl: 'Question.html',
            size: 'lg',
            backdrop: 'static',
            controller: 'QuestionController',
            controllerAs: '$ctrl'
        });
    };
});
myApp.controller('QuestionController',
    function ($uibModalInstance,$scope) {
        var $ctrl = this;

        $ctrl.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
        $ctrl.Submit = function () {
            debugger
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
    });