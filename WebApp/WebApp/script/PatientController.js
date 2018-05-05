app.controller('PatientController', function ($scope, $http, $filter, DTOptionsBuilder, $compile) {
    $scope.dtOption = DTOptionsBuilder.newOptions()
        .withDisplayLength(10)
        .withOption('bLengthChange', false);
    //define 
    $scope.patients = [];
    $scope.patient = {};

    //get data
    $http.get('http://localhost:6500/Service1.svc/getAllPatients/').then(function (res) {
        $scope.patients = res.data;
    });

    //show modal
    $scope.showModal = function (id) {
        $scope.id = id;
        if (id == 0) {
            $("#modalTitle").text("New Patient");
            $("#btnAddAction").text("Add");

            $scope.IdentifyCard = "";
            $scope.FirstName = "";
            $scope.LastName = "";
            $scope.MiddleName = "";
            $scope.Gender = 'Male';
            $scope.Phone = "";
            $scope.Address = "";

        } else {
            $("#modalTitle").text("Edit Patient");
            $("#btnAddAction").text("Update");

            //find selected item
            $http.get('http://localhost:6500/Service1.svc/getPatient?id=' + id).then(function (res) {
                $scope.patient = res.data;
                $scope.IdentifyCard = $scope.patient.IdentifyCard;
                $scope.FirstName = $scope.patient.FirstName;
                $scope.MiddleName = $scope.patient.MiddleName;
                $scope.LastName = $scope.patient.LastName;
                $scope.Gender = $scope.patient.Gender?'Male':'Female';
                $scope.Phone = $scope.patient.Phone;
                $scope.Address = $scope.patient.Address;
            });
        }
        $("#PatientModal").modal('show');
    };

    //save 
    $scope.saveData = function () {
        if ($scope.id == 0) {
            var params = {
                'IdentifyCard' : $scope.IdentifyCard,
                'FirstName' : $scope.FirstName,
                'MiddleName' : $scope.MiddleName,
                'LastName' : $scope.LastName,
                'Gender' : $scope.Gender == 'Male' ? true : false,
                'Phone' : $scope.Phone,
                'Address' : $scope.Address
            };

           $http.post("http://localhost:6500/Service1.svc/Patients/new", params).then(function (res) {
                window.location.reload();
            });
        }
        else {
            var params = {
                'PatientID' : $scope.id,
                'IdentifyCard': $scope.IdentifyCard,
                'FirstName': $scope.FirstName,
                'MiddleName': $scope.MiddleName,
                'LastName': $scope.LastName,
                'Gender': $scope.Gender == 'Male' ? true : false,
                'Phone': $scope.Phone,
                'Address': $scope.Address
            };
            
            $http.put("http://localhost:6500/Service1.svc/Patients/edit", params).then(function (res) {
                window.location.reload();
            });
        }
        
    }

    //Get number
    $scope.getNumber = function (id) {
        $http.post("http://localhost:6500/Service1.svc/PatientOfDays/new", id).then(function (res) {
            $scope.Number = res.data.Number;
            $scope.Room = res.data.Room;
            $("#MessageBox").modal('show');
        });
    };

    //OK
    $scope.OK = function () {
        window.location.reload();
    };
});

