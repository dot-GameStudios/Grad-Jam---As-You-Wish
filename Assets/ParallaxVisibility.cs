using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxVisibility : MonoBehaviour
{
    public GameObject ParallaxImages;
    public bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isActive = !isActive;
            ParallaxImages.SetActive(isActive);
        }
    }
}
