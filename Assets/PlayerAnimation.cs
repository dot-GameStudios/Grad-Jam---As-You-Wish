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
         animator.SetBool("Idle",false);
     
    }

    public void RunAnimation()
    {
        animator.SetBool("Run",true);
        animator.SetBool("Idle",false);
    }

    public void StopRunning()
    {
       animator.SetBool("Run",false);
       animator.SetBool("Flying",false);
       animator.SetBool("Idle",true);
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
