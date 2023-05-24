var form = document.getElementById('registration-form');

var id_person;

form.addEventListener('submit', function (e) {
    e.preventDefault();

    var name = document.getElementById('nameText');
    var email = document.getElementById('typeEmailX');
    var idNumber = document.getElementById('identificationNumber');
    var phone = document.getElementById('phoneNumber');
    var workingday = document.getElementById('workingday-dropdown');
    var motorbikebrand = document.getElementById('motorbikebrand-dropdown');
    var motorbike_plate = document.getElementById('motorbike-plate');
    var motorbikemodel = document.getElementById('motorbike-model');
    var username = document.getElementById('userName');
    var userpassword = document.getElementById('passwordUser');

    console.log(name.value);
    console.log(email.value);

    
    fetch('https://localhost:7119/api/Person', {
        method: 'POST',
        body:JSON.stringify({
            "Name": name.value,
            "Email": email.value,
            "Phone": phone.value,
            "IdentificationNumber": idNumber.value
        }), 
        headers:{
            'Content-Type': 'application/json; charset=UTF-8'
        }
    })
    .then(function (response){
        return response.json();
    })
    .then(function (data){ 
        console.log(data);
    } 
    )}).await();
    
    function postPerson(){

    }
    
    function postMotorbike(){

    }

    function postUser(){

    }




    fetch('https://localhost:7119/api/Motorbike', {
        method: 'POST',
        body:JSON.stringify({
            "Plate": motorbike_plate.value,
            "Model": motorbikemodel.value,
            "IdMotorbikeBrand": parseInt(motorbikebrand.value)
        }), 
        headers:{
            'Content-Type': 'application/json; charset=UTF-8'
        }
    })
    .then(function (response){
        return response.json();
    })
    .then(function (data){ 
        console.log(data);
    } 
    );

    fetch('https://localhost:7119/api/User/form', {
        method: 'POST',
        body:JSON.stringify({
            "UserWorkingDay": workingday.value,
            "UserName": username.value,
            "UserPassword": userpassword.value,
            "UserHasAccess": 0
        }), 
        headers:{
            'Content-Type': 'application/json; charset=UTF-8'
        }
    })
    .then(function (response){
        return response.json();
    })
    .then(function (data){ 
        console.log(data);
    } );
