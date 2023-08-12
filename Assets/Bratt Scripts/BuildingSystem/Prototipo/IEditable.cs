using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEditable
{
    //Será implementada por objetos editables
    void ConfirmarEdicion();
    void ReiniciarEdicion();
    void HabilitarEstructuras();
    void DeshabilitarEstructuras();
    void PresionarIndice(int indice);
    int ObjetoAIndice(GameObject objeto);
}
