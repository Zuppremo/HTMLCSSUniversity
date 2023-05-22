const idbrand = 1;
const urlmotorbikebrand = `https://localhost:7119/api/Motorbikebrand/${idbrand}`;

fetch(urlmotorbikebrand)
    .then(res=> {
        return res.json();
    })
    .then(data => {
        console.log(data);
        JSON.stringify(data);
        console.log(data);
        document.getElementById('brand').innerHTML = data[0].motorbikebrand_name;
    })
    .catch(error => console.log(error));