using System.Collections;
using System.Collections.Generic;
using Candlelight;
using UnityEngine;

[CreateAssetMenu]
public class TestSO : ScriptableObject
{
    [SerializeField, PropertyBackingField]
    //(typeof(RangeAttribute), 0f, 1f)] // override attribute type and its constructor args
     
    private float _FloatValue;
    public float FloatValue
    {
        get { return _FloatValue; }
        set { _FloatValue = value; Debug.Log($"New value: {value}");}
    }
}
