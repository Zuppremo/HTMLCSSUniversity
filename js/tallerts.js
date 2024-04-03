var numberOne = 0;
var numberTwo = 0;
var result = 0;
var fibonacciLimit;
var factorialLimit = 0;

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

function factorialNumber() {
    factorialLimit = parseInt(document.getElementById("factorialLimit").value);
    result = 1;
    for (let i = 1; i <= factorialLimit; i++){
        result *= i;
        showResult();
    }
}

function pair()
{
    let pairNumber = document.getElementById("pairNumber").value;
    if (pairNumber % 2 == 0)
        document.getElementById("isPairNumber").innerHTML = "El numero ingresado es par";
    else
        document.getElementById("isPairNumber").innerHTML = "El numero ingresado no es par";
}
