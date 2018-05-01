app.controller('tableController', function ($scope, $http, $filter, DTOptionsBuilder) {
    $scope.dtOption = DTOptionsBuilder.newOptions()
      .withDisplayLength(10)
      .withOption('bLengthChange', false);
    //get data
    $scope.Tables = [];
    $scope.Table = {};
    $http.get('http://localhost:1523/api/Table').then(function (res) {
        $scope.Tables = res.data;
    });

    //delete
    $scope.deleteItem = function (id) {
        $http.delete("http://localhost:1523/api/Table/" + id).then(function (res) {
            window.location.reload();
            //location.reload();
        });
    }

    //add and update
    $scope.saveData = function () {
        $scope.Table.Area = $scope.Area;    
        if ($scope.id == 0) {
            var params = {
                "Area": $scope.Area
            };
            $http.post("http://localhost:1523/api/Table/", params).then(function (res) {
                window.location.reload();
            });
        }
        else {
            var params = {
                "TableID": $scope.id,
                "Area": $scope.Area
            };
            $http.put("http://localhost:1523/api/Table/" + $scope.id, params).then(function (res) {
                window.location.reload();
            });
        }
    }


    //show modal
    $scope.showModal = function (id) {
        jQuery(function () {
            if (id == 0) {
                $("#modalTitle").text("New Table");
                $("#btnAddAction").text("Add");
                $scope.id = 0;
            } else {
                $("#modalTitle").text("Edit Table");
                $("#btnAddAction").text("Update");

                //find selected item
                $scope.Table = $filter('filter')($scope.Tables, { TableID: id }, true)[0];
                $scope.id = $scope.Table.TableID;
                $scope.Area = $scope.Table.Area;
            }
            $("#myModal").modal('show');
        });
    }


    $scope.confirm = function (id) {
        jQuery(function () {

            //find selected item
            $scope.Table = $filter('filter')($scope.Tables, { TableID: id }, true)[0];
            $scope.id = $scope.Table.TableID;
            $scope.Area = $scope.Table.Area;


            $("#typemodal").modal('show');
        });
    }
});