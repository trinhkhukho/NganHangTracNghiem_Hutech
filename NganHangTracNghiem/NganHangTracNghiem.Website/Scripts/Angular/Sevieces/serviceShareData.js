(function (app) {
    'use strict';

    app.factory('serviceShareData', serviceShareData);
    serviceShareData.$inject = ['$window'];

    function serviceShareData($window) {

        var KEY = 'App.SelectedValue';

        var addData = function (newObj, key) {
            KEY = key;
            var mydata = $window.sessionStorage.getItem(KEY);
            if (mydata) {
                mydata = JSON.parse(mydata);
            } else {
                mydata = [];
            }
            mydata.push(newObj);
            $window.sessionStorage.setItem(KEY, JSON.stringify(mydata));
        };

        var getData = function (key) {
            KEY = key;
            var mydata = $window.sessionStorage.getItem(KEY);
            if (mydata) {
                mydata = mydata;
            }
            return mydata || [];
        };
        var clearall = function clearAll(key) {
            KEY = key;
            $window.sessionStorage.removeItem(KEY);
        }
        return {
            addData: addData,
            getData: getData,
            clearall: clearall
        };

    }

})(angular.module('myApp'));