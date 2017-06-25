(function (app) {
    'use strict';
    app.controller('editQuestionController', questionCrt);
    questionCrt.$inject = ['$scope', '$http', '$route', '$timeout', 'blockUI', 'toastr'];
    function questionCrt($scope, $http, $route, $timeout, blockUI, toastr) {
        blockUI.start();
        $http.get("api/Question/get").then(function (response) {
            blockUI.stop();
            debugger 
            var ketqua = response.data;
            //var ketqua2 = JSON.parse(this.response);
            debugger 
            if (ketqua != null) {
                $scope.ListQuestions = ketqua;
                toastr.success('', 'Tải dnah sách câu hỏi thành công');

            } else {
                toastr.error('', 'Không tải được danh sách câu hỏi');

            }
        });
    };
})(angular.module('myApp'));