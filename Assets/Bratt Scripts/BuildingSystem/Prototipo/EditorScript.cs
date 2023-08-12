using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorScript : MonoBehaviour 
{
	public bool editando;
	public bool dibujando;
	public GameObject estructuras;

	private IEditable componente;
	private GameObject EdicionActual = null;
	private float distanciaObjetoEditando;

	void Update()
	{		
		RaycastHit hit;

		//Logica de editar y dejar de editar
		GameObject playerTemp = GameObject.FindWithTag("Player");
		Vector3 posRayo = new Vector3(playerTemp.transform.position.x, playerTemp.transform.position.y + 2, playerTemp.transform.position.z);

		if (!dibujando)
		{
			if (Physics.Raycast(posRayo, playerTemp.transform.forward, out hit, 4.45f))
			{
				if (hit.collider.gameObject.GetComponent<IEditable>() != null)
				{
					componente = hit.collider.gameObject.GetComponent<IEditable>();

					if (Input.GetKeyDown(KeyCode.G))
					{
						SetEdit(true);
						EdicionActual = hit.collider.gameObject;
						EdicionActual.GetComponent<MeshCollider>().enabled = false;
						componente.HabilitarEstructuras();
						//editando = true;
					}
				}
				else if (Input.GetKeyDown(KeyCode.G))
				{

					SetEdit(false);
					componente.ConfirmarEdicion();

					componente.DeshabilitarEstructuras ();
					if (EdicionActual != null)
						EdicionActual.GetComponent<MeshCollider>().enabled = true;

				}
			}
			else if (Input.GetKeyDown(KeyCode.G))
			{
				SetEdit(false);

				if (componente != null)
					componente.ConfirmarEdicion();

				if (EdicionActual != null)
					EdicionActual.GetComponent<MeshCollider>().enabled = true;
				componente.DeshabilitarEstructuras();
			}
		}

		if (editando)
		{
			SistemaConstruccion_01 sc = GameObject.FindGameObjectWithTag("Player").GetComponent<SistemaConstruccion_01>();
			sc.SacarPlanos(true);
			sc.enabled = false;
			GameObject.FindWithTag("Player").GetComponent<Apuntador>().ap = false;

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

					if (Input.GetKeyDown(KeyCode.G))
					{
						dibujando = false;
						SetEdit(false);

						if (componente != null)
							componente.ConfirmarEdicion();

						if (EdicionActual != null)
							EdicionActual.GetComponent<MeshCollider>().enabled = true;
					}
					return;
				}
				dibujando = false;
			}
		}
	}
}
