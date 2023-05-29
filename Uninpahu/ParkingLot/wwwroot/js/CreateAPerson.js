var form = document.getElementById('registration-form');

form.addEventListener('submit', function (e) {
    e.preventDefault();

    var name = document.getElementById('nameText');
    var email = document.getElementById('typeEmailX');
    var idNumber = document.getElementById('identificationNumber');
    var phone = document.getElementById('phoneNumber');
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
    )}
    );