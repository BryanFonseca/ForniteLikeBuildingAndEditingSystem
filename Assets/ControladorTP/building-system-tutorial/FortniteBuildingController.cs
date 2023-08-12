using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FortniteBuildingController : MonoBehaviour {
	public float baseSquareLength = 4.5f;
	private GameObject[] firstLevelWalls = new GameObject[4];
	public Material buildingGuidesMaterial;
	public Material invisibleMaterial;

	private GameObject baseSquare;
	private GameObject buildingGuides;

	void Start () {
		generateBuildingGuides();
	}
	
	void Update () {
		CalculateBaseSquarePosition();
	}

	void FixedUpdate() {
        firstLevelWalls.ToList().ForEach(wall => wall.GetComponent<MeshRenderer>().material = invisibleMaterial);
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, 10, LayerMask.GetMask("BuildingReference")))
        {
            Debug.DrawLine(transform.position, hitInfo.point);
            if (hitInfo.collider.tag == "BuildingReference")
            {
                GameObject wall = hitInfo.collider.gameObject;
                wall.GetComponent<MeshRenderer>().material = buildingGuidesMaterial;
                // distancia entre el personaje y la pared que tiene en frente
                Vector3 hitDistance = wall.transform.position - transform.position;
                // La magnitud de (distance * wall.transform.forward) es la distancia "vertical"
                // Ya que al multiplicar las componentes que no sean la azul, serán 0
                // Otro enfoque que funciona independientemente de la rotación es usar hitInfo.normal
                // float forwardDistance = Vector3.Scale(hitDistance, hitInfo.normal).magnitude;
                float forwardDistance = Vector3.Scale(hitDistance, wall.transform.forward).magnitude;
                // float distanceToHit = hitInfo.distance / baseSquareLength; // Esto no es suficiente
                float distanceToHit = forwardDistance / baseSquareLength;
                float distanceComplement = 1 - distanceToHit;
                // the collider's center will only be between 0 and -1
                // so that the raycast will always be able to hit a building reference
                float centerYClamped = Mathf.Clamp(-(distanceComplement), -1, 0);
                wall.GetComponent<BoxCollider>().center = new Vector3(0, centerYClamped, 0);
            }
        }
    }

	void CalculateBaseSquarePosition() {
		float xPos = baseSquareLength * (Mathf.Floor(transform.position.x / baseSquareLength));
        float zPos = baseSquareLength * (Mathf.Floor(transform.position.z / baseSquareLength));

        buildingGuides.transform.position = new Vector3(xPos + (baseSquareLength / 2), 0, zPos + (baseSquareLength / 2));
		buildingGuides.transform.rotation = Quaternion.Euler(0, 0, 0);
	}

	public void build(){
		print("Building like in Fortnite");
	}

	void generateBuildingGuides() {
		buildingGuides = GameObject.Find("BuildingGuides");

		baseSquare = GameObject.CreatePrimitive(PrimitiveType.Cube);
		baseSquare.transform.localScale = new Vector3(baseSquareLength, .1f, baseSquareLength);
		baseSquare.transform.parent = buildingGuides.transform;
		baseSquare.GetComponent<MeshRenderer>().material = buildingGuidesMaterial;
		// baseSquare.GetComponent<BoxCollider>().isTrigger = true;
		baseSquare.name = "BaseFloor";
		// walls start counting from 0 clockwise
        firstLevelWalls = firstLevelWalls
            .Select((wall, i) => {
                wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wall.name = "wall_" + i;
                wall.transform.parent = GameObject.Find("FirstLevelWalls").transform;
                wall.GetComponent<BoxCollider>().isTrigger = true;
                wall.GetComponent<BoxCollider>().size = new Vector3(1, 1.2f, 1);
                wall.tag = "BuildingReference";
                wall.layer = 12;

                float height = 4f;
                wall.transform.localScale = new Vector3(baseSquareLength, height, 0.1f);
                wall.transform.localRotation = Quaternion.Euler(0, 90f * i, 0);
                wall.transform.position += (wall.transform.forward * baseSquareLength / 2) + new Vector3(0, height / 2, 0);
                return wall;
            }).ToArray();
	}
}
