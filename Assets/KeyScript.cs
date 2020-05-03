using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private Collider2D collider;
    public GameObject keySpot;
    public GameObject Pillar;
    public Sprite newPillarImage;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeyAquired()
    {
        transform.position = keySpot.transform.position;
        Pillar.GetComponent<SpriteRenderer>().sprite = newPillarImage;
        Destroy(collider);
    }
}
