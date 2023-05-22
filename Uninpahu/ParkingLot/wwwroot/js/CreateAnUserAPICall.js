const url = "https://localhost:7119/api/Motorbikebrand";

async function MakeAPICall() {
    const result = await (fetch(url));
    result.json().then(data => {
        console.log(data);
    })
}

//MakeAPICall();