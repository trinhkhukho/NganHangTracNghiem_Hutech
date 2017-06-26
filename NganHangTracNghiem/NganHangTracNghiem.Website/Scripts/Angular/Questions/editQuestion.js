(function (app) {
    'use strict';
    app.controller('editQuestionController', questionCrt);
    questionCrt.$inject = ['$scope', '$http', '$route', '$timeout', '$uibModal', 'blockUI', 'toastr', 'serviceGetId'];
    function questionCrt($scope, $http, $route, $timeout, $uibModal, blockUI, toastr, serviceGetId) {
        blockUI.start();
        //lấy dữ liệu
        $http.get("api/Question/get").then(function (response) {
            blockUI.stop();
            var ketqua = response.data;
            if (ketqua != null) {
                $scope.ListQuestions = ketqua;
                toastr.success('', 'Tải dnah sách câu hỏi thành công');

            } else {
                toastr.error('', 'Không tải được danh sách câu hỏi');

            }
        });
        //bật pop chỉnh sửa câu hỏi
        $scope.editQuestion = function (Id) {
            serviceGetId.clearall();
            serviceGetId.addData(Id);
            $uibModal.open({
                templateUrl: 'Scripts/Angular/Questions/popQuestion.html',
                size: 'lg',
                backdrop: 'static',
                controller: 'popQuestionController',
                controllerAs: '$ctrl'
      
            });
        };
    };
    app.controller('popQuestionController', popCrt);
    popCrt.$inject = ['$uibModalInstance', '$scope', '$http', 'serviceGetId'];
    function popCrt($uibModalInstance, $scope, $http, serviceGetId) {
        var Id = serviceGetId.getData();
        var $ctrl = this;
        $http.get(hostapi + 'api/Questions/' + Id).then(function (response) {
            debugger 
            $scope.Question = response.data;
            $('#CauHoi').val($scope.Question.Content);
           
        });
        //$(document).ready(function() {
        //    CKEDITOR.instances.CauHoi.setData("aaa");

        //});
        $ctrl.cancel = function () {
            debugger
            $uibModalInstance.dismiss('cancel');
        };
    };

})(angular.module('myApp'));