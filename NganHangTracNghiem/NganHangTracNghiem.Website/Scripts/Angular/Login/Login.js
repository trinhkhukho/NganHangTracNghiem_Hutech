//get host of web API
var xml = new XMLHttpRequest();
xml.open('GET', '/Scripts/XML/ClinicInfo.xml', false)
xml.send();
var xmlData = xml.responseXML;
var host;
xmlData = (new DOMParser()).parseFromString(xml.responseText, 'text/xml');
var clinic = xmlData.getElementsByTagName("clinic");
hostapi = clinic[0].getElementsByTagName("host")[0].firstChild.data;

//create module login
var mylogin = angular.module('login', []);
//create controller login
mylogin.controller('getlogin', function ($scope,accountService,serviceShareData,$http) {
    
    $scope.user = {
        UserName: "",
        PassWord:""
    }
    $scope.message = "";
    $scope.submit = function () {
        debugger;
        accountService.Login($scope.user).then(function (data) {
            if (data.error === "" || data.error == null)
            {
                var hosts = window.location.origin;
                //var hostname = hosts + "/View/index.html";
                var hostname = hosts;
                window.location = hostname;
            }
            else
            {
                $scope.message = data.error;
                alert("Tên đăng nhập hoặc mật khẩu sai !");
            }
        }, function (error){
            $scope.message = error.error_description;
        })
    }
});
mylogin.factory('dataService',['$http',function($http){
    var far = [];
    far.GetLogin = function () {
        return $http.get(hostapi + 'api/Login').then(function (response) {
            return response.data;
        })
    }
    return fac;
}])
mylogin.factory('userService', function () {
    var fac = {};
    fac.CurrentUser = null;
    fac.SetCurrentUser = function (user) {
        fac.CurrentUser = user;
        sessionStorage.user = angular.toJson(user);
    }
    fac.GetCurrentUser = function()
    {
        fac.CurrentUser = angular.fromJson(sessionStorage.user);
        return fac.CurrentUser;
    }
    return fac;
})
mylogin.factory('accountService', ['$http', '$q', 'userService', function ($http, $q, userService) {
    var fac = {};
    fac.Login=function(user)
    {
        var obj = { 'username': user.UserName, 'password': user.PassWord, 'grant_type': 'password' };
        Object.toparams = function ObjectToParams(obj) {
            var p = [];
            for(var key in obj)
            {
                p.push(key + '=' + encodeURIComponent(obj[key]));
            }
            return p.join('&');
        }
        var defer = $q.defer();
        $http({
            method: 'post',
            url: hostapi + 'token',
            data: Object.toparams(obj),
            headers: {'Content_type':'application/x-www-form-urlencoded'}
        }).then(function (response) {
            userService.SetCurrentUser(response.data);
            defer.resolve(response.data);
        }, function (error) {
            defer.resolve(error.data);
        })
        return defer.promise;
    }
    fac.Logout = function () {
        userService.CurrentUser = null;
        userService.SetCurrentUser(userService.CurrentUser);
    }
    return fac;
}])
mylogin.config(['$httpProvider', function ($httpProvider) {
    var interceptor=function(userService,$q)//làm singe page thì thêm cái location zô đây
    {
        return {
            request: function (config) {
                var currentUser = userService.GetCurrentUser();
                if(currentUser!=null)
                {
                    config.headers['Authorization'] = 'Bearer' + currentUser.access_token;
                }
                return config;
            },
            responseError: function(rejection)
            {
                if(rejection.status===400)
                {
                    var hosts = window.location.origin;
                    var hostname = hosts + "/Scripts/Angular/Login/Login.html";
                    window.location = hostname;
                    return $q.reject(rejection);
                }
                if (rejection.status === 401) {
                    var hosts = window.location.origin;
                    var hostname = hosts + "/Scripts/Angular/Login/Login.html";
                    window.location = hostname;
                    return $q.reject(rejection);
                }
                if (rejection.status === 403) {
                    var hosts = window.location.origin;
                    var hostname = hosts + "/Scripts/Angular/Login/Login.html";
                    window.location = hostname;
                    return $q.reject(rejection);
                }
                return $q.reject(rejection);
            }
        }
    }
    var params = ['userService', '$q'];
    interceptor.$inject = params;
    $httpProvider.interceptors.push(interceptor);
}])
// share data between pages
mylogin.service('serviceShareData', function ($window) {
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