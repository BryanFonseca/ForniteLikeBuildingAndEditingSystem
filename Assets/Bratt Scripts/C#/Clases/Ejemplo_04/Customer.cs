using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Customer
{
    public string Nombre;
    public string Apellido;
    public string Genero;
    public string Ocupacion;
    public int Edad;
   

    public Customer()
    { }

    public Customer(string Nombre, string Apellido, string Genero, string Ocupacion, int Edad)
    {
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.Genero = Genero;
        this.Ocupacion = Ocupacion;
        this.Edad = Edad;
    }
}
