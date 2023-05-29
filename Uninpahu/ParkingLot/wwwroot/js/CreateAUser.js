var form = document.getElementById('registration-form');

var id_person;

form.addEventListener('submit', function (e) {
    e.preventDefault();

    var workingday = document.getElementById('workingday-dropdown');
    var username = document.getElementById('userName');
    var userpassword = document.getElementById('passwordUser');
    
    userAdd = fetch('https://localhost:7119/api/User/form', {
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
    });

});
