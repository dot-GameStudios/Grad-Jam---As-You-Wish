using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlightAnimation()
    {
        animator.SetBool("Flying", true);
    }

    public void RunAnimation()
    {
        animator.SetBool("Flying", false);
    }

    public void FlipForward()
    {
        spriteRenderer.flipX = true;
    }

        public void FlipBackward()
    {
        spriteRenderer.flipX = false;
    }
}
