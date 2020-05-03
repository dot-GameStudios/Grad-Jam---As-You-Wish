using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePlayerMovement : State
{
    [Header("Data")]
    [SerializeField] private DataInt dataIntMax;
    [SerializeField] private DataInt dataInt;
    [SerializeField] private DataBool Condition;
    [SerializeField] private DataBool Healthy;

    public LayerMask GroundLayer;

    [Header("References")]
    [SerializeField] private DataInputController Controller;
    [SerializeField] private Rigidbody2D Rigidbody;
    [SerializeField] private Rigidbody2DTrigger RB2DTrigger;

    public void GetData()
    {
        Condition = data.Bool(Condition);
        Healthy = data.Bool(Healthy);
        dataIntMax = data.Int(dataIntMax);
        dataInt = data.Int(dataInt);
        RB2DTrigger = GetComponent<Rigidbody2DTrigger>();
    }

    public void GroundCheck()
    {
        Condition.Value = GetComponent<Collider2D>().IsTouchingLayers(GroundLayer);
    }

    public void Damage()
    {
        if (RB2DTrigger.Tag == "Harmful") {
            Healthy.Value = false;
        }
    }

    public void ExtraJump()
    {
        if (RB2DTrigger.Tag == "Key")
        {
            dataIntMax.Value++;
        }
    }

    public void TotalInputLockToggle(bool value)
    {
        Controller.TotalInputLockToggle(value);
    }

    public void DecreaseIntCount()
    {
        if (dataInt.Value > 0)
        {
            dataInt.Value--;
        }
    }

   public void JumpLimit(string KeyName)
   {
        if(Condition.Value == false && dataInt.Value == 0)
        {
            Controller.GetKey(KeyName).InputLock(true);
        }
        else if (Condition.Value == true)
        {
            Controller.GetKey(KeyName).InputLock(false);
            dataInt.Value = dataIntMax.Value;
        }
   }
}
