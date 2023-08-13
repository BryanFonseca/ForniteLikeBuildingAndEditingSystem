using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FortniteBuildingController : MonoBehaviour {
	public float baseSquareLength = 4.5f;
	public Material visibleMaterial;
	public Material invisibleMaterial;

	private GameObject buildingGuides;
	private Wall baseSquare;
	private Wall[] firstLevelWalls = new Wall[4];

	void Start () {
		GenerateBuildingGuides();
        GameObject emptyObject = new GameObject("EmptyObject");
        // Attach the GameObject to the current scene
        SceneManager.MoveGameObjectToScene(emptyObject, SceneManager.GetActiveScene());
	}
	
	void Update () {
		CalculateBaseSquarePosition();
	}

	void FixedUpdate() {
        // firstLevelWalls.ToList().ForEach(wall => wall.GetComponent<MeshRenderer>().material = invisibleMaterial);
        firstLevelWalls.ToList().ForEach(wall => wall.Hide());
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, 10, LayerMask.GetMask("BuildingReference")))
        {
            Debug.DrawLine(transform.position, hitInfo.point);
            if (hitInfo.collider.TryGetComponent(out Wall wall))
            {
                wall.Show();
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

	void GenerateBuildingGuides() {
		buildingGuides = GameObject.Find("BuildingGuides");

		baseSquare = CreateWallGuide(buildingGuides, "BaseFloor");
        Quaternion floorRotation = Quaternion.Euler(90, 0, 0);
        baseSquare.Init(visibleMaterial, invisibleMaterial).Place(Vector3.zero, floorRotation);
        baseSquare.GetComponent<BoxCollider>().isTrigger = true;
		// walls start counting from 0 clockwise
        GameObject firstLevelWallsParent = GameObject.Find("FirstLevelWalls");
        firstLevelWalls = firstLevelWalls
            .Select((wall, i) => {
                wall = CreateWallGuide(firstLevelWallsParent, "wall_" + i);
                Quaternion wallRotation = Quaternion.Euler(0, 90f * i, 0);
                wall.Init(visibleMaterial, invisibleMaterial).Place(Vector3.zero, wallRotation);
                wall.transform.position += (wall.transform.forward * baseSquareLength / 2) + new Vector3(0, wall.transform.localScale.y / 2, 0);
                wall.GetComponent<BoxCollider>().isTrigger = true;
                wall.GetComponent<BoxCollider>().size = new Vector3(1, 1.2f, 1);
                wall.tag = "BuildingReference";
                return wall;
            }).ToArray();
	}

    // Intended to be used as a fallback if no wall prefab is provided
    Wall CreateWallGuide(GameObject parent, string name) {
        GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
		wall.name = name;
		wall.transform.parent = parent.transform;
        wall.transform.localScale = new Vector3(baseSquareLength, baseSquareLength, 0.1f);
        wall.layer = 12;
        return wall.AddComponent<Wall>();
    }
}
