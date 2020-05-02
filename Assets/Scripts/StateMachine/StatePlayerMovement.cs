using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePlayerMovement : State
{
    [Header("Data")]
    [SerializeField] private DataInt dataIntMax;
    [SerializeField] private DataInt dataInt;
    [SerializeField] private DataBool Condition;
    
    public LayerMask GroundLayer;

    [Header("References")]
    [SerializeField] private DataInputController Controller;
    [SerializeField] private Rigidbody2D Rigidbody;

    public void GetData()
    {
        Condition = data.Bool(Condition);
        dataIntMax = data.Int(dataIntMax);
        dataInt = data.Int(dataInt);
    }

    public void GroundCheck()
    {
        Condition.Value = GetComponent<Collider2D>().IsTouchingLayers(GroundLayer);
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
