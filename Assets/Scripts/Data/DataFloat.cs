using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataFloat : DataNode
{
    [SerializeField] private float value;
    public float Value { get { return value; } set { this.value = value; } }

    public static DataFloat operator +(DataFloat left, float right)
    {
        left.Value += right;
        return left;
    }

    public static DataFloat operator -(DataFloat left, float right)
    {
        left.Value -= right;
        return left;
    }

    public static DataFloat operator *(DataFloat left, float right)
    {
        left.Value *= right;
        return left;
    }

    public static DataFloat operator /(DataFloat left, float right)
    {
        left.Value /= right;
        return left;
    }

    public static explicit operator float(DataFloat data)
    {
        return data.Value;
    }

    //public static explicit operator DataNode(DataFloat data)
    //{
    //    return new DataNode() { Name = data.name, Value = data.value };
    //}

    //public static explicit operator DataFloat(DataNode data)
    //{
    //    return new DataFloat() { name = data.Name, value = (float)data.Value };
    //}
}
