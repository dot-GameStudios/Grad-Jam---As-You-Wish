using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePlayerMovement : State
{
    [Header("Data")]
    [SerializeField] private DataInt dataInt;
    [SerializeField] private DataBool Condition;

    public LayerMask GroundLayer;

    [Header("References")]
    [SerializeField] private DataInputController Controller;
    [SerializeField] private Rigidbody2D Rigidbody;

    public void GroundCheck()
    {
        Condition.Value = GetComponent<Collider2D>().IsTouchingLayers(GroundLayer);
    }

    public void InputLock(string KeyName)
    {
        Controller.InputLock(KeyName);
    }

    public void DecreaseJumpCount()
    {
        
    }

    public void GetKeys(DataInputController controller)
    {
        
    }
}
