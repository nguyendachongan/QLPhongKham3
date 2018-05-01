/// <reference path="D:\Project\New folder\RestautantManagement\ManageRestaurant\FrontEnd\js/angular/angular.js" />
app.controller('typeController', function ($scope, $http, $filter, DTOptionsBuilder) {
    $scope.dtOption = DTOptionsBuilder.newOptions()
       .withDisplayLength(10)
       .withOption('bLengthChange', false);

    //get data
    $scope.types = [];
    $scope.type = {};
    $http.get('http://localhost:1523/api/typeofemployee').then(function (res) {
        $scope.types = res.data;
    });

    //add and update
    $scope.saveData = function () {
        //$scope.type.NameOfType = $scope.typeName;

        if ($scope.id == 0) {

            var params = {
                "NameOfType": $scope.typeName
            };

            $http.post("http://localhost:1523/api/typeofemployee", params).then(function (res) {
                window.location.reload();
            });
        }
        else {
            var params = {
                "TypeID": $scope.type.TypeID,
                "NameOfType": $scope.typeName
            };
            $http.put("http://localhost:1523/api/typeofemployee/" + $scope.type.TypeID, params).then(function (res) {
                window.location.reload();
                //find selected item
                // $scope.type = $filter('filter')($scope.types, { typeid: parseint(id) }, true)[0];
                // $scope.type.name = $scope.typename;
            });
        }

    }
    //delete
    $scope.deleteItem = function (id) {

        $http.delete("http://localhost:1523/api/typeofemployee/" + id).then(function (res) {
            window.location.reload();
        });
    }
    //show modal
    $scope.showModal = function (id) {
        jQuery(function () {
            if (id == 0) {
                $("#modalTitle").text("New Type");
                $("#btnAddAction").text("Add");
                $scope.id = 0;
            } else {
                $("#modalTitle").text("Edit Type");
                $("#btnAddAction").text("Update");
                $("#myModal").modal('show');
                //find selected item
                $scope.type = $filter('filter')($scope.types, id, true)[0];

                $scope.typeName = $scope.type.NameOfType;
                $scope.id = $scope.type.TypeID;
            }
            $("#myModal").modal('show');
        });
    }

    $scope.confirm = function (id) {
        jQuery(function () {

            //find selected item
            $scope.type = $filter('filter')($scope.types, id, true)[0];

            $scope.typeName = $scope.type.NameOfType;
            $scope.id = $scope.type.TypeID;


            $("#typemodal").modal('show');
        });
    }

});
app.controller("employeeController", function ($scope, $http, $filter, DTOptionsBuilder) {
    $scope.dtOptions = DTOptionsBuilder.newOptions()
       .withDisplayLength(10)
       .withOption('bLengthChange', false);
    //get data
    $scope.employees = [];
    $scope.type = {};
    $http.get('http://localhost:1523/api/employee').then(function (res) {
        $scope.employees = res.data;

    

    });

    //add and update
    $scope.saveData = function () {
        $scope.type.Username = $scope.Username;
        $scope.type.Password = $scope.Password;
        $scope.type.FirstName = $scope.FirstName;
        $scope.type.LastName = $scope.LastName;
        $scope.type.Gender = $scope.Gender;
        $scope.type.Phone = $scope.Phone;
        $scope.type.Address = $scope.Address;
        $scope.type.TypeID = $scope.TypeID[0];
        if ($scope.id == 0) {

            var params = {
                "Username": $scope.Username,
                "Password": $scope.Password,
                "FirstName": $scope.FirstName,
                "LastName": $scope.LastName,
                "Gender": $scope.Gender,
                "Phone": $scope.Phone,
                "Address": $scope.Address,
                "TypeID": $scope.TypeID.TypeID,

            };

            $http.post("http://localhost:1523/api/employee", params).then(function (res) {
                window.location.reload();
            });


        }
        else {
            var params = {
                "EmployeeID": $scope.id,
                "Username": $scope.type.Username,
                "Password": $scope.type.Password,
                "FirstName": $scope.type.FirstName,
                "LastName": $scope.type.LastName,
                "Gender": $scope.type.Gender,
                "Phone": $scope.type.Phone,
                "Address": $scope.type.Address,
                "TypeID": $scope.TypeID.TypeID,


            };
            $http.put("http://localhost:1523/api/employee/" + $scope.id, params).then(function (res) {
                window.location.reload();
                //find selected item
                // $scope.type = $filter('filter')($scope.types, { typeid: parseint(id) }, true)[0];
                // $scope.type.name = $scope.typename;
            });
        }

    }

    //delete
    $scope.deleteItem = function (id) {

        $http.delete("http://localhost:1523/api/employee/" + id).then(function (res) {
            window.location.reload();
        });
    }
    //show modal
    $scope.showModal = function (id) {
        jQuery(function () {
            if (id == 0) {
                $("#modalTitle").text("New Employee");
                $("#btnAddAction").text("Add");
                $scope.id = 0;
            } else {
                $("#modalTitle").text("Edit Employee");
                $("#btnAddAction").text("Update");

                //find selected item
                $scope.type = $filter('filter')($scope.employees, id, true)[0];
                $scope.Username = $scope.type.Username;
                $scope.Password = $scope.type.Password;
                $scope.FirstName = $scope.type.FirstName;
                $scope.LastName = $scope.type.LastName;
                $scope.Gender = $scope.type.Gender;
                $scope.Phone = $scope.type.Phone;
                $scope.Address = $scope.type.Address;
                $scope.TypeID = $scope.type.TypeID;
                $scope.id = $scope.type.EmployeeID;

            }
            $("#employeeModal").modal('show');
        });
    }


    $scope.confirm = function (id) {
        jQuery(function () {

            //find selected item
            //find selected item
            $scope.type = $filter('filter')($scope.employees, id, true)[0];
            $scope.id = $scope.type.EmployeeID;
            $scope.Username = $scope.type.Username;
            $scope.Password = $scope.type.Password;
            $scope.FirstName = $scope.type.FirstName;
            $scope.LastName = $scope.type.LastName;
            $scope.Gender = $scope.type.Gender;
            $scope.Phone = $scope.type.Phone;
            $scope.Address = $scope.type.Address;
            $scope.TypeID = $scope.type.TypeID;
            

            $("#mymodal").modal('show');
        });
    }

});
app.controller('drugsController', function ($scope, $http, $filter, DTOptionsBuilder, $compile) {
    $scope.dtOption = DTOptionsBuilder.newOptions()
        .withDisplayLength(10)
        .withOption('bLengthChange', false);
    //get data
    $scope.drugs = [];
    $scope.drug = {};

    $http.get('http://localhost:6500/Service1.svc/getAllDrugs/').then(function (res) {
        $scope.drugs = res.data;
    });

});