using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorScript1 : MonoBehaviour 
{
	//public SistemaConstruccion_01 sConstruccion;
	public bool editando;
	IEditable componente;

	public GameObject estructuras;
	public Transform rayoEdicion;

	public bool dibujando;

	public GameObject EdicionActual = null;
	public float distanciaObjetoEditando;

	void Update()
	{		
		RaycastHit hit;

		//Logica de editar y dejar de editar
		GameObject playerTemp = GameObject.FindWithTag("Player");
		Vector3 posRayo = new Vector3(playerTemp.transform.position.x, playerTemp.transform.position.y + 2, playerTemp.transform.position.z);


        if (Input.GetKeyDown(KeyCode.G))
        {

			if (Physics.Raycast(posRayo, playerTemp.transform.forward, out hit, 4.49f))
			{
				componente = hit.collider.gameObject.GetComponent<IEditable>();
				EdicionActual = hit.collider.gameObject;
				SetEdit(true);
				if (componente != null && EdicionActual != null)
				{
					componente.ConfirmarEdicion();
					componente.HabilitarEstructuras();
					//EdicionActual.GetComponent<MeshCollider>().enabled = false;
				}
			}
			else
			{
				SetEdit(false);
				componente.ConfirmarEdicion();
				EdicionActual.GetComponent<MeshCollider>().enabled = true;
			}
        }

        if (editando)
		{
			SistemaConstruccion_01 sc = GameObject.FindGameObjectWithTag("Player").GetComponent<SistemaConstruccion_01>();
			sc.SacarPlanos(true);
			sc.enabled = false;


			EdicionActual.GetComponent<MeshRenderer>().enabled = false;

			if (Input.GetKeyDown(KeyCode.Mouse1))
			{
				componente.ReiniciarEdicion();
			}
			//Se empieza a dibujar la edición					
			estructuras.SetActive(false);			
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			DibujarEdicion();

			if (EdicionActual != null)
			{
				distanciaObjetoEditando = Vector3.Distance(EdicionActual.transform.position, posRayo);
				if (distanciaObjetoEditando > 4.5f)
					SetEdit(false);
			}
		}
		else
		{
			SistemaConstruccion_01 sc = GameObject.FindGameObjectWithTag("Player").GetComponent<SistemaConstruccion_01>();
			//sc.SacarPlanos(false);
			sc.enabled = true;

			//Se confirma edición
			estructuras.SetActive(true);

			//el cálculo de y asignación de la edición correspondiente basado en los cuadros presionados se gestiona en los objetos
			//que implementan la interfaz IEditable

			if(EdicionActual != null)
				EdicionActual.GetComponent<MeshRenderer>().enabled = true;

			if(componente != null)
				componente.DeshabilitarEstructuras();

			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}

	private void SetEdit(bool valor)
	{
		editando = valor;
	}

	private void DibujarEdicion()
	{
		//Se empieza a dibujar edición
		RaycastHit hitDibujo;
		if (Physics.Raycast(transform.position, transform.forward, out hitDibujo))
		{
			if (hitDibujo.collider.tag == "Editor")
			{
				if (Input.GetKey(KeyCode.Mouse0))
				{
					dibujando = true;
					componente.PresionarIndice(componente.ObjetoAIndice(hitDibujo.collider.gameObject));
					return;
				}
				dibujando = false;
			}
		}
	}
}
