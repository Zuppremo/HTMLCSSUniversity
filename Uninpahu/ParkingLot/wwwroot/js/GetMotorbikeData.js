const idmotorbike = 1;
const urlmotorbike = `https://localhost:7119/api/Motorbike/${idmotorbike}`;

fetch(urlmotorbike)
    .then(res=> {
        return res.json();
    })
    .then(data => {
        console.log(data);
        JSON.stringify(data);
        console.log(data);
        document.getElementById('plate').innerHTML = data[0].motorbike_plate;
        document.getElementById('model').innerHTML = data[0].motorbike_model;
    })
    .catch(error => console.log(error));