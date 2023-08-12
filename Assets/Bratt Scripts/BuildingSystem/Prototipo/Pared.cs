using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared : MonoBehaviour, IEditable 
{
    public Material materialPresionado, materialNoPresionado;
    public GameObject[] estructurasEdit = new GameObject[9];    
    public bool[] estructurasSeleccionadas = new bool[9];

    public bool siendoEditada;

    [HideInInspector]
    public Mesh ObjetoActual;

    //NoDefinida = Sin editar
    enum Ediciones{EsqInfIzq, EsqInfDer, EsqSupIzq, EsqSupDer, CuadroIzq, CuadroDer, UnTercio, DosTercios, TInvertida, NoDefinida }
    Ediciones edicionDibujada;

    private void Awake()
    {
        DeshabilitarEstructuras();
    }

    public void ConfirmarEdicion()
    {
        //Debug.Log("Confirmado");
        edicionDibujada = CalcularEdicion();
        AsignarModeloEdicion();
    }   

    public void HabilitarEstructuras()
    {
        //Temporal, es más eficiente deshabilitar solo el objeto padre (creo... )
        for (int i = 0; i < estructurasEdit.Length; i++)
        {
            estructurasEdit[i].SetActive(true);
        }
    }

    public void DeshabilitarEstructuras()
    {
        for (int i = 0; i < estructurasEdit.Length; i++)
        {
            estructurasEdit[i].SetActive(false);
        }
    }

    public void ReiniciarEdicion()
    {
        //print("Reiniciar");

        //Hacer falsos todos los bools que definen las ediciones

        for (int i = 0; i < estructurasSeleccionadas.Length; i++)
        {
            estructurasSeleccionadas[i] = false;
        }

        //Asignar materiales de no presionados a todos 
        for (int i = 0; i < estructurasEdit.Length; i++)
        {
            estructurasEdit[i].GetComponent<MeshRenderer>().material = materialNoPresionado;
        }
    }

    public void PresionarIndice(int indice)
    {
        if (indice < estructurasEdit.Length)
        {
            estructurasEdit[indice].GetComponent<MeshRenderer>().material = materialPresionado;
            estructurasSeleccionadas[indice] = true;
        }
    }

    public int ObjetoAIndice(GameObject objeto)
    {
        //GameObject temp = objeto as GameObject;
        int i;
        for (i = 0; i < estructurasEdit.Length; i++)
        {
            if (GameObject.ReferenceEquals(objeto, estructurasEdit[i]))
            {                
                break;
            }
        }
        return i;
    }

    private Ediciones CalcularEdicion()
    {
        //Esquinas
        if (estructurasSeleccionadas[3] && estructurasSeleccionadas[6] && estructurasSeleccionadas[7] &&
            (!estructurasSeleccionadas[0] && !estructurasSeleccionadas[4] && !estructurasSeleccionadas[8] &&
            !estructurasSeleccionadas[5] && !estructurasSeleccionadas[1] && !estructurasSeleccionadas[2]))
        {
            return Ediciones.EsqInfIzq;
        }
        else if (estructurasSeleccionadas[5] && estructurasSeleccionadas[7] && estructurasSeleccionadas[8] &&
            (!estructurasSeleccionadas[0] && !estructurasSeleccionadas[1] && !estructurasSeleccionadas[2] &&
            !estructurasSeleccionadas[3] && !estructurasSeleccionadas[4] && !estructurasSeleccionadas[6]))
        {
            return Ediciones.EsqInfDer;
        }
        else if (estructurasSeleccionadas[0] && estructurasSeleccionadas[1] && estructurasSeleccionadas[3] &&
            (!estructurasSeleccionadas[2] && !estructurasSeleccionadas[4] && !estructurasSeleccionadas[5] &&
            !estructurasSeleccionadas[6] && !estructurasSeleccionadas[7] && !estructurasSeleccionadas[8]))
        {
            return Ediciones.EsqSupIzq;
        }
        else if (estructurasSeleccionadas[1] && estructurasSeleccionadas[2] && estructurasSeleccionadas[5] &&
            (!estructurasSeleccionadas[0] && !estructurasSeleccionadas[4] && !estructurasSeleccionadas[8] &&
            !estructurasSeleccionadas[3] && !estructurasSeleccionadas[6] && !estructurasSeleccionadas[7]))
        {
            return Ediciones.EsqSupDer;
        }
        else if (estructurasSeleccionadas[0] && estructurasSeleccionadas[1] && estructurasSeleccionadas[2] &&
            (!estructurasSeleccionadas[3] && !estructurasSeleccionadas[4] && !estructurasSeleccionadas[6] &&
            !estructurasSeleccionadas[5] && !estructurasSeleccionadas[8] && !estructurasSeleccionadas[7]))
        {
            return Ediciones.UnTercio;
        }
        else if (estructurasSeleccionadas[0] && estructurasSeleccionadas[1] && estructurasSeleccionadas[2]
            && estructurasSeleccionadas[3] && estructurasSeleccionadas[4] && estructurasSeleccionadas[5] &&
            (!estructurasSeleccionadas[6] && !estructurasSeleccionadas[7] && !estructurasSeleccionadas[8]))
        {
            return Ediciones.DosTercios;
        }
        else if (estructurasSeleccionadas[3] && estructurasSeleccionadas[6] && estructurasSeleccionadas[7] &&
            estructurasSeleccionadas[4] && (!estructurasSeleccionadas[0] && !estructurasSeleccionadas[8] &&
            !estructurasSeleccionadas[5] && !estructurasSeleccionadas[1] && !estructurasSeleccionadas[2]))
        {
            return Ediciones.CuadroIzq;
        }
        else if (estructurasSeleccionadas[5] && estructurasSeleccionadas[8] && estructurasSeleccionadas[7] &&
            estructurasSeleccionadas[4] && (!estructurasSeleccionadas[6] && !estructurasSeleccionadas[3] &&
            !estructurasSeleccionadas[0] && !estructurasSeleccionadas[1] && !estructurasSeleccionadas[2]))
        {
            return Ediciones.CuadroDer;
        }
        else if (estructurasSeleccionadas[6] && estructurasSeleccionadas[8] && estructurasSeleccionadas[7] &&
            estructurasSeleccionadas[4] && (!estructurasSeleccionadas[5] && !estructurasSeleccionadas[3] &&
            !estructurasSeleccionadas[0] && !estructurasSeleccionadas[1] && !estructurasSeleccionadas[2]))
        {
            return Ediciones.TInvertida;
        }
        else
        {
            ReiniciarEdicion();
            return Ediciones.NoDefinida;
        }
    }

    private void AsignarModeloEdicion()
    {
        ObjetoActual = EditDatabase.Instance.DarObjeto(edicionDibujada.ToString());
        gameObject.GetComponent<MeshFilter>().mesh = ObjetoActual;
        gameObject.GetComponent<MeshCollider>().sharedMesh = ObjetoActual;
    }
}
