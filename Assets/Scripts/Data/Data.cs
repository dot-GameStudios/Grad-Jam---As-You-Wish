using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    [SerializeField, HideInInspector] private List<DataBool> bools = new List<DataBool>();
    public List<DataBool> Bools { get => bools; }

    [SerializeField, HideInInspector] private List<DataInt> ints = new List<DataInt>();
    public List<DataInt> Ints { get => ints; }

    [SerializeField, HideInInspector] private List<DataFloat> floats = new List<DataFloat>();
    public List<DataFloat> Floats { get => floats; }

    [SerializeField, HideInInspector] private List<DataVector2> vector2s = new List<DataVector2>();
    public List<DataVector2> Vector2s { get => vector2s; }

    public DataBool Bool(DataBool node)
    {
        DataBool found = bools.Find(d => d.Name == node.Name);
        if (found != null)
            return found;
        else
            bools.Add(node);
        return node;
    }
    public DataInt Int(DataInt node)
    {
        DataInt found = ints.Find(d => d.Name == node.Name);
        if (found != null)
            return found;
        else
            ints.Add(node);
        return node;
    }
    public DataFloat Float(DataFloat node)
    {
        DataFloat found = floats.Find(d => d.Name == node.Name);
        if (found != null)
            return found;
        else
            floats.Add(node);
        return node;
    }
    public DataVector2 Vector2(DataVector2 node)
    {
        DataVector2 found = vector2s.Find(d => d.Name == node.Name);
        if (found != null)
            return found;
        else
            vector2s.Add(node);
        return node;
    }

    public DataBool GetBool(string name) { return bools.Find(d => d.Name == name); }
    public DataInt GetInt(string name) { return ints.Find(d => d.Name == name); }
    public DataFloat GetFloat(string name) { return floats.Find(d => d.Name == name); }
    public DataVector2 GetVector2(string name) { return vector2s.Find(d => d.Name == name); }

    public bool Has(DataBool data) { return bools.Find(d => d.Name == data.Name) != null; }
    public bool Has(DataInt data) { return ints.Find(d => d.Name == data.Name) != null; }
    public bool Has(DataFloat data) { return floats.Find(d => d.Name == data.Name) != null; }
    public bool Has(DataVector2 data) { return vector2s.Find(d => d.Name == data.Name) != null; }

    public void Add(DataBool data) { bools.Add(data); }
    public void Add(DataInt data) { ints.Add(data); }
    public void Add(DataFloat data) { floats.Add(data); }
    public void Add(DataVector2 data) { vector2s.Add(data); }
}
