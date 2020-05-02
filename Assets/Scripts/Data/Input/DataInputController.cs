using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInputController : MonoBehaviour
{
    [Header("Keys")]
    [SerializeField] private List<DataInputKey> keys = new List<DataInputKey>();
    public DataInputKey GetKey(string name) { return keys.Find(key => key.Name == name); }
  
    [Header("References")]
    [SerializeField] private Data data;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = keys.Count - 1; i >= 0; i--)
            keys[i].Start(data);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = keys.Count - 1; i >= 0; i--)
            keys[i].Update();
    }

    public void InputLock(string KeyName)
    {
        GetKey(KeyName).InputLockToggle();
    }
}
