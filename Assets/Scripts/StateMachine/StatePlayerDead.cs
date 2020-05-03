using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePlayerDead : State
{
    public float deathcount;
    private float originalCount;
    [SerializeField]private DataBool Healthy;

    public void Initialize()
    {
        Healthy = data.Bool(Healthy);
        originalCount = deathcount;
    }

    public void CountDown()
    {
        deathcount -= Time.fixedDeltaTime;
        if(deathcount <= 0)
        {
            Healthy.Value = true;
            deathcount = originalCount;
        }

    }

    
}
