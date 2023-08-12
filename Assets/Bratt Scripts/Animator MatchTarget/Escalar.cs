using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchTarget : MonoBehaviour 
{
	private Animator anim;
	private GameObject instancia;

	public float EspacioAdicional;
	public float ZOffset;
	public GameObject Indicador;

	void Start()
	{
		anim = gameObject.GetComponent<Animator>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			RaycastHit hit;
			if (Physics.Raycast(transform.position + new Vector3(.1f, .1f, .1f), transform.forward, out hit))
			{
				if (hit.distance < 1.5f)
				{
					instancia = Instantiate(Indicador, hit.point + new Vector3(0, hit.collider.gameObject.transform.localScale.y - EspacioAdicional, 0), Quaternion.identity);
					anim.SetBool("Escalar", true);
					StartCoroutine("Pos");
				}

			}
			
		}
		else
		{
			anim.SetBool("Escalar", false);
		}

				
	}
	IEnumerator Pos()
	{
		while (transform.position.magnitude - instancia.transform.position.magnitude < .1f)
		{
			transform.position = Vector3.Lerp(transform.position, new Vector3(instancia.transform.position.x, instancia.transform.position.y, instancia.transform.position.z + ZOffset), Time.deltaTime * 3f);
			yield return null;
		}
	}

}
