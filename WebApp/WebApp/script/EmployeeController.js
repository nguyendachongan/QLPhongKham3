app.controller('EmployeeController', function ($scope, $http, $filter, DTOptionsBuilder, $compile) {
    $scope.dtOption = DTOptionsBuilder.newOptions()
        .withDisplayLength(10)
        .withOption('bLengthChange', false);
    //define 
    $scope.employees = [];
    $scope.employee = {};
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
    $http.get('http://localhost:6500/Service1.svc/getAllEmployees/').then(function (res) {
        $scope.employees = res.data;
    });

    //show modal
    $scope.showModal = function (id) {
        $scope.id = id;
        if (id == 0) {
            $("#modalTitle").text("New Employee");
            $("#btnAddAction").text("Add");

            $scope.IdentifyCard = "";
            $scope.FirstName = "";
            $scope.LastName = "";
            $scope.MiddleName = "";
            $scope.Gender = 'Male';
            $scope.Phone = "";
            $scope.Address = "";
            $scope.BirthDay = new Date();
            $scope.Position = $scope.positions[0];
        } else {
            $("#modalTitle").text("Edit Employee");
            $("#btnAddAction").text("Update");

            //find selected item
            $http.get('http://localhost:6500/Service1.svc/getEmployee?id=' + id).then(function (res) {
                $scope.employee = res.data;
                $scope.IdentifyCard = $scope.employee.IdentifyCard;
                $scope.FirstName = $scope.employee.FirstName;
                $scope.MiddleName = $scope.employee.MiddleName;
                $scope.LastName = $scope.employee.LastName;
                $scope.Gender = $scope.employee.Gender ? 'Male' : 'Female';
                $scope.Phone = $scope.employee.Phone;
                $scope.Address = $scope.employee.Address;
                $scope.BirthDay = $scope.employee.BirthDay;
                $scope.Position = $scope.positions[$scope.employee.Position-1];
            });
        }
        $("#EmployeeModal").modal('show');
    };

    //save 
    $scope.saveData = function () {
        if ($scope.id == 0) {
            var params = {
                'IdentifyCard': $scope.IdentifyCard,
                'FirstName': $scope.FirstName,
                'MiddleName': $scope.MiddleName,
                'LastName': $scope.LastName,
                'Gender': $scope.Gender == 'Male' ? true : false,
                'Phone': $scope.Phone,
                'Address': $scope.Address,
                'Position': $scope.Position.id
            };
            /*$http.post("http://localhost:6500/Service1.svc/Employees/new", params).then(function (res) {
                window.location.reload();
            });*/
        }
        else {
            var params = {
                'EmployeeID': $scope.id,
                'IdentifyCard': $scope.IdentifyCard,
                'FirstName': $scope.FirstName,
                'MiddleName': $scope.MiddleName,
                'LastName': $scope.LastName,
                'Gender': $scope.Gender == 'Male' ? true : false,
                'Phone': $scope.Phone,
                'Address': $scope.Address,
                'Position': $scope.Position
            };

            $http.put("http://localhost:6500/Service1.svc/Employees/edit", params).then(function (res) {
                window.location.reload();
            });
        }

    }
});

