using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditDatabase : MonoBehaviour
{
    private static EditDatabase _instance;
    public static EditDatabase Instance 
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Base de datos de edits NULL");

            return _instance;
        }
    }   

    public Edit[] EdicionesPared = new Edit[10];


    private void Awake()
    {
        _instance = this;
    }

    public Mesh DarObjeto(string nombre)
    {
        for (int i = 0; i < EdicionesPared.Length; i++)
        {
            if (EdicionesPared[i].nombre == nombre)
                return EdicionesPared[i].modelo;            
        }
        Debug.Log("Se ha retornado null");
        return null;
    }
}
