//var LsQuestions_Success;
//var LsQuestions_Error;
(function (app) {
    'use strict';
        //app.filter('startFrom', function () {
        //    return function (data, start) {
        //        return data.slice(start);
        //    }
        //});


    app.controller('Result', resultCrt);
    resultCrt.$inject = ['$scope', '$sce', '$http', '$location', 'blockUI', 'toastr', 'serviceShareData'];
    function resultCrt($scope, $sce, $http, $location, blockUI, toastr, serviceShareData) {
        debugger 
        $scope.from = {};
        $scope.pagesize = 5;
        $scope.currentpage = 1;
        $scope.trustAsHtml = $sce.trustAsHtml;
        $scope.ListQuestions = null;
        $scope.ListQuestions = serviceShareData.getData();
        var ListQuestions = JSON.parse($scope.ListQuestions);
        $scope.Question_Successs = ListQuestions[0].Question_Success;
        $scope.Question_Errors = ListQuestions[0].Question_Error;
    }


})(angular.module('myApp'));



