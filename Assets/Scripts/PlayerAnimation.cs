using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    
    public Data data;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    [SerializeField]private DataBool Grounded, Gliding, Jumped, Walking;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }

        Grounded = data.Bool(Grounded);
        Gliding = data.Bool(Gliding);
        Jumped = data.Bool(Jumped);
        Walking = data.Bool(Walking);


        //for (int i = animator.parameterCount - 1; i >= 0; i--) {
        //   if(animator.parameters[i])
        //   {
        //   }
        //}

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Grounded", Grounded.Value);
        animator.SetBool("Gliding", Gliding.Value);
        animator.SetBool("Walking", Walking.Value);
        animator.SetBool("Jumped", Jumped.Value);

        if(Jumped.Value == true)
        {
            Jumped.Value = false;
        }
    }

    public void GlideToggle(bool value)
    {
        Gliding.Value = value;
    }

    public void WalkToggle(bool value)
    {
        Walking.Value = value;
    }

    public void hasJumped()
    {
        Jumped.Value = true;
    }

    //public void FlightAnimation()
    //{
    //    animator.SetBool("Grounded", true);
    //     animator.SetBool("Idle",false);

    //}

    //public void RunAnimation()
    //{
    //    animator.SetBool("Run",true);
    //    animator.SetBool("Idle",false);
    //}

    //public void StopRunning()
    //{
    //   animator.SetBool("Run",false);
    //   animator.SetBool("Flying",false);
    //   animator.SetBool("Idle",true);
    //}

    public void FlipSprite(bool value)
    {
        spriteRenderer.flipX = value;
    }
   
}
