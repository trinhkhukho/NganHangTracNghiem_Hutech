
(function () {
    'use strict';
    angular.module('myApp', ['ngRoute', 'ngAnimate', 'ngSanitize', 'ui.bootstrap', 'blockUI', 'toastr', 'angularjs-datetime-picker', 'angularTreeview'])
        .config(config)
    .controller('checklogin', ['$scope', 'serviceShareData', '$http', '$location',  function($scope, serviceShareData, $http, $location) {
        $scope.user = serviceShareData.getData("UserLogin");
        if ($scope.user != null && $scope.user.length > 0) {
            $location.url('login');
        }
        else
        {
            
            $location.url('home');
        }
    }])
    .filter('startFrom', function () {
        return function (data, start) {
            return data.slice(start);
        }
    })
    
    config.$inject = ['$routeProvider'];
    function config($routeProvider) {

        $routeProvider
            .when('/',
                {
                    templateUrl: 'Scripts/Angular/Login/Login.html'
                })
             .when('/login',
                {
                  templateUrl: 'Scripts/Angular/Login/Login.html'
                })
            .when('/home',
                {
                    templateUrl: 'Scripts/Angular/Home/home.html'
                })
            .when('/chapter',
                {
                    templateUrl: 'Scripts/Angular/Chapter/Chapter.html'
                })
            .when('/addfile',
                {
                    templateUrl: 'Scripts/Angular/Readfile/readfile.html'
                })
            .when('/addQuestion',
                {
                    templateUrl: 'Scripts/Angular/Questions/addQuestion.html'
                })
            .when('/GroupQuestion',
                {
                    templateUrl: 'Scripts/Angular/GroupQuestions/GroupQuestion.html'
                })
            .when('/GroupQuestionChil',
                {
                    templateUrl: 'Scripts/Angular/GroupQuestions/Question.html'
                })
            .when('/Result',
                {
                    templateUrl: 'Scripts/Angular/Readfile/Result.html'
                })
            .when('/ListQuestion',
                {
                    templateUrl: 'Scripts/Angular/QuestionManager/editQuestion.html'
                })
            .when('/TypeQuestions',
                {
                    templateUrl: 'Scripts/Angular/Chapter/TypeQuestions.html'
                })
            .when('/Dashboard',
                {
                    templateUrl: 'Scripts/Angular/Dashboard/Dashboard.html'
                })
            .when('/Dashboard_Faculties',
                {
                    templateUrl: 'Scripts/Angular/Dashboard/Dashboard_Faculties.html'
                })
            .when('/Dashboard_Subject',
                {
                    templateUrl: 'Scripts/Angular/Dashboard/Dashdoard_Subject.html'
                })
            .when('/Faculties',
                {
                    templateUrl: 'Scripts/Angular/Faculties/Faculties.html'
                })
            .when('/Subjects',
                {
                    templateUrl: 'Scripts/Angular/Subjects/Subjects.html'
                })
            .when('/Chapters',
                {
                    templateUrl: 'Scripts/Angular/Chapters/Chapters.html'
                })
            .when('/Decentralization',
                {
                    templateUrl: 'Scripts/Angular/Decentralization/Decentralization.html'
                })
            .when('/ListUser',
                {
                    templateUrl: 'Scripts/Angular/ListUser/ListUser.html'
                })
            .when('/Register',
                {
                    templateUrl: 'Scripts/Angular/Register/Register.html'
                })
    };

})();