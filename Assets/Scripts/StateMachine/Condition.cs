using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Condition
{
    
    public interface IConditional
    {
        bool Evaluate();
        void Initialize(Data data_);
    }

    [Serializable]
    public class ConditionBool : IConditional
    {
        public DataBool datum;
        public bool condition;
        public enum Comparison { EQUAL, NOTEQUAL};
        public Comparison compare = Comparison.EQUAL;

        public bool Evaluate()
        {
            if (compare == Comparison.EQUAL)
            {
                return (bool)datum == condition;
            }
            else
            {
                return (bool)datum != condition;
            }
        }

        public void Initialize(Data data_)
        {
            datum = data_.Bool(datum);
        }
    }
    [Serializable]
    public class ConditionInt : IConditional
    {
        public DataInt datum;
        public int condition;
        public enum Comparison { EQUAL, NOTEQUAL, GREATER, LESS, GREATEREQUAL, LESSEQUAL };
        public Comparison compare = Comparison.EQUAL;

        public bool Evaluate()
        {

            switch (compare)
            {
                case Comparison.EQUAL:
                    return (int)datum == condition;
                case Comparison.NOTEQUAL:
                    return (int)datum != condition;
                case Comparison.GREATER:
                    return (int)datum > condition;
                case Comparison.LESS:
                    return (int)datum < condition;
                case Comparison.GREATEREQUAL:
                    return (int)datum >= condition;
                case Comparison.LESSEQUAL:
                    return (int)datum <= condition;
                default:
                    return false;
            }
        }

        public void Initialize(Data data_)
        {
            datum = data_.Int(datum);
        }
        
    }
    [Serializable]
    public class ConditionFloat : IConditional
    {
        public DataFloat datum;
        public float condition;
        public enum Comparison { EQUAL, NOTEQUAL, GREATER, LESS, GREATEREQUAL, LESSEQUAL };
        public Comparison compare = Comparison.EQUAL;

        public bool Evaluate()
        {

            switch (compare)
            {
                case Comparison.EQUAL:
                    return (float)datum == condition;
                case Comparison.NOTEQUAL:
                    return (float)datum != condition;
                case Comparison.GREATER:
                    return (float)datum > condition;
                case Comparison.LESS:
                    return (float)datum < condition;
                case Comparison.GREATEREQUAL:
                    return (float)datum >= condition;
                case Comparison.LESSEQUAL:
                    return (float)datum <= condition;
                default:
                    return false;
            }
        }

        public void Initialize(Data data_)
        {
            datum = data_.Float(datum);
        }

    }
    //[Serializable]
    //public class ConditionVector2 : IConditional
    //{
    //    public DataVector2 datum;
    //    public float condition;
    //    public enum Comparison { EQUAL, NOTEQUAL, GREATER, LESS, GREATEREQUAL, LESSEQUAL };
    //    public Comparison compare = Comparison.EQUAL;

    //    public bool Evaluate()
    //    {

    //        switch (compare)
    //        {
    //            case Comparison.EQUAL:
    //                return (float)datum == condition;
    //            case Comparison.NOTEQUAL:
    //                return (float)datum != condition;
    //            case Comparison.GREATER:
    //                return (float)datum > condition;
    //            case Comparison.LESS:
    //                return (float)datum < condition;
    //            case Comparison.GREATEREQUAL:
    //                return (float)datum >= condition;
    //            case Comparison.LESSEQUAL:
    //                return (float)datum <= condition;
    //            default:
    //                return false;
    //        }
    //    }

    //    public void Initialize(Data data_)
    //    {
    //        datum = data_.Vector2(datum);
    //    }

    //}
    public Data data;

    public List<ConditionBool> boolConditions = new List<ConditionBool>();
    public List<ConditionInt> intConditions = new List<ConditionInt>();
    public List<ConditionFloat> floatConditions = new List<ConditionFloat>();
    public DataVector2 vector2Condition;

    public void Initialize()
    {
        for(int i = boolConditions.Count - 1; i >= 0; i--)
        {
            boolConditions[i].Initialize(data);
        }

        for (int i = intConditions.Count - 1; i >= 0; i--)
        {
            intConditions[i].Initialize(data);
        }

        for (int i = floatConditions.Count - 1; i >= 0; i--)
        {
            floatConditions[i].Initialize(data);
        }

        //vector2Condition = data.Vector2(vector2Condition);
    }

    public bool Evaluate()
    {
        for (int i = boolConditions.Count - 1; i >= 0; i--)
        {
            if(boolConditions[i].Evaluate() == false)
            {
                return false;
            }
        }

        for (int i = intConditions.Count - 1; i >= 0; i--)
        {
            if (intConditions[i].Evaluate() == false)
            {
                return false;
            }
        }

        for (int i = floatConditions.Count - 1; i >= 0; i--)
        {
            if (floatConditions[i].Evaluate() == false)
            {
                return false;
            }
        }

        return true;
    }

}
