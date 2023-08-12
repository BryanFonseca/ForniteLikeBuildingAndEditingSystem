using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
	public Material visibleMaterial;
	public Material invisibleMaterial;

    public Wall Init(Material visibleMaterial, Material invisibleMaterial) {
        this.visibleMaterial = visibleMaterial;
        this.invisibleMaterial = invisibleMaterial;
        Show();
        return this;
    }

    public void Place(Vector3 position, Quaternion rotation) {
        this.transform.rotation = rotation;
        this.transform.position = position;
    }

    public void Show() {
        GetComponent<MeshRenderer>().material = visibleMaterial;
    }

    public void Hide() {
        GetComponent<MeshRenderer>().material = invisibleMaterial;
    }
}
