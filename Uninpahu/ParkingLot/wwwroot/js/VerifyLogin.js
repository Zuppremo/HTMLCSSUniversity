
let button = document.getElementById("login-try");
let usernametextbox;
let userpassword;
let userdatabase;
let userpassworddatabase;


function updateUrl(){
  userpassword = document.getElementById('userpassword').value;
  //console.log(userpassword.value);
  url = `'https://localhost:7119/api/User/usercreds/'${usernametextbox.value}'`;
  return url;
}

let soMany = 10;
console.log(`This is ${soMany} times easier!`);

function getUserCredentials(){
  var username = document.getElementById('username').value;
  var password = document.getElementById('userpassword').value;
  const url = `'https://localhost:7119/api/User/usercreds/'${usernametextbox.value}'`;
  console.log(username);
  console.log(password);
  const result = await (fetch(url));
  result.json().then(data => {
      console.log(data);
  })
}