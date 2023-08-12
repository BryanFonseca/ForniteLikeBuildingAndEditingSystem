using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JugadorSerializable
{
    //Puntos de vector3
    public float x;
    public float y;
    public float z;

    public JugadorSerializable(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}
