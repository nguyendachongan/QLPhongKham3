app.controller('AccountController', function ($scope, $http, $filter, DTOptionsBuilder, $compile) {
    $scope.dtOption = DTOptionsBuilder.newOptions()
        .withDisplayLength(10)
        .withOption('bLengthChange', false);
    //define 
    $scope.accounts = [];
    $scope.acount = {};
    $scope.types = [];

    //get data
    $http.get('http://localhost:6500/Service1.svc/getAllDrugs/').then(function (res) {
        $scope.drugs = res.data;
    });
    $http.get('http://localhost:6500/Service1.svc/getAllTypeDrugs/').then(function (res) {
        $scope.types = res.data;
    });

    //show modal
    $scope.showModal = function (id) {
        $scope.id = id;
        if (id == 0) {
            $("#modalTitle").text("New Drug");
            $("#btnAddAction").text("Add");

            $scope.Name = "";
            $scope.Description = "";
            $scope.Price = 0;
            $scope.Type = $scope.types[0];
        } else {
            $("#modalTitle").text("Edit Drug");
            $("#btnAddAction").text("Update");

            //find selected item
            $http.get('http://localhost:6500/Service1.svc/getOneDrug?id=' + id).then(function (res) {
                $scope.drug = res.data;
                $scope.Name = $scope.drug.Name;
                $scope.Description = $scope.drug.Description;
                $scope.Price = $scope.drug.Price;
                $scope.Type = $scope.types.find(item => item.TypeOfDrugID === $scope.drug.TypeID);
                console.log($scope.Type);
            });
        }
        $("#DrugModal").modal('show');
    };

    //save 
    $scope.saveData = function () {
        if ($scope.id == 0) {
            var params = {
                "Name": $scope.Name,
                "Description": $scope.Description,
                "Price": $scope.Price,
                "TypeID": $scope.Type.TypeOfDrugID
            };

            $http.post("http://localhost:6500/Service1.svc/Drugs/new", params).then(function (res) {
                window.location.reload();
            });
        }
        else {
            var params = {
                "DrugID": $scope.id,
                "Name": $scope.Name,
                "Description": $scope.Description,
                "Price": $scope.Price,
                "TypeID": $scope.Type.TypeOfDrugID
            };
            $http.put("http://localhost:6500/Service1.svc/Drugs/edit", params).then(function (res) {
                window.location.reload();
            });
        }

    }
});

