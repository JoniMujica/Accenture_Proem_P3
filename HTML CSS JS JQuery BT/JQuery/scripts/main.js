const elemento = $("#contenedor");
const elemento2 = document.querySelector("#contenedor2");
console.log(elemento2);
console.log(elemento);
elemento2.innerHTML ="<h1>Hola mundo desde JS puro</h1>"
elemento.append("<h1>Hola mundo desde JQuery</h1>");
//en realidad se hace...:

const h = document.createElement("h1");
h.textContent ="Hola 2";
elemento2.appendChild(h);