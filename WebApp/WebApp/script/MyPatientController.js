app.controller('MyPatientController', function ($scope, $http, $filter, DTOptionsBuilder, $compile) {
    $scope.dtOption = DTOptionsBuilder.newOptions()
        .withDisplayLength(10)
        .withOption('bLengthChange', false);
    //define 
    $scope.patients = [];
    $scope.patient = {};
    $scope.drugs = [];
    $scope.prescriptionDetails = [];
    $scope.examinationResults = [];

    var cookie = document.cookie;
    var doctorId = cookie.split('=').pop();
    //get data
    $http.get('http://localhost:6500/Service1.svc/getPatientOfDaysByDoctorID?id='+doctorId).then(function (res) {
        $scope.patients = res.data;
        console.log($scope.patients);
    });
    $http.get('http://localhost:6500/Service1.svc/getAllDrugs/').then(function (res) {
        $scope.drugs = res.data;
    });
    //show modal
    $scope.showModal = function (id) {
        $scope.PatientID = id;
            //find selected item
            $http.get('http://localhost:6500/Service1.svc/getPatient?id=' + id).then(function (res) {
                $scope.patient = res.data;
                $scope.IdentifyCard = $scope.patient.IdentifyCard;
                $scope.FirstName = $scope.patient.FirstName;
                $scope.MiddleName = $scope.patient.MiddleName;
                $scope.LastName = $scope.patient.LastName;
                $scope.Gender = $scope.patient.Gender ? 'Male' : 'Female';
                $scope.Phone = $scope.patient.Phone;
                $scope.Address = $scope.patient.Address;

                $http.get('http://localhost:6500/Service1.svc/getAllExaminationResultsByPatient?id=' + id).then(function (res) {
                    $scope.examinationResults = res.data;

                });    
        });
            $scope.prescriptionDetails = [{ 'DrugID': $scope.drugs[0], 'Quantity': 1, 'Day': 1, 'Description': '', 'Dosage':'', 'Usage': ''}];
            $("#PrescriptionModal").modal('show');
    };

    $scope.addNewPrescription = function () {
        $scope.prescriptionDetails.push({ 'DrugID': $scope.drugs[0], 'Quantity': 1, 'Day': 1, 'Description': '', 'Dosage': '', 'Usage': '' });
    };

    $scope.removePrescription = function (index) {
        $scope.prescriptionDetails.splice(index, 1);
    };

    //save 
    $scope.saveData = function () {
        var ExaminationResult = {
            'Result': $scope.Result,
            'Description': $scope.Description,
            'DoctorID': doctorId,
            'PatientID': $scope.PatientID
        };
        var PrescriptionDetails = [];
        
        console.log(PrescriptionDetails);
        $http.post("http://localhost:6500/Service1.svc/ExaminationResults/new", ExaminationResult).then(function (res) {
            angular.forEach($scope.prescriptionDetails, function (value, key) {
                var PrescriptionDetail = {
                    'ExaminationResultID': res.data,
                    'DrugID': value.DrugID.DrugID,
                    'Quantity': value.Quantity,
                    'Day': value.Day,
                    'Description': value.Description,
                    'Dosage': value.Dosage,
                    'Usage': value.Usage
                };
                PrescriptionDetails.push(PrescriptionDetail);
            });
            $http.post("http://localhost:6500/Service1.svc/PrescriptionDetails/new", PrescriptionDetails).then(function (res) {
                window.location.reload();
            });
        });
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

