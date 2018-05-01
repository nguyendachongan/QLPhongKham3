app.controller('ProductController', function ($scope, $http, $filter, DTOptionsBuilder) {

    //up file 
    var formdata = new FormData();
    $scope.getTheFiles = function ($files) {
        $scope.imagesrc = [];

        for (var i = 0; i < $files.length; i++) {
            var reader = new FileReader();
        }
    };



    $scope.dtOption = DTOptionsBuilder.newOptions()
     .withDisplayLength(10)
     .withOption('bLengthChange', false);
    //get data
    $scope.products = [];
    $scope.areas = [];
    $scope.product = {};
    $scope.Photo = {};
    $scope.Photo.src = "";
    $http.get('http://localhost:1523/api/Product/').then(function (res) {
        $scope.products = res.data;
    });
    $http.get('http://localhost:1523/api/Area/').then(function (res) {
        $scope.areas = res.data;
    });

    //add and update
    $scope.saveData = function () {
        // $scope.type.NameOfType = $scope.typeName;
        // if ($scope.type.TypeID == 0) {
        if($scope.id==0){
        var params = {
            //"Name": $scope.typeName
        "Name" : $scope.Name,
      //  "Photo" : $scope.Photo,
        "Unit" : $scope.Unit,
        "Prices" : $scope.Prices,
        "ExportPrice" : $scope.ExportPrice,
        "AreaID" : $scope.AreaID.AreaID
        };

        $http.post("http://localhost:1523/api/Product", params).then(function (res) {
            window.location.reload();
        });
        }
       else {
            var params = {
              //  "typeid": $scope.type.typeid,
                //  "typename": $scope.typename
                "ProductID":$scope.id,
                "Name": $scope.Name,
                //  "Photo" : $scope.Photo,
                "Unit": $scope.Unit,
                "Prices": $scope.Prices,
                "ExportPrice": $scope.ExportPrice,
                "AreaID": $scope.AreaID.AreaID
            };
            $http.put("http://localhost:1523/api/Product/" + $scope.id, params).then(function (res) {
                window.location.reload();
                //find selected item
                // $scope.type = $filter('filter')($scope.types, { typeid: parseint(id) }, true)[0];
                // $scope.type.name = $scope.typename;
            });
        }

    }
    $scope.delete = function (id) {
        $http.delete("http://localhost:1523/api/Product/"+id).then(function (res) {
            window.location.reload();
        });
    }
    //show modal
    $scope.showModal = function (id) {
        jQuery(function () {
            if (id == 0) {
                $("#modalTitle").text("New Product");
                $("#btnAddAction").text("Add");
                $scope.id = 0;
                $scope.Name ="";
                $scope.Photo = "";
                $scope.Unit = "";
                $scope.Prices = "";
                $scope.ExportPrice = "";
                $scope.AreaID = $scope.areas[0];
            } else {
                //    alert(id);
                
                $("#modalTitle").text("Edit Type");
                $("#btnAddAction").text("Update");

                //find selected item
                $scope.product = $filter('filter')($scope.products, { ProductID: id }, true)[0];
                $scope.id = $scope.product.ProductID;
                $scope.Name = $scope.product.Name;
                $scope.Photo = $scope.product.Photo;
                $scope.Unit = $scope.product.Unit;
                $scope.Prices = $scope.product.Prices;
                $scope.ExportPrice = $scope.product.ExportPrice;
          //      $scope.AreaID = $scope.product.AreaID;
                $scope.AreaID = $filter('filter')($scope.areas, { AreaID: $scope.product.AreaID }, true)[0];
              
             //   $scope.typeName = $scope.type.NameOfType;
            }
            $("#myModal").modal('show');
        });
    }
 
    $scope.confirm = function (id) {
        jQuery(function () {
            
                //find selected item
                $scope.product = $filter('filter')($scope.products, { ProductID: id }, true)[0];
                $scope.id = $scope.product.ProductID;
                $scope.Name = $scope.product.Name;
                $scope.Photo = $scope.product.Photo;
                $scope.Unit = $scope.product.Unit;
                $scope.Prices = $scope.product.Prices;
                $scope.ExportPrice = $scope.product.ExportPrice;
                $scope.Area = $scope.product.Area;
                //   $scope.typeName = $scope.type.NameOfType;
            
            $("#mymodal").modal('show');
        });
    }
});