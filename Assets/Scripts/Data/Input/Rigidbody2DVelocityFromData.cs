using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigidbody2DVelocityFromData : MonoBehaviour
{
    private LayerMask GroundLayer;

    [Header("Data")]
    [SerializeField] private DataFloat dataFloat;
    [SerializeField] private DataFloat dataDirection;
    [SerializeField] private DataBool Condition;
    
    //[SerializeField] private List<DataBool> dataBools = new List<DataBool>();
    //[SerializeField] private List<DataInt> dataInts = new List<DataInt>();
    //[SerializeField] private List<DataFloat> dataFloats = new List<DataFloat>();
    //[SerializeField] private List<DataVector2> dataVector2s = new List<DataVector2>();
    [Header("References")]
    [SerializeField] private Data data;
    [SerializeField] private Rigidbody2D rigidbody_;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<Data>();
        rigidbody_ = GetComponent<Rigidbody2D>();

        Condition = data.Bool(Condition);
        dataFloat = data.Float(dataFloat);
        dataDirection = data.Float(dataDirection);

        //for (int i = dataBools.Count - 1; i >= 0; i--)
        //{
        //    dataBools[i] = data.Bool(dataBools[i]);
        //}

        //for (int i = dataInts.Count - 1; i >= 0; i--)
        //{
        //    dataInts[i] = data.Int(dataInts[i]);
        //}

        //for (int i = dataFloats.Count - 1; i >= 0; i--)
        //{
        //    dataFloats[i] = data.Float(dataFloats[i]);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VerticalForceImpulse()
    {
        Debug.Log(dataFloat.Name);
        //rigidbody_.AddForce(new Vector2(rigidbody_.velocity.x, (float)dataFloats[0]), ForceMode2D.Impulse);
        rigidbody_.AddForce(new Vector2(rigidbody_.velocity.x, dataFloat.Value), ForceMode2D.Impulse);
        
    }

    public void VerticalForceImpulse(float value)
    {
        //rigidbody_.AddForce(new Vector2(rigidbody_.velocity.x, (float)dataFloats[0]), ForceMode2D.Impulse);
        rigidbody_.velocity = new Vector2(rigidbody_.velocity.x, 0);
        Vector2 temp = Vector2.zero;

        rigidbody_.AddForce(new Vector2(rigidbody_.velocity.x, value), ForceMode2D.Impulse);
        //rigidbody_.velocity.Normalize();
    }

    public void HorizontalMovement()
    {
        //rigidbody_.velocity = new Vector2( (float)dataFloats[0] * (float)dataFloats[1], rigidbody_.velocity.y);
        rigidbody_.velocity = new Vector2(dataDirection.Value * dataFloat.Value, rigidbody_.velocity.y);
    }

    public void HorizontalMovement(float value)
    {
        //rigidbody_.velocity = new Vector2( (float)dataFloats[0] * (float)dataFloats[1], rigidbody_.velocity.y);
        rigidbody_.velocity = new Vector2(dataDirection.Value * value, rigidbody_.velocity.y);
    }

    public void ResetSpeedX()
    {
        rigidbody_.velocity = new Vector2(0.0f, rigidbody_.velocity.y);
    }

    public void SetLinearDrag(int drag)
    {
        rigidbody_.drag = drag;
    }
}
