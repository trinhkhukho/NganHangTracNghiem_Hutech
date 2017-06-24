
//get host of web API
var xml = new XMLHttpRequest();
xml.open('GET', 'ClinicInfo.xml', false)
xml.send();
var xmlData = xml.responseXML;
var host;
xmlData = (new DOMParser()).parseFromString(xml.responseText, 'text/xml');
var clinic = xmlData.getElementsByTagName("clinic");
host = clinic[0].getElementsByTagName("host")[0].firstChild.data;
var myApp = angular.module('NganHangTracNghiem', ['ngAnimate', 'ngSanitize', 'ui.bootstrap', 'oc.lazyLoad']);

//Show popup ReadFile
myApp.controller('UploadControler', function ($uibModal, $scope, $document) {
    $scope.animationsEnabled = true;
    $scope.open = function () {
        $uibModal.open({
            templateUrl: 'ReadFile.html',
            size: 'lg',
            backdrop: 'static',
            controller: 'ReadfileController',
            controllerAs: '$ctrl'
        });
    };
});

//popup ReadFile
myApp.controller('ReadfileController',
    function ($uibModalInstance, $ocLazyLoad) {
        $ocLazyLoad.load('custom-file-input.js');
        var $ctrl = this;
        $ctrl.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
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
        debugger;
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
myApp.controller('fupzipController', function ($scope) {
    debugger 
    // GET THE FILE INFORMATION.
    //$scope.getFileDetails = function (e) {
    //    debugger 
    //    $scope.files = [];
    //    $scope.$apply(function () {

    //        // STORE THE FILE OBJECT IN AN ARRAY.
    //        for (var i = 0; i < e.files.length; i++) {
    //            $scope.files.push(e.files[i])
    //        }

    //    });
    //};

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
    $scope.trustAsHtml = $sce.trustAsHtml;
    $scope.ListQuestions = serviceShareData.getData();
    var ListQuestions = JSON.parse($scope.ListQuestions);
    $scope.Question_Successs = ListQuestions[0].Question_Success;
    $scope.Question_Errors = ListQuestions[0].Question_Error;
    debugger;
});
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

myApp.controller('QuestionAddController', function ($uibModal, $scope, $document) {


    $scope.animationsEnabled = true;
    $scope.openQuestion = function () {

        $uibModal.open({

            templateUrl: 'Question.html',
            size: 'lg',
            backdrop: 'static',
            controller: 'QuestionController',
            controllerAs: '$ctrl'
        });
    };

    $scope.openQuestionGroup = function () {

        $uibModal.open({

            templateUrl: 'QuestionGroup.html',
            size: 'lg',
            backdrop: 'static',
            controller: 'QuestionGroupController',
            controllerAs: '$ctrl'
        });
    };
});
myApp.controller('QuestionController',
    function ($uibModalInstance, $scope, $http, $ocLazyLoad) {
        $ocLazyLoad.load('classie.js');
        $ocLazyLoad.load('custom-file-input.js');
        //lấy thông tin file câu a
        var fileCauA = new FormData();
        var fileCauB = new FormData();
        var fileCauC = new FormData();
        var fileCauD = new FormData();
        $scope.getFileADetails = function (e) {

            $scope.files = [];
            $scope.$apply(function () {

                // STORE THE FILE OBJECT IN AN ARRAY.
                for (var i = 0; i < e.files.length; i++) {
                    $scope.files.push(e.files[i])
                }

            });
          
            debugger;
            for (var i in $scope.files) {
                fileCauA.append("fileA", $scope.files[i]);
            }

          
        };
        $scope.getFileBDetails = function (e) {

            $scope.files = [];
            $scope.$apply(function () {

                // STORE THE FILE OBJECT IN AN ARRAY.
                for (var i = 0; i < e.files.length; i++) {
                    $scope.files.push(e.files[i])
                }

            });

            debugger;
            for (var i in $scope.files) {
                fileCauB.append("fileA", $scope.files[i]);
            }


        };
        $scope.getFileCDetails = function (e) {

            $scope.files = [];
            $scope.$apply(function () {

                // STORE THE FILE OBJECT IN AN ARRAY.
                for (var i = 0; i < e.files.length; i++) {
                    $scope.files.push(e.files[i])
                }

            });


            for (var i in $scope.files) {
                fileCauC.append("fileC", $scope.files[i]);
            }


        };
        $scope.getFileDDetails = function (e) {

            $scope.files = [];
            $scope.$apply(function () {

                // STORE THE FILE OBJECT IN AN ARRAY.
                for (var i = 0; i < e.files.length; i++) {
                    $scope.files.push(e.files[i])
                }

            });

            for (var i in $scope.files) {
                fileCauD.append("fileD", $scope.files[i]);
            }


        };
        //test
        



        var DapAn;

        var $ctrl = this;
        $ctrl.Submit = function () {
            debugger 
            UploadImage(fileCauA);
            UploadImage(fileCauB);
            //UploadImage(fileCauC);
            //UploadImage(fileCauD);

            //lấy đáp án
            if ($('#CauA').is(':checked')) {
                DapAn = 'CauA'
            }
            if ($('#CauB').is(':checked')) {
                DapAn = 'CauB'
            }
            if ($('#CauC').is(':checked')) {
                DapAn = 'CauC'
            }
            if ($('#CauD').is(':checked')) {
                DapAn = 'CauD'
            }

            //lấy hoán vị
            if ($('#CauA2').is(':checked') == false) {
                $scope.CheckBox.CauAhv = false;
            }
            if ($('#CauB2').is(':checked')) {
                $scope.CheckBox.CauBhv = true;
            }
            if ($('#CauC2').is(':checked')) {
                $scope.CheckBox.CauChv = true;
            }
            if ($('#CauD2').is(':checked')) {
                $scope.CheckBox.CauDhv = true;
            }
            var data = {
                'DeBai': $scope.CauHoi.DeBai,
                'CauA': $scope.CauHoi.CauA,
                'CauB': $scope.CauHoi.CauB,
                'CauC': $scope.CauHoi.CauC,
                'CauD': $scope.CauHoi.CauD,
                'HoanViA': $scope.CheckBox.CauAhv,
                'HoanViB': $scope.CheckBox.CauBhv,
                'HoanViC': $scope.CheckBox.CauChv,
                'HoanViS': $scope.CheckBox.CauDhv,
                'Diem': $scope.CauHoi.Diem,
                'DoPhanCach': $scope.CauHoi.DoPhanCach,
                'DoKho': $scope.CauHoi.DoKho,
                'DapAn': DapAn,
               

            };
            debugger 
            $http.post("/api/Question/add", data)
                .success(function () {
                    
                    //trả về 1 cái ID
                    //trả về tên hình
                    //gọi hàm upload hình
                }).error(function (response) {

                });
        }
        //button Cancel
        $ctrl.cancel = function () {

            $uibModalInstance.dismiss('cancel');
        };
        $(document).ready(function () {
            //$("#DeBai").summernote({
            //    height: 300
            //});
            //$("#DeBai").summernote({
                
            //    height: 300,
                
            //    toolbar: [
            //        // [groupName, [list of button]]
            //        ['fontsize', ['fontname', 'fontsize', 'color', 'bold', 'italic', 'underline', 'strikethrough', 'superscript', 'subscript', 'clear']],
            //        ['para', ['ul', 'ol', 'paragraph', 'style', 'height']],
            //        ['insert', ['table', 'hr', 'link', 'picture', 'video']],
            //        ['undo', ['undo', 'redo']],
            //        ['mics', ['fullscreen', 'codeview', 'help']]

            //    ]
            //});
           
            $('#CauA').prop('checked', true);
            $('#CauA').click(function () {
                debugger
                if ($('#CauA').is(':checked')) {
                    $('#CauB').prop('checked', false);
                    $('#CauC').prop('checked', false);
                    $('#CauD').prop('checked', false);
                } else {
                    $('#CauA').prop('checked', true);
                }


            });
            $('#CauB').click(function () {
                debugger
                if ($('#CauB').is(':checked')) {
                    $('#CauA').prop('checked', false);
                    $('#CauC').prop('checked', false);
                    $('#CauD').prop('checked', false);
                } else {
                    $('#CauA').prop('checked', true);
                }


            });
            $('#CauC').click(function () {
                debugger
                if ($('#CauC').is(':checked')) {
                    $('#CauA').prop('checked', false);
                    $('#CauB').prop('checked', false);
                    $('#CauD').prop('checked', false);
                } else {
                    $('#CauA').prop('checked', true);
                }


            });
            $('#CauD').click(function () {
                debugger
                if ($('#CauD').is(':checked')) {
                    $('#CauA').prop('checked', false);
                    $('#CauB').prop('checked', false);
                    $('#CauC').prop('checked', false);
                } else {
                    $('#CauA').prop('checked', true);
                }


            });
            if (!String.prototype.trim) {
                (function () {
                    // Make sure we trim BOM and NBSP
                    var rtrim = /^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g;
                    String.prototype.trim = function () {
                        return this.replace(rtrim, '');
                    };
                })();
            }

            [].slice.call(document.querySelectorAll('input.input__field')).forEach(function (inputEl) {
                // in case the input is already filled..
                if (inputEl.value.trim() !== '') {
                    classie.add(inputEl.parentNode, 'input--filled');
                }

                // events:
                inputEl.addEventListener('focus', onInputFocus);
                inputEl.addEventListener('blur', onInputBlur);
            });

            function onInputFocus(ev) {
                classie.add(ev.target.parentNode, 'input--filled');
            }

            function onInputBlur(ev) {
                if (ev.target.value.trim() === '') {
                    classie.remove(ev.target.parentNode, 'input--filled');
                }
            }
        });



    });



myApp.controller('QuestionGroupController',
    function ($uibModalInstance, $scope, $uibModal, $ocLazyLoad) {


        //$ocLazyLoad.load('classie.js');

        //var DapAn;

        var $ctrl = this;
        $ctrl.cancel = function () {

            $uibModalInstance.dismiss('cancel');
        };
        $ctrl.Submit = function() {

        }

        $scope.addAnswers=function() {
            $uibModal.open({

                templateUrl: 'QuestionGroupChil.html',
                size: 'lg',
                backdrop: 'static',
                controller: 'QuestionGroupChilController',
                controllerAs: '$ctrl'
            });
            $uibModalInstance.dismiss('cancel');
        }


    });

myApp.controller('QuestionGroupChilController',
    function ($uibModalInstance, $uibModal, $scope, $http, $ocLazyLoad) {
        $ocLazyLoad.load('classie.js');
       
        var DapAn;
        var $ctrl = this;
        $ctrl.addQuestionChil = function () {
            //lấy đáp án
            if ($('#CauA').is(':checked')) {
                DapAn = 'CauA'
            }
            if ($('#CauB').is(':checked')) {
                DapAn = 'CauB'
            }
            if ($('#CauC').is(':checked')) {
                DapAn = 'CauC'
            }
            if ($('#CauD').is(':checked')) {
                DapAn = 'CauD'
            }

            //lấy hoán vị
            if ($('#CauA2').is(':checked') == false) {
                $scope.CheckBox.CauAhv = false;
            }

            if ($('#CauB2').is(':checked')) {
                $scope.CheckBox.CauBhv = true;
            }
            if ($('#CauC2').is(':checked')) {
                $scope.CheckBox.CauChv = true;
            }
            if ($('#CauD2').is(':checked')) {
                $scope.CheckBox.CauDhv = true;
            }
            var data = {
                'DeBai': $scope.CauHoi.DeBai,
                'CauA': $scope.CauHoi.CauA,
                'CauB': $scope.CauHoi.CauB,
                'CauC': $scope.CauHoi.CauC,
                'CauD': $scope.CauHoi.CauD,
                'HoanViA': $scope.CheckBox.CauAhv,
                'HoanViB': $scope.CheckBox.CauBhv,
                'HoanViC': $scope.CheckBox.CauChv,
                'HoanViS': $scope.CheckBox.CauDhv,
                'Diem': $scope.CauHoi.Diem,
                'DoPhanCach': $scope.CauHoi.DoPhanCach,
                'DoKho': $scope.CauHoi.DoKho,
                'DapAn': DapAn

            };
            debugger
            $http.post("/api/Question/add", data)
                .success(function () {
                    debugger 
                }).error(function (response) {

                });

            //$uibModal.open({

            //    templateUrl: 'QuestionGroupChil.html',
            //    size: 'lg',
            //    backdrop: 'static',
            //    controller: 'QuestionGroupChilController',
            //    controllerAs: '$ctrl'
            //});
            //$uibModalInstance.dismiss('cancel');
        }
        //button Cancel
        $ctrl.cancel = function () {

            $uibModalInstance.dismiss('cancel');
        };
        $(document).ready(function () {
            //$("#DeBai").summernote({
            //    height: 300
            //});
            //$("#DeBai").summernote({

            //    height: 300,

            //    toolbar: [
            //        // [groupName, [list of button]]
            //        ['fontsize', ['fontname', 'fontsize', 'color', 'bold', 'italic', 'underline', 'strikethrough', 'superscript', 'subscript', 'clear']],
            //        ['para', ['ul', 'ol', 'paragraph', 'style', 'height']],
            //        ['insert', ['table', 'hr', 'link', 'picture', 'video']],
            //        ['undo', ['undo', 'redo']],
            //        ['mics', ['fullscreen', 'codeview', 'help']]

            //    ]
            //});

            $('#CauA').prop('checked', true);
            $('#CauA').click(function () {
                debugger
                if ($('#CauA').is(':checked')) {
                    $('#CauB').prop('checked', false);
                    $('#CauC').prop('checked', false);
                    $('#CauD').prop('checked', false);
                } else {
                    $('#CauA').prop('checked', true);
                }


            });
            $('#CauB').click(function () {
                debugger
                if ($('#CauB').is(':checked')) {
                    $('#CauA').prop('checked', false);
                    $('#CauC').prop('checked', false);
                    $('#CauD').prop('checked', false);
                } else {
                    $('#CauA').prop('checked', true);
                }


            });
            $('#CauC').click(function () {
                debugger
                if ($('#CauC').is(':checked')) {
                    $('#CauA').prop('checked', false);
                    $('#CauB').prop('checked', false);
                    $('#CauD').prop('checked', false);
                } else {
                    $('#CauA').prop('checked', true);
                }


            });
            $('#CauD').click(function () {
                debugger
                if ($('#CauD').is(':checked')) {
                    $('#CauA').prop('checked', false);
                    $('#CauB').prop('checked', false);
                    $('#CauC').prop('checked', false);
                } else {
                    $('#CauA').prop('checked', true);
                }


            });
            if (!String.prototype.trim) {
                (function () {
                    // Make sure we trim BOM and NBSP
                    var rtrim = /^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g;
                    String.prototype.trim = function () {
                        return this.replace(rtrim, '');
                    };
                })();
            }

            [].slice.call(document.querySelectorAll('input.input__field')).forEach(function (inputEl) {
                // in case the input is already filled..
                if (inputEl.value.trim() !== '') {
                    classie.add(inputEl.parentNode, 'input--filled');
                }

                // events:
                inputEl.addEventListener('focus', onInputFocus);
                inputEl.addEventListener('blur', onInputBlur);
            });

            function onInputFocus(ev) {
                classie.add(ev.target.parentNode, 'input--filled');
            }

            function onInputBlur(ev) {
                if (ev.target.value.trim() === '') {
                    classie.remove(ev.target.parentNode, 'input--filled');
                }
            }
        });



    });


function UploadImage(data) {
    debugger 
    var objXhr = new XMLHttpRequest();
  

    // SEND FILE DETAILS TO THE API.
    objXhr.open("POST", "/api/Question/upload");
    objXhr.send(data);
    
}