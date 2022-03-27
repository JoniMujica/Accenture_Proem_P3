
console.log("Hoal");
var Lbody = document.getElementById("Loaded");
const dialogo = document.getElementsByClassName("dialogo");
//const btnOpenForm = document.querySelector("#openForm");
const btnOpenForm = document.getElementsByClassName("openForm");
//const btnCerrarForm = document.querySelector("#btnCerrar");
const btnCerrarForm = document.getElementsByClassName("btnCerrar");
/*
btnOpenForm.addEventListener("click", handleOpenForm);
btnCerrarForm.addEventListener("click", function () {
    dialogo.removeAttribute("open");
});

function handleOpenForm() {
    dialogo.setAttribute("open", "true");
}*/

function cargarModal() {
    for (var i = 0; i < btnOpenForm.length; i++) {
        var currD;
        (function (_i) {
            btnOpenForm[_i].addEventListener('click', function () {
                dialogo[_i].setAttribute("open", "true");

            });

            btnCerrarForm[_i].addEventListener('click', function () {
                dialogo[_i].removeAttribute("open");
                console.log("clicked");
            })
        })(i);

    }

   
}
/*
function cargarModalC() {
    for (var i = 0; i < btnCerrarForm.length; i++) {
        var currD;
        (function (_i) {
            btnCerrarForm[_i].addEventListener('click', function () {
                dialogo.setAttribute("open", "true");
            });
        })(i);

    }
}*/

Lbody.addEventListener('load', cargarModal());
//Lbody.addEventListener('load', cargarModalC());