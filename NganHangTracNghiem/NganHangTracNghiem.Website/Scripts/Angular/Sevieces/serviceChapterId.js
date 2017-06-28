(function (app) {
    'use strict';

    app.factory('serviceChapterId', serviceGetId);
    serviceGetId.$inject = ['$window'];

    function serviceGetId($window) {

        var addChapterId = function (newObj) {

            $window.sessionStorage.setItem("ChapterId", newObj);
        };

        var getChapterId = function () {
            var mydata = $window.sessionStorage.getItem("ChapterId");

            return mydata;
        };
        var clearall = function clearAll() {
            $window.sessionStorage.clear();
        }
        return {
            addChapterId: addChapterId,
            getChapterId: getChapterId,
            clearall: clearall
        };

    }

})(angular.module('myApp'));