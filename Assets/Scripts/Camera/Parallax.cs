using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPosition;
    public GameObject mainCamera;
    public float parallaxSpeed;
    public bool verticalParallax;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (mainCamera.transform.position.x * (1 - parallaxSpeed));
        float distance = (mainCamera.transform.position.x * parallaxSpeed);
        float vDistance = (mainCamera.transform.position.y * parallaxSpeed);
       
        if (verticalParallax)
        {
            transform.position = new Vector3(startPosition + distance, startPosition + vDistance, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);
        }

        if (temp > startPosition + length)
        {
            startPosition += length;
        }
        else if(temp < startPosition - length){
            startPosition -= length;
        }
    }
}
