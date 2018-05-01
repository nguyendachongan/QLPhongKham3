
var app = angular.module("MyApp", ["ngRoute", 'datatables']).directive('ngFiles', ['$parse', function ($parse) {
    function fn_link(scope, element, attrs) {
        var onChange = $parse(attrs.ngFiles);

        element.on('change', function (event) {
            onChange(scope, { $files: event.target.files });

        });
    }

    return {
        link: fn_link
    }
}]);

app.config(function ($routeProvider) {
    $routeProvider
        .when("/order", {
            templateUrl: "../../View/Order/index.html"
        })
        .when("/table", {
            templateUrl: "../../View/Table/index.html"
        })
        .when("/typeemployee", {
            templateUrl: "../../View/TypeEmployee/index.html"
        })
        .when("/product", {
            templateUrl: "../../View/Product/index.html"
        })
       /* .when("/employee", {
            templateUrl: "../../View/Drugs/index.html"
        })*/
        .when("/drugs", {
            templateUrl: "../../View/Drugs/index.html"
        });
});