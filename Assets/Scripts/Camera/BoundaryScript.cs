using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            CameraScript camera = Camera.main.GetComponent<CameraScript>();
            
            camera.setBoundary(this.GetComponent<BoxCollider2D>());

        }
    }
}
