app.controller('PrescriptionAdminController', function ($scope, $http, $filter, DTOptionsBuilder, $compile) {
    $scope.dtOption = DTOptionsBuilder.newOptions()
        .withDisplayLength(10)
        .withOption('bLengthChange', false);
    //define 
    $scope.prescriptions_admin = [];

    //get data

    $http.get('http://localhost:6500/Service1.svc/getAllExaminationResults/').then(function (res) {
        $scope.prescriptions_admin = res.data;
    });
    
});

