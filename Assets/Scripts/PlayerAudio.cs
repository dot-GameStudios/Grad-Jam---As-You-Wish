using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAudio : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JumpAudio()
    {

        FMODUnity.RuntimeManager.PlayOneShot("event:/bat_flapping",GetComponent<Transform>().position);
    }

    public void WalkAudio()
    {
        if (!animator.GetBool("Flying"))
            FMODUnity.RuntimeManager.PlayOneShot("event:/bat_walking",GetComponent<Transform>().position);
            
    }
}
