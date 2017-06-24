(function () {
    'use strict';
    angular.module('myApp', ['ngRoute', 'ngAnimate', 'blockUI', 'toastr'])
        .config(config);
      

//var myApp = angular.module('myApp', ['ngRoute']);

    config.$inject = ['$routeProvider'];
    function config($routeProvider) {

        $routeProvider
            .when('/',
                {
                    templateUrl: 'Scripts/Angular/Home/home.html'
                })
            //.when('/login',
            //    {
            //        templateUrl: 'Scripts/Angular/Login/Login.html'
            //    })
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
    };

})();