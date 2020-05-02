using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAudio : MonoBehaviour
{
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
}
