(function (app) {
    'use strict';

    app.factory('serviceGetId', serviceGetId);
    serviceGetId.$inject = ['$window'];

    function serviceGetId($window) {

        var addData = function (newObj) {

            $window.sessionStorage.setItem("", newObj);
        };

        var getData = function () {
            var mydata = $window.sessionStorage.getItem("");

            return mydata;
        };
        var clearall = function clearAll() {
            $window.sessionStorage.clear();
        }
        return {
            addData: addData,
            getData: getData,
            clearall: clearall
        };

    }

})(angular.module('myApp'));