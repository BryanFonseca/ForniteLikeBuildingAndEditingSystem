using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SSManager : MonoBehaviour
{
    private static SSManager _instance;
    public static SSManager Instance
    {
        get 
        {
            if (_instance == null)
                Debug.LogError("No hay sistema de guardado");

            return _instance;
        }
    }

    public delegate void Guardar();
    public delegate void Cargar();

    public static event Guardar guardar;
    public static event Cargar cargar;

    BinaryFormatter formateador;
    Stream stream;

    public Vector3 posicionGuardada;

    private void Awake()
    {
        _instance = this;
    }

    public void BotonGuardar()
    {
        if(guardar != null)
            guardar();

        //serialización

        float x = posicionGuardada.x;
        float y = posicionGuardada.y;
        float z = posicionGuardada.z;

        JugadorSerializable js = new JugadorSerializable(x, y, z);

        Debug.Log("Serializando...");

        formateador = new BinaryFormatter();
        stream = new FileStream("SaveData.game", FileMode.Create, FileAccess.Write, FileShare.None);

        formateador.Serialize(stream, js);

        stream.Close();
    }

    public void BotonCargar()
    {
        Debug.Log("Deserializando...");

        //deserializar

        formateador = new BinaryFormatter();

        stream = new FileStream("SaveData.game", FileMode.Open, FileAccess.Read, FileShare.None);
        JugadorSerializable deserializado = (JugadorSerializable)formateador.Deserialize(stream);

        float xC = deserializado.x;
        float yC = deserializado.y;
        float zC = deserializado.z;

        posicionGuardada = new Vector3(xC, yC, zC);

        stream.Close();

        if (cargar != null)
            cargar();
    }
}
