var TaoDe = angular.module('ui.bootstrap.demo', []);
//lây thông tin khoa
TaoDe.controller('GetKhoa', function ($scope, $http) {
    $http.get('http://localhost/web_api_public/api/Faculties').then(function (response) {
        
        $scope.Khoas = response.data;
    });
});
//lấy thông tin môn học
TaoDe.controller('GetMonHoc', function ($scope, $http) {
    $http.get('http://localhost/web_api_public/api/Subjects').then(function (response) {
        $scope.MonHocs = response.data;
    });
});
//lấy phần
TaoDe.controller('GetPhan', function ($scope, $http) {
    $http.get('http://localhost/web_api_public/api/Chapters').then(function (response) {
        $scope.Phans = response.data;
    });
});



//TaoDe.controller('TaoCauHoi', function ($scope) {
//    var ThongTinCoBan = {
//        _Khoa: KhoaSelected,
//        _NameKhoa:NameKhoa,
//        _MonHoc: MonhocSelected,
//        _NameMonHoc:NameMonHoc,
//        _Phan: PhanSelected,
//        _NamePhan: NamePhan
//    }
//    $scope.ThongTinCoBan = ThongTinCoBan;
//});

//controller chuyển trang.
//TaoDe.config(['$routeProvider',
//         function ($routeProvider) {
//             $routeProvider.
//                when('/TaoCauHoi', {
//                    templateUrl: 'TaoCauHoi.html',
//                    controller: 'TaoCauHoi'
//                }).
//                otherwise({
//                    redirectTo: '/TaoCauHoi'
//                });
//         }]);

//var KhoaSelected;
//var NameKhoa;
//var MonhocSelected;
//var NameMonHoc;
//var PhanSelected;
//var NamePhan;
//function SelectKhoa() {
//    KhoaSelected = document.getElementById("khoa").value;
//    NameKhoa = document.getElementById("khoa");
//}
//function SelectMonHoc() {
//    MonhocSelected = document.getElementById("monhoc").value;
//    NameMonHoc = document.getElementById("monhoc");
//}
//function SelectPhan() {
//    PhanSelected = document.getElementById("phan").value;
//    NamePhan = document.getElementById("phan");
//}

//function btn_LoadTaoCauHoi()
//{
//    window.location.href = "#TaoCauHoi.html";
//}

