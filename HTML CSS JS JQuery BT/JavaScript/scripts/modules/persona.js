export class Persona{
    constructor(nombre,apellido,edad){
        this.nombre = nombre;
        this.apellido = apellido;
        this.edad = edad;
    }
}
export class Alumno extends Persona{ //con extends, estos diciendo que Alumno hereda de persona
    constructor(nombre,apellido,edad,legajo){
        super(nombre,apellido,edad); //esto vendria a ser como el :base en c# , que hereda del padre
        this.legajo = legajo;
    }
}
export class Perro{ //con extends, estos diciendo que Alumno hereda de persona
        constructor(nombre){
        this.nombre = nombre;
    }
}