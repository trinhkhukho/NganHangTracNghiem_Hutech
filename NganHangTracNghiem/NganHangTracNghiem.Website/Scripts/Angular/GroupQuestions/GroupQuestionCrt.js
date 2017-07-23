
(function (app) {
    'use strict';
    app.controller('GroupQuestionController', questionCrt);
    questionCrt.$inject = ['$scope', '$http', '$location', 'blockUI', 'toastr', 'serviceGetId'];
    function questionCrt($scope, $http, $location, blockUI, toastr, serviceGetId) {
        $scope.ChapterId = JSON.parse(serviceShareData.getData("ChapterId"));
        $scope.ChapterId = $scope.ChapterId[0];
        $scope.CauHoi = {
            Diem: 0.5,
            DoKho: 0.5,
            DoPhanCach: 0.5
        };
        $scope.addQuestion = function () {
            blockUI.start();
            var deBai = CKEDITOR.instances.CauHoi.getData();
            var data = {
                'DeBai': deBai,
                'Diem': $scope.CauHoi.Diem,
                'DoPhanCach': $scope.CauHoi.DoPhanCach,
                'DoKho': $scope.CauHoi.DoKho
            };
            $http.post("api/Question/addGroupParent", data).then(function (response) {
                blockUI.stop();
                var ketqua = response.data;
                if (ketqua === 0) {
                    toastr.success('', 'Thêm đề bài thất bại');
                } else {


                    toastr.success('', 'Thêm đề bài thành công');
                    //location.reload(true);
                    //ParentId = ketqua;

                    serviceGetId.addData(ketqua);
                    $location.url('GroupQuestionChil');
                }

            });

        }


    };


    //app.service('serviceGetId', function ($window) {
    //    //var KEY = 'App.SelectedValue';

    //    var addData = function (newObj) {
    //        //debugger 
    //        //var mydata = $window.sessionStorage.getItem(KEY);
    //        //if (mydata) {
    //        //    mydata = JSON.parse(mydata);
    //        //} else {
    //        //    mydata = [];
    //        //}
    //        //mydata.push(newObj);
    //        $window.sessionStorage.setItem("",newObj);
    //    };

    //    var getData = function () {
    //        var mydata = $window.sessionStorage.getItem("");
    //        //if (mydata) {
    //        //    mydata = mydata;
    //        //}
    //        return mydata;
    //    };
    //    var clearall = function clearAll() {
    //        $window.sessionStorage.clear();
    //    }
    //    return {
    //        addData: addData,
    //        getData: getData,
    //        clearall: clearall
    //    };
    //});
})(angular.module('myApp'));