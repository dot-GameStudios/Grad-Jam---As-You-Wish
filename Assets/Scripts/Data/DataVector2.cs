using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataVector2 : DataNode
{
    [SerializeField] private Vector2 value;
    public Vector2 Value { get { return value; } set { this.value = value; } }

    public static explicit operator Vector2(DataVector2 data)
    {
        return data.value;
    }
}
