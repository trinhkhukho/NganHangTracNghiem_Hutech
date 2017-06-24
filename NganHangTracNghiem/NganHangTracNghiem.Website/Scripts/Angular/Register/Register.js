//get host of web API
var xml = new XMLHttpRequest();
xml.open('GET', '/Scripts/XML/ClinicInfo.xml', false)
xml.send();
var xmlData = xml.responseXML;
var host;
xmlData = (new DOMParser()).parseFromString(xml.responseText, 'text/xml');
var clinic = xmlData.getElementsByTagName("clinic");
host = clinic[0].getElementsByTagName("host")[0].firstChild.data;
//create module Register
var myRegister = angular.module('Register', []);
//create controller Register
myRegister.controller('getData', function ($scope, $http) {

    
    $scope.user = {
        Name:"",
        UserName: "",
        PassWord: "",
        PassWord2:"" 
    }
    $scope.Error = {
        NameError: "",
        UserNameError: "",
        PassWordError: "",
        PassWord2Error: "",
        PassWordCorrect:""
    }
    $scope.message = "";
    $scope.submit = function () {
        debugger;
        var result = 1;
        if( $scope.user.Name ==="")
        {
            $scope.Error.NameError = " * nhập tên";
            result = 0;
        }
        else
        {    
            $scope.Error.NameError = "";
        }
        if( $scope.user.UserName ==="")
        {
            $scope.Error.UserNameError = " * nhập tên tài khoản";
            result = 0;
        }
        else {
            $scope.Error.UserNameError = "";
        }
        if ($scope.user.PassWord ==="") {
            $scope.Error.PassWordError = " * nhập mật khẩu";
            result = 0;
        }
        else {
            $scope.Error.PassWordError = "";
        }
        if ($scope.user.PassWord2=="") {
            $scope.Error.PassWord2Error = " * nhập lại mật khẩu";
            result = 0;
        }
        else {
            $scope.Error.PassWord2Error = "";
        }
        if($scope.user.PassWord!=$scope.user.PassWord2)
        {
            $scope.Error.PassWordCorrect = " * mật khẩu không khớp";
            result = 0;
        }
        else {
            $scope.Error.PassWordCorrect = "";
        }
        var data = {
            'Id': 0,
            'Username': $scope.user.UserName,
            'Password': $scope.user.PassWord,
            'Name': $scope.user.Name,
            'CreateDate': null,
            'Deleted': null,
            'LogOut': null,
            'LastActivity': null,
            'LastLogIn': null,
            'LastPasswordChanged': null,
            'LastLogOut': null,
            'Salt': null,
            'Comment': null,
            'BuildInUser': null
        };
        $http.post(host + "api/Register/UserName", data).then(function (response) {
            if (response.data == 1) {
                alert("tên tài khoản đã tồn tại");
                $scope.Error.UserNameError = " * ";
                result = 0;
            }
            else
            {
                $scope.Error.UserNameError = "";
                if (result == 1) {
                    $http.post(host + "api/Users", data).then(function(response) {
                        debugger;
                        if (response.status == 201) {
                            alert("Tạo tài khoản thành công");
                            var hosts = window.location.origin;
                            var hostname = hosts + "/Scripts/Angular/Login/Login.html";
                            window.location = hostname;
                        } else {
                            alert("Lỗi !");
                        }
                    });
                }
            }
        });
    }
});