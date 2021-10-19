using System.Collections;
using System.Collections.Generic;
//using Candlelight;
using UnityEngine;

[CreateAssetMenu]
public class TestSO : ScriptableObject
{
    //(typeof(RangeAttribute), 0f, 1f)] // override attribute type and its constructor args

    [SerializeField] //, PropertyBackingField]
    private float _FloatValue;

    public float FloatValue
    {
        set { _FloatValue = value; Debug.Log($"New value: {value}");}
        get { return _FloatValue; }
    }
}
