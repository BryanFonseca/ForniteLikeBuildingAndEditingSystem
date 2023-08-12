using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejemplo : MonoBehaviour {

    public Vector3 vector, planeNormal;
    public Vector3 response;
    public float radians;
    public float degrees;
    public float timer = 12345.0f;

    // Generate the values for all the examples.
    // Change the example every two seconds.
    void Update()
    {
        
            // Generate a position inside xy space.
            //vector = new Vector3(1, 1, 0.0f);

            // Compute a normal from the plane through the origin.
            //degrees = 45;
            radians = degrees * Mathf.Deg2Rad;
            planeNormal = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0.0f);

            // Obtain the ProjectOnPlane result.
            response = Vector3.ProjectOnPlane(vector, planeNormal);

         
    }

    // Show a Scene view example.
    void OnDrawGizmosSelected()
    {
        // Left/right and up/down axes.
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position - new Vector3(2.25f, 0, 0), transform.position + new Vector3(2.25f, 0, 0));
        Gizmos.DrawLine(transform.position - new Vector3(0, 1.75f, 0), transform.position + new Vector3(0, 1.75f, 0));

        // Display the plane.
        Gizmos.color = Color.green;
        Vector3 angle = new Vector3(-1.75f * Mathf.Sin(radians), 1.75f * Mathf.Cos(radians), 0.0f);
        Gizmos.DrawLine(transform.position - angle, transform.position + angle);

        // Show a connection between vector and response.
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(vector, response);

        // Now show the input position.
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(vector, 0.05f);

        // And finally the resulting position.
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(response, 0.05f);
    }
}
