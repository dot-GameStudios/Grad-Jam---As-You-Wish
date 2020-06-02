using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private Collider2D Collider;
    public GameObject keySpot;
    public GameObject Pillar;
    public Sprite newPillarImage;
    public GameObject extraJumpObj;
    // Start is called before the first frame update
    void Start()
    {
        Collider = GetComponent<Collider2D>();  
    }

    // Update is called once per frame
    void Update()
    {}

    public void KeyAquired()
    {
        //detect if the player has collided with the Key object
        if (GetComponent<Rigidbody2DTrigger>().CollTag == "Player")
        {
            Instantiate(extraJumpObj,transform.position,Quaternion.identity);
            Destroy(Collider);
            transform.position = keySpot.transform.position;
            Pillar.GetComponent<SpriteRenderer>().sprite = newPillarImage;
            FindObjectOfType<MoonScript>().IncreaseKeyCount();
        }   
    }
}
