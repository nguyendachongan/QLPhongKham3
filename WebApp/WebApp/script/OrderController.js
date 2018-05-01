app.controller('OrderController', function ($scope, $http, $filter, DTOptionsBuilder, $compile) {
    $scope.dtOption = DTOptionsBuilder.newOptions()
     .withDisplayLength(10)
     .withOption('bLengthChange', false);
    //get data
    $scope.tables = [];
    $scope.table = {};
    $scope.orders = [];
    $scope.order = {};
    $scope.orderdetail = {};
    $scope.employees = [];
    $scope.cashiers = [];
    $scope.cashier = {};
    $scope.servants = [];
    $scope.servant = {};
    $scope.products = [];
    $scope.product = {};
    $scope.id2 = 0;
    $http.get('http://localhost:1523/api/Table/').then(function (res) {
        $scope.tables = res.data;
    });
    $http.get('http://localhost:1523/api/Product/').then(function (res) {
        $scope.products = res.data;
    });
    $http.get('http://localhost:1523/api/Employee/').then(function (res) {
        $scope.employees = res.data;
    });
    var vm = this;
    vm.Total = 0;
    $scope.itemTotal = 0;
    $scope.showModal = function (id) {
        jQuery(function () {
            $scope.orderdetails = [];
            $scope.tableid = id;

            $scope.table = $filter('filter')($scope.tables, { TableID: parseInt(id) }, true)[0];
            $scope.Name = $scope.table.Area;
            $scope.Status = "Chưa thanh toán";
            $scope.servants = $filter('filter')($scope.employees, { TypeName: "Phục Vụ" });
            $scope.cashiers = $filter('filter')($scope.employees, { TypeName: "Thu ngân" });
            if ($scope.table.Status == false) {
                /*      $("#orderdetail tbody tr").each(function () {
                          this.parentNode.removeChild(this);
                      });*/

                $scope.table.Status = true;
                var params = {
                    "TableID": id,
                    "Area": $scope.table.Area,
                    "Status": $scope.table.Status,
                    "TotalPrice": $scope.table.TotalPrice
                };
                $http.put("http://localhost:1523/api/Table/" + $scope.id, params).then(function (res) {
                });

                //tao oerder dan chuyen sang ham ben suoi
                var params = {
                    "ExportDate": $scope.Date,
                    "TotalPrice": $scope.Price,
                    "Status": false,
                    "TableID": id,
                    "Type": "Xuất"
                };
                $http.post("http://localhost:1523/api/Order/", params).then(function (res) {
                    $scope.id = res.data.OrderID;
                    var param = {
                        "EmployeeID": $scope.servant.EmployeeID,
                        "OrderID": $scope.id,
                        "Type": "Servant"
                    };
                    $http.post("http://localhost:1523/api/Division/", param).then(function (res) {

                    });
                    var param1 = {
                        "EmployeeID": $scope.cashier.EmployeeID,
                        "OrderID": $scope.id,
                        "Type": "Cashier"

                    };
                    $http.post("http://localhost:1523/api/Division/", param1).then(function (res) {
                    });
                });

                $("#modalTitle").text("Create Order");
                $scope.servant = $scope.servants[0];
                $scope.cashier = $scope.cashiers[0];
                $scope.Date = new Date();
                $scope.Price = 0;
            } else {

                $("#modalTitle").text("Update Order");
                $http.get("http://localhost:1523/api/Order").then(function (res) {
                    $scope.orders = res.data;
                    $scope.order = $filter('filter')($scope.orders, { Status: false, TableID: parseInt(id) }, true)[0];
                    $scope.Date = $scope.order.ExportDate;
                    $scope.Price = $scope.order.TotalPrice;
                    $scope.id = $scope.order.OrderID;
                    $http.get('http://localhost:1523/api/OrderDetail/' + parseInt($scope.id)).then(function (res) {
                        $scope.orderdetails = res.data;
                        
                    });
                });
                $http.get("http://localhost:1523/api/Division/GetByOrder/" + $scope.id).then(function (res) {
                    $scope.divisions = res.data;
                    $scope.division = $filter('filter')($scope.divisions, { Type: "Servant" })[0];
                    $scope.servant = $filter('filter')($scope.employees, { EmployeeID: $scope.division.EmployeeID })[0];
                    $scope.division = $filter('filter')($scope.divisions, { Type: "Cashier" })[0];
                    $scope.cashier = $filter('filter')($scope.employees, { EmployeeID: $scope.division.EmployeeID })[0];
                });
            }
            $("#myModal").modal('show');
        });
    }
    $scope.createorder = function ()
    {
        $("#modalTitle").text("Create Order");
        
        $scope.Date = new Date();
        $scope.Price = 0;

        $scope.orderdetails = [];
        $scope.Status = "Chưa thanh toán";
        $scope.cashiers = $filter('filter')($scope.employees, { TypeName: "Thu ngân" });
        $scope.cashier = $scope.cashiers[0];

        var params = {
            "ExportDate": $scope.Date,
            "TotalPrice": $scope.Price, 
            "Status": false,
            "TableID": "",
            "Type": "Xuất"
        };
        $http.post("http://localhost:1523/api/Order/", params).then(function (res) {
            $scope.id = res.data.OrderID;
            alert("da tao order" + $scope.id);
            var param1 = {
                "EmployeeID": $scope.cashier.EmployeeID,
                "OrderID": $scope.id,
                "Type": "Cashier"

            };
            $http.post("http://localhost:1523/api/Division/", param1).then(function (res) {
            });
        });
        $("#myModal2").modal('show');
    }
   
    $scope.saveData = function () {
        var params = {
            "OrderID": $scope.id,
            "ExportDate": $scope.Date,
            "TotalPrice": $scope.Price,
            "Status": true,
            "TableID": $scope.tableid,
            "Type": "Xuất"
        };
        $http.put("http://localhost:1523/api/Order/" + $scope.id, params).then(function (res) {
            $scope.id = res.data.OrderID;
            var param = {
                "EmployeeID": $scope.servant.EmployeeID,
                "OrderID": $scope.id,
                "Type": "Servant"
            };
            $http.post("http://localhost:1523/api/Division/", param).then(function (res) {

            });
            var param1 = {
                "EmployeeID": $scope.cashier.EmployeeID,
                "OrderID": $scope.id,
                "Type": "Cashier"
            };
            $http.post("http://localhost:1523/api/Division/", param1).then(function (res) {
            });
        });
    }
    $scope.cancelOrder = function (i) {
        if (i == 0) {
            $scope.table.Status = false;
            var params = {
                "TableID": $scope.tableid,
                "Area": $scope.table.Area,
                "Status": $scope.table.Status,
                "TotalPrice": $scope.table.TotalPrice
            };
            $http.put("http://localhost:1523/api/Table/" + $scope.id, params).then(function (res) {
                $http.delete('http://localhost:1523/api/OrderDetail/' + $scope.id + '/' + 1)
                $http.delete('http://localhost:1523/api/division/' + $scope.id + '/' + 1);
                $http.delete('http://localhost:1523/api/order/' + $scope.id);
                alert("Da xoa order :" + $scope.id);
            });
        }
        else {
            $http.delete('http://localhost:1523/api/OrderDetail/' + $scope.id + '/' + 1)
            $http.delete('http://localhost:1523/api/division/' + $scope.id + '/' + 1);
            $http.delete('http://localhost:1523/api/order/' + $scope.id);
            alert("Da xoa order :" + $scope.id);
        }
    $('#myModal').modal('hide');
}
$scope.add = function (id) {
    $http.get('http://localhost:1523/api/OrderDetail/' + $scope.id).then(function (res) {
        $scope.orderdetails = res.data;
    });
    $scope.orderdetail = $filter('filter')($scope.orderdetails, { ProductID: id })[0];

    if ($scope.orderdetail == null) {
        $scope.product = $filter('filter')($scope.products, { ProductID: id }, true)[0];
        var params = {
            "ProductID": id,
            "OrderID": $scope.id,
            "Number": 1,
            "Prices": $scope.product.Prices

        };
        $http.post("http://localhost:1523/api/OrderDetail/", params).then(function (res) {
            $http.get('http://localhost:1523/api/OrderDetail/' + $scope.id).then(function (res) {
                $scope.orderdetails = res.data;
            });
        });

    }
    else {
        var params = {
            "ProductID": id,
            "Number": $scope.orderdetail.Number + 1,
            "OrderID": $scope.id,
            "Prices": $scope.orderdetail.Prices,
            "OrderDetailID": $scope.orderdetail.OrderDetailID
        };
        $http.put("http://localhost:1523/api/OrderDetail/", params).then(function (res) {
            $http.get('http://localhost:1523/api/OrderDetail/' + $scope.id).then(function (res) {
                $scope.orderdetails = res.data;
            });
        });
    }
}
$scope.change = function (id, num) {
    if ((typeof num != "number") || num <= 0) num = 1;
    $http.get('http://localhost:1523/api/OrderDetail/getbyid/' + id).then(function (res) {
        $scope.orderdetail = res.data;
        var params = {
            "ProductID": $scope.orderdetail.ProductID,
            "OrderID": $scope.orderdetail.OrderID,
            "Number": num,
            "Prices": $scope.orderdetail.Prices,
            "OrderDetailID": id
        };
        $http.put("http://localhost:1523/api/OrderDetail/", params).then(function (res) {
            $http.get('http://localhost:1523/api/OrderDetail/' + $scope.id).then(function (res) {
                $scope.orderdetails = res.data;
            });
        });
    });


}
$scope.delete = function (id) {
    $http.delete("http://localhost:1523/api/OrderDetail/" + id).then(function (res) {
        $http.get('http://localhost:1523/api/OrderDetail/' + $scope.id).then(function (res) {
            $scope.orderdetails = res.data;
        });
    });

}
$scope.updateservant = function (id) {
    $http.get("http://localhost:1523/api/Division/getbyorder/" + $scope.id).then(function (res) {
        $scope.divisions = res.data;
        $scope.division = $filter('filter')($scope.divisions, { Type: "Servant" })[0];
        $http.delete("http://localhost:1523/api/Division/" + $scope.division.EmployeeID + "/" + $scope.id).then(function (res) {
        });
    });
    //     alert()
    params = {
        "EmployeeID": id,
        "OrderID": $scope.id,
        "Type": "Servant"

    };
    $http.post("http://localhost:1523/api/Division/", params).then(function (res) {
    });

}
$scope.updatecashier = function (id) {
    $http.get("http://localhost:1523/api/Division/getbyorder/" + $scope.id).then(function (res) {
        $scope.divisions = res.data;
        $scope.division = $filter('filter')($scope.divisions, { Type: "Cashier" })[0];
        $http.delete("http://localhost:1523/api/Division/" + $scope.id).then(function (res) {
        });
    });
    params = {
        "EmployeeID": id,
        "OrderID": $scope.id,
        "Type": "Cashier"

    };
    $http.post("http://localhost:1523/api/Division/", params).then(function (res) {
    });

}


});

