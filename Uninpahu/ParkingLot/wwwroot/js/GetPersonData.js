const id = 1;
const url = `https://localhost:7119/api/Person/${id}`;

fetch(url)
    .then(res=> {
        return res.json();
    })
    .then(data => {
        console.log(data);
        JSON.stringify(data);
        console.log(data);
        document.getElementById('name').innerHTML = data[0].person_name;
        document.getElementById('email').innerHTML = data[0].person_email;
        document.getElementById('identification-number').innerHTML = data[0].person_IDNumber;
        document.getElementById('phone').innerHTML = data[0].person_PhoneNumber;
    })
    .catch(error => console.log(error));
