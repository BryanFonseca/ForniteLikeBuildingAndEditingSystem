using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Edit
{
    public string nombre;
    public Mesh modelo;

    public Edit(string nombre)
    {
        this.nombre = nombre;
    }
}
