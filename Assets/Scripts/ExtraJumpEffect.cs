using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraJumpEffect : MonoBehaviour
{
    private Transform T;
    private SpriteRenderer SRenderer;
    private Color Alpha;
    public float fadeRate;
    // Start is called before the first frame update
    void Start()
    {
        T = GetComponent<Transform>();
        SRenderer = GetComponent<SpriteRenderer>();
        Alpha = SRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        Alpha.a -= fadeRate;
        SRenderer.color = Alpha;
        T.position += new Vector3(0.0f, fadeRate, 0.0f);
        if(Alpha.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
