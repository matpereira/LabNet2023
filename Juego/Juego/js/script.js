let numeroAleatorio = generarNumeroAleatorio();
let maximo = 10;
let puntos = 10;
let puntajeMaximo = 0;
let nivelDificultad = 1;
let puntajeMaximoPartida = 0;


const puntosElement = document.getElementById("puntos");
const puntajeMaximoElement = document.getElementById("puntajeMaximo");
const entradaNumero = document.getElementById("entradaNumero");
const botonAdivinar = document.getElementById("botonAdivinar");
const botonReiniciar = document.getElementById("botonReiniciar");
const valorMaximoElement = document.getElementById("valorMaximo");
const mensaje = document.getElementById("mensaje");
const comenzarJuegoButton = document.getElementById('botonStart');
const adivinarButton = document.getElementById('botonAdivinar');
const reiniciarJuegoButton = document.getElementById('botonReiniciar');
const juegoStartDiv = document.getElementById('Juego-Start');
juegoStartDiv.style.display = 'none';
reiniciarJuegoButton.style.display = 'none';
adivinarButton.style.display = 'none';


comenzarJuegoButton.addEventListener('click', function() {
    // Oculta el botón "Empezar Juego"
    comenzarJuegoButton.style.display = 'none';
    juegoStartDiv.style.display = 'inline-block';

    // Muestra los otros dos botones
    reiniciarJuegoButton.style.display = 'inline-block';
    adivinarButton.style.display = 'inline-block';
    reiniciarJuego();
});


function reiniciarJuego() {
    puntos = 10;
    maximo = 10;
    valorMaximoElement.textContent = maximo;
    entradaNumero.setAttribute("max", maximo);
    puntajeMaximoPartida = 0;
    nivelDificultad = 1;
    numeroAleatorio = generarNumeroAleatorio();
    actualizarDificultad();
    actualizarPuntaje();
    mensaje.textContent = "";
    entradaNumero.value = "";
}


botonAdivinar.addEventListener("click", function () {
    const numeroIngresado = parseInt(entradaNumero.value);
    
    if (numeroIngresado < 1 || numeroIngresado > maximo || isNaN(numeroIngresado)) {
        mensaje.textContent = "El número ingresado debe estar entre 1 y " + maximo;
        return; // Salir de la función sin contar como un intento
    }

    if (numeroIngresado === numeroAleatorio) {
        proximoNivel();
    } else {
        if (numeroIngresado < numeroAleatorio) {
            mensaje.textContent = "El número es mayor.";
        } else {
            mensaje.textContent = "El número es menor.";
        }
        puntos -= nivelDificultad;
        if (puntos < 0) {
            perdiste();
        }
    }
    actualizarPuntaje();
});


function actualizarPuntaje() {
    puntosElement.textContent = puntos;
    puntajeMaximoElement.textContent = puntajeMaximo;
}

function actualizarDificultad() {
    maximo = nivelDificultad * 10;
    valorMaximoElement.textContent = maximo;
    entradaNumero.setAttribute("max", maximo);
}



function generarNumeroAleatorio() {
    let maximo = 10;
    return Math.floor(Math.random() * maximo) + 1;
}

function proximoNivel() {
    nivelDificultad++; 
    mensaje.textContent = "Excelente, avanzas al sig nivel: Nivel " + nivelDificultad;
    numeroAleatorio = generarNumeroAleatorio();
    puntos += (nivelDificultad*2)+10;
    actualizarDificultad();

    if (puntos > puntajeMaximo) {
        puntajeMaximo = puntos;
    }

    if(puntos > puntajeMaximoPartida){
    puntajeMaximoPartida = puntos;
    }

}

function perdiste() {
            puntos = 0; 
            nivelDificultad = 1; 
            reiniciarJuego(); 
            mensaje.textContent = "Perdiste, el número era " + numeroAleatorio;
    }

botonReiniciar.addEventListener("click", reiniciarJuego);
