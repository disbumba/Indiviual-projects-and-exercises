// Declarare cu let
let nume = "Ana";
nume = "Maria"; // OK, se poate schimba

// Declarare cu const
const varsta = 25;
// varsta = 26; // Eroare: nu se poate schimba

// Declarare cu var (nu recomandat)
var oras = "București";
oras = "Cluj"; // OK, dar scope global
// Funcție declarată
function salut(nume) {
    return "Salut, " + nume + "!";
}

// Funcție expresie
const aduna = function(a, b) {
    return a + b;
};

// Funcție săgeată
const inmulteste = (a, b) => a * b;

// Apelarea funcțiilor
console.log(salut("Ana")); // Salut, Ana!
console.log(aduna(2, 3)); // 5
console.log(inmulteste(4, 5)); // 20