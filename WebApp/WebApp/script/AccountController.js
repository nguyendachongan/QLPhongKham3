app.controller('AccountController', function ($scope, $http, $filter, DTOptionsBuilder, $compile) {
    $scope.dtOption = DTOptionsBuilder.newOptions()
        .withDisplayLength(10)
        .withOption('bLengthChange', false);
    //define 
    $scope.accounts = [];
    $scope.account = {};
    $scope.employees = [];
    $scope.positions = [
        {
            id: 1,
            position: 'Quản lý'
        },
        {
            id: 2,
            position: 'Bác sĩ'
        },
        {
            id: 3,
            position: 'Nhân viên nhận bệnh'
        },
        {
            id: 4,
            position: 'Nhân viên phát thuốc'
        }
    ];
    //get data
    $http.get('http://localhost:6500/Service1.svc/getAllAccounts/').then(function (res) {
        $scope.accounts = res.data;
    });

    $http.get('http://localhost:6500/Service1.svc/getAllNewEmployees/').then(function (res) {
        $scope.employees = res.data;
        console.log($scope.employees);
    });
    //show modal
    $scope.showModal = function (id) {
        $("#modalTitle").text("Thêm nhân viên");
        $("#btnAddAction").text("Thêm");
        $scope.EmployeeID = $scope.employees[0] ;
        $scope.UserName = "";
        $scope.Password = "";
        $("#EmployeeModal").modal('show');
    };

    //save 
    $scope.saveData = function () {
        var params = {
                'EmployeeId': $scope.EmployeeID.EmployeeID,
                'UserName': $scope.UserName,
                'Password': $scope.Password,
                            };
            $http.post("http://localhost:6500/Service1.svc/Accounts/new", params).then(function (res) {
                window.location.reload();
            });
    }
});

