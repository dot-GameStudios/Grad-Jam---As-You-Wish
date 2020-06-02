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
    public GameObject rayPosLeft;
    public GameObject rayPosRight;
    
    //public GameObject Feet;
    public GameObject CheckPoint;

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
        float rayDistance = 0.8f;
        
        RaycastHit2D leftHit = Physics2D.Raycast(rayPosLeft.transform.position, Vector2.down, rayDistance, GroundLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(rayPosRight.transform.position, Vector2.down, rayDistance, GroundLayer);

        //Debug.DrawRay(rayPosLeft.transform.position, Vector2.down, Color.red);
        //Debug.DrawRay(rayPosRight.transform.position, Vector2.down, Color.red);

        if (leftHit.collider != null || rightHit.collider != null)
        {
            Condition.Value = true;
        }
        else if(leftHit.collider == null && rightHit.collider == null)
        {
            Condition.Value = false;
        }
    }
    
    public void Damage()
    {
        if (RB2DTrigger.CollTag == "Harmful") {
            Healthy.Value = false;
        }
    }

    public void ExtraJump()
    {
        if (RB2DTrigger.CollTag == "Key")
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

    public void Teleport()
    {
        transform.position = CheckPoint.transform.position;
    }

    public void GetCheckPoint()
    {
        if (RB2DTrigger.CollTag == "Checkpoint")
        {
            CheckPoint = RB2DTrigger.Collider.gameObject;
        }
    }
}
