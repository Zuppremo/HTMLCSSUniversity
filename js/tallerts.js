var numberOne = 0;
var numberTwo = 0;
var result = 0;
var fibonacciLimit;

function getValues(){
    numberOne = parseFloat(document.getElementById("numberOne").value);
    numberTwo = parseFloat(document.getElementById("numberTwo").value);
}

function showResult(){
    document.getElementById("result").innerHTML = "El resultado de la operacion es: " + result;
}

function sum() {
    getValues();
    result = numberOne + numberTwo;
    showResult();
}

function substraction() {
    getValues();
    result = numberOne - numberTwo;
    showResult();
}

function multiply(){
    getValues();
    result = numberOne * numberTwo;
    showResult();
}

function divide() {
    getValues();
    if(numberTwo == 0)
        document.getElementById("result").innerHTML = "La division por 0 no se puede realizar";
    else {
        getValues();
        result = numberOne / numberTwo;
        showResult();
    }
}

function module(){
    getValues();
    result = numberOne % numberTwo;
    showResult();
}

function fibonacci(){
    fibonacciLimit = parseInt(document.getElementById("fibonacciLimit").value);
    if(fibonacciLimit <= 0)
        document.getElementById("result").innerHTML = "El limite debe ser mayor a 0";
    else{
        let a = 0, b = 1, c;
        while (a <= fibonacciLimit) {
            c = a + b;
            a = b;
            b = c;
            result = a;
            document.getElementById("result").innerHTML += a + ",";
        }
    }
}

function factorial(n) {
    let result = 1;
    for (let i = 1; i <= n; i++) {
        result *= i;
    }
    console.log("El factorial es: ", result);
}

function pair(n) {
    if (n % 2 == 0)
        console.log(n, " es par");
    else
        console.log(n, " es impar");
}

function cousinNumbers(n) {
    for (let i = 1; i < n; i++) {
        if (i % i == 0 && i % 1 == 0)
            console.log(i, " es primo")
        else
            console.log(i, " no es primo")
    }
}