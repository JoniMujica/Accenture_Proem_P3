/*import { Persona } from "./modules/persona.js";
import { Alumno } from "./modules/persona.js";
import { Perro } from "./modules/persona.js";




const p = new Persona("Jose","Colmenares",40);
console.log(p);



const a = new Alumno("Jose","Colmenares",40,1111);
console.log(a);


p.saludar = () => {
    console.log(`soy ${p.apellido}`)
}

p.saludar();

console.log(p instanceof Persona); //verifica si p es una instancia de Persona  => true
console.log(a instanceof Persona); //verifica si p es una instancia de Persona => true
console.log(p instanceof Perro); //verifica si p es una instancia de Persona => false


let {nombre,apellido,edad} = {...p}; //aca guarda las propiedades de P en las variables de las {} en orden definido en el objeto
console.log(nombre);
console.log(apellido);
console.log(edad);*/

import { Persona } from "./modules/persona.js";


const dialogo = document.getElementById("dialogo");
const btnOpenForm = document.querySelector("#openForm");
const btnCerrarForm = document.querySelector("#btnCerrar");
btnOpenForm.addEventListener("click",handleOpenForm);
btnCerrarForm.addEventListener("click",function(){
    dialogo.removeAttribute("open");
})  ;

function handleOpenForm(){
    dialogo.setAttribute("open","true");
}

document.getElementById("articuloModificado").classList.add("cambiarColorArticulo");



/*

Saludar();


 function Saludar(){
     return new Promise((res)=>{
        setTimeout(()=>{
            res(console.log("Como estas?"));
        },5000);
    });
}

async function ejecutarlo(){
    console.log("Hola");
    await Saludar();
    console.log("Chau");

}
*/















//pegar a una API
//GET
fetch("https://uncovered-satisfying-kale.glitch.me/api/personas") //referimos a la API
.then(res=>res.ok ? res.json() : Promise.reject({error: "Error"})) //con esto verifico que si la solicitud es OK, si es asi, recibo un JSON, sino devuelvo un error de la promesa
//.then(data=> console.log(data));
.then(data=> {
    if (data.status == "ok") {
        console.log("respuesta server OK");
        console.log(data.data);
    }
});




const formulario = document.getElementById("formulario");
const btnEnviar = document.getElementById("btnEnviar");
btnEnviar.addEventListener("click",()=>{
    const persona = 
    {
        nombre: formulario.nombre.value,
        apellido:formulario.apellido.value,
        sexo :formulario.sexo.value,
    };
    console.log(persona);
    
    //POST
    fetch("https://uncovered-satisfying-kale.glitch.me/api/personas", //para hacer post a una API, necesito la URL de la app y un parametro objeto la cual indicara metodo,body
    {
        method:"POST",
        body:JSON.stringify(persona),
        headers:{"Content-Type": "application/json; charset=utf-8"}
    }    
    )
    .then(res=> res.ok ?  res.json() : Promise.reject({error : "Error"}))
    .then(data=> console.log(data));
});