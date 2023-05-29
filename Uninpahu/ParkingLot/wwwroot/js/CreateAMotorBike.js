var form = document.getElementById('registration-form');

var id_person;

form.addEventListener('submit', function (e) {
    e.preventDefault();

    var motorbikebrand = document.getElementById('motorbikebrand-dropdown');
    var motorbike_plate = document.getElementById('motorbike-plate');
    var motorbikemodel = document.getElementById('motorbike-model');
    
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
    });
});