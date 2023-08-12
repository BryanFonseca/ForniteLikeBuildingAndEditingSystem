using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construcciones : MonoBehaviour
{
	[SerializeField]
	private GameObject Pared;
	[SerializeField]
	private GameObject Suelo;
	[SerializeField]
	private GameObject Rampa;
	[SerializeField]
	private GameObject RampaInstanciar;
	

	//float dis;
	float restaDelante;
	float restaAtras;
	float restaDelanteH;
	float restaAtrasH;
	float restaArriba;
	float restaAbajo;

	public Transform siguientePos;
	public Transform antePos;
	public Transform siguientePosH;
	public Transform antePosH;
	public Transform siguientePosV;
	public Transform antePosV;

	public GameObject[] visibilidadParedes;
	public GameObject[] visibilidadSuelos;

	//Posición y rotación de los objetos a instanciar
	Vector3 RotacionPared;
	Vector3 PosicionPared;
	Vector3 RotacionSuelo;
	Vector3 PosicionSuelo;

	private Vector3 cantidadHorizontal = new Vector3(5, 0, 0);
	private Vector3 cantidadVertical = new Vector3(0, 0, 5); //en realidad profundidad
	private Vector3 cantidadArriba = new Vector3(0, 4, 0);

	public bool puedeConstruir;
	private bool mostrarRampas;
	private bool mostrarParedes;
	private bool mostrarSuelos;

	public GameObject Paredes;
	public GameObject Suelos;

	public GameObject ray;
	RaycastHit hit;

	public enum Cardinales { Norte, Sur, Este, Oeste }
	public Cardinales direccion;
	void Start()
	{
		Visible(visibilidadSuelos, false);
	}

	void Update()
	{
		MostrarGuias();
		Controles();
		ControlarDireccion();
		PosicionEstructurasGuias();

		if (puedeConstruir)
		{
			GameObject.Find("Planos").GetComponent<MeshRenderer>().enabled = true;
			GameObject.Find("Lapiz").GetComponent<MeshRenderer>().enabled = true;

			Cursor.lockState = CursorLockMode.Locked;

			//temporal
			if (mostrarRampas)
			{
				Construir("Rampa");
			}

			if (Physics.Raycast(ray.transform.position, ray.transform.forward, out hit, 10f))
			{
				if (hit.collider.tag == "ParedC")
				{
					if (mostrarParedes)
					{
						Visible(visibilidadParedes, true);
						Visible(visibilidadSuelos, false);
						RotacionPared = hit.transform.rotation.eulerAngles;
						PosicionPared = hit.transform.position;
						GameObject actual = hit.transform.gameObject;

						for (int i = 0; i < visibilidadParedes.Length; i++)
						{
							for (int a = 0; i < visibilidadParedes.Length; a++)
							{
								if (GameObject.ReferenceEquals(actual, visibilidadParedes[a]))
								{
									Visibilidad(a, i, visibilidadParedes);
									break;
								}
							}
						}
						Construir("Pared");
					}
				}

				if (mostrarSuelos || mostrarRampas)
				{
					if (hit.collider.tag == "SueloC")
					{
						Vector3 rampaTemp = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y + 2f, hit.collider.transform.position.z);
						Rampa.transform.position = rampaTemp;

						Visible(visibilidadParedes, false); //activa mesh renderer de todos los suelos
						Visible(visibilidadSuelos, true);
						RotacionSuelo = hit.transform.rotation.eulerAngles;
						PosicionSuelo = hit.transform.position;
						GameObject actualSuelo = hit.transform.gameObject;
						for (int i = 0; i < visibilidadSuelos.Length; i++)
						{
							for (int a = 0; a < visibilidadSuelos.Length; a++)
							{
								if (GameObject.ReferenceEquals(actualSuelo, visibilidadSuelos[a]))
								{
									if (mostrarSuelos)
									{
										Visibilidad(a, i, visibilidadSuelos);
										break;
									} else if (mostrarRampas)
									{
										Visible(visibilidadSuelos, false);
										break;
									}
								}
							}
						}

						if(!mostrarRampas)
							Construir("Suelo");
					}
					else if (hit.collider.tag == "Suelo")
					{
						Vector3 rampaTemp = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y + 2f, hit.collider.transform.position.z);
						Rampa.transform.position = rampaTemp;
					}
					else
					{
						Visible(visibilidadSuelos, false);
					}
				}
			}
		}
		else
		{
			Visible(visibilidadParedes, false);
			GameObject.Find("Planos").GetComponent<MeshRenderer>().enabled = false;
			GameObject.Find("Lapiz").GetComponent<MeshRenderer>().enabled = false;
			Cursor.lockState = CursorLockMode.None;
		}
	}

	private void ControlarDireccion()
	{

		if (transform.rotation.eulerAngles.y >= -45 && transform.rotation.eulerAngles.y <= 45)
		{
			direccion = Cardinales.Norte;
		}
		else if (transform.rotation.eulerAngles.y >= 45 && transform.rotation.eulerAngles.y <= 135)
		{
			direccion = Cardinales.Este;
		} else if (transform.rotation.eulerAngles.y >= 135 && transform.rotation.eulerAngles.y <= 225)
		{
			direccion = Cardinales.Sur;
		}
		else if (transform.rotation.eulerAngles.y >= 225 && transform.rotation.eulerAngles.y <= 360)
		{
			direccion = Cardinales.Oeste;
		}
	}

	//Muestra estructuras guías al activar el modo construcción
	private void MostrarGuias()
	{
		if (mostrarParedes)
		{
			Paredes.SetActive(true);
			Suelos.SetActive(false);
			Rampa.SetActive(false);
		} 
		else if (mostrarSuelos)
		{
			Suelos.SetActive(true);
			Paredes.SetActive(false);
			Rampa.SetActive(false);
		}
		else if (mostrarRampas)
		{
			Rampa.SetActive(true);
			Suelos.SetActive(true);
			Paredes.SetActive(false);
		}

		switch (direccion)
		{
			case Cardinales.Norte:
				Rampa.transform.rotation = Quaternion.Euler(new Vector3(50, 0, 0));
				break;
			case Cardinales.Este:
				Rampa.transform.rotation = Quaternion.Euler(new Vector3(50, 90, 0));
				break;
			case Cardinales.Sur:
				Rampa.transform.rotation = Quaternion.Euler(new Vector3(50, 180, 0));
				break;
			case Cardinales.Oeste:
				Rampa.transform.rotation = Quaternion.Euler(new Vector3(50, 270, 0));
				break;
		}
	}

	//Controla los inputs para asignar estructuras correspondientes
	private void Controles()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			mostrarRampas = !mostrarRampas;
			mostrarParedes = false;
			mostrarSuelos = false;
		}else if (Input.GetKeyDown(KeyCode.Tab))
		{
			mostrarParedes = !mostrarParedes;
			mostrarSuelos = false;
			mostrarRampas = false;
		}else if (Input.GetKeyDown(KeyCode.X))
		{
			mostrarSuelos = !mostrarSuelos;
			mostrarParedes = false;
			mostrarRampas = false;
		}
		
		if (!mostrarRampas && !mostrarParedes && !mostrarSuelos)
		{
			puedeConstruir = false;
			Visible(visibilidadSuelos, false);
			Visible(visibilidadParedes, false);
			Rampa.SetActive(false);
		}
		else
		{
			puedeConstruir = true;
		}
	}

	//Desactiva MeshRenderers correspondientes pasándole como parámetro el excluido(el que se mostrará)
	void Visibilidad(int excluido, int cont, GameObject[] objetoAOcultar)
	{
		for (int a = 0; a < objetoAOcultar.Length; a++)
		{
			if (cont == excluido)
			{
				objetoAOcultar[cont].GetComponent<MeshRenderer>().enabled = true;
				continue;
			}
			objetoAOcultar[cont].GetComponent<MeshRenderer>().enabled = false;
		}
	}

	//Desactiva todos los MeshRenderers
	void Visible(GameObject[] objeto, bool esVisible)
	{
		for (int i = 0; i < objeto.Length; i++)
		{
			objeto[i].GetComponent<MeshRenderer>().enabled = esVisible;
		}
	}	

	//Controla Inputs para construir
	void Construir(string construccion)
	{
		if (Input.GetKey(KeyCode.Mouse0))
		{
			if (construccion == "Pared")
			{
				Instantiate(Pared, PosicionPared, Quaternion.Euler(RotacionPared));
			}
			else if (construccion == "Suelo")
			{
				Instantiate(Suelo, PosicionSuelo, Quaternion.Euler(RotacionSuelo));
			} else if (construccion == "Rampa")
			{
				Instantiate(RampaInstanciar, Rampa.transform.position, Rampa.transform.rotation);
			}
		}
	}

	//Controla la posición de las estructuras
	void PosicionEstructurasGuias()
	{
		restaDelante = siguientePos.position.z - transform.position.z;
		restaDelanteH = siguientePosH.position.x - transform.position.x;
		restaAtras = antePos.position.z - transform.position.z;
		restaAtrasH = antePosH.position.x - transform.position.x;
		restaArriba = siguientePosV.position.y - transform.position.y;
		restaAbajo = antePosV.position.y - transform.position.y;

		if (restaDelante <= 0.001f)
		{
			siguientePos.position += cantidadVertical;
			siguientePosH.position += cantidadVertical;
			antePos.position += cantidadVertical;
			antePosH.position += cantidadVertical;
			siguientePosV.position += cantidadVertical;
			antePosV.position += cantidadVertical;
		}
		else if (restaAtras >= -0.001f)
		{
			antePos.position -= cantidadVertical;
			antePosH.position -= cantidadVertical;
			siguientePos.position -= cantidadVertical;
			siguientePosH.position -= cantidadVertical;
			siguientePosV.position -= cantidadVertical;
			antePosV.position -= cantidadVertical;
		}
		else if (restaDelanteH <= 0.001f)
		{
			siguientePosH.position += cantidadHorizontal;
			siguientePos.position += cantidadHorizontal;
			antePosH.position += cantidadHorizontal;
			antePos.position += cantidadHorizontal;
			siguientePosV.position += cantidadHorizontal;
			antePosV.position += cantidadHorizontal;
		}
		else if (restaAtrasH >= -0.001f)
		{
			antePosH.position -= cantidadHorizontal;
			antePos.position -= cantidadHorizontal;
			siguientePosH.position -= cantidadHorizontal;
			siguientePos.position -= cantidadHorizontal; 
			siguientePosV.position -= cantidadHorizontal; 
			antePosV.position -= cantidadHorizontal; 
		}
		else if (restaArriba <= 0.001f)
		{
			siguientePosV.position += cantidadArriba;
			siguientePosH.position += cantidadArriba;
			antePosH.position += cantidadArriba;
			antePosV.position += cantidadArriba;
			siguientePos.position += cantidadArriba;
			antePos.position += cantidadArriba;
		}
		else if (restaAbajo >= -0.001f)
		{
			siguientePosV.position -= cantidadArriba;
			antePosV.position -= cantidadArriba;
			siguientePosH.position -= cantidadArriba;
			antePosH.position -= cantidadArriba;
			siguientePos.position -= cantidadArriba;
			antePos.position -= cantidadArriba;
		}
	}	
}
