app.controller('PrescriptionController', function ($scope, $http, $filter, DTOptionsBuilder, $compile) {
    $scope.dtOption = DTOptionsBuilder.newOptions()
        .withDisplayLength(10)
        .withOption('bLengthChange', false);
    //define 
    $scope.prescriptions = [];
    $scope.prescriptions_admin = [];
    $scope.prescription = {};

    var cookie = document.cookie;
    var dispenserId = cookie.split('=').pop();
    //get data
    $http.get('http://localhost:6500/Service1.svc/getAllExaminationResultsByDispenser/').then(function (res) {
        $scope.prescriptions = res.data;
    });

    $http.get('http://localhost:6500/Service1.svc/getAllExaminationResults/').then(function (res) {
        $scope.prescriptions_admin = res.data;
    });

    $scope.phatThuoc = function (e) {
        var params = {
            'ExaminationResultID': e.ExaminationResultID,
            'DispenserID': dispenserId
        }
        $http.put('http://localhost:6500/Service1.svc/ExaminationResults/edit', params).then(function (res) {
            window.location.reload();
        });
    };
    
});

