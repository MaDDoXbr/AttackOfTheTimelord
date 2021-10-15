using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class TestSO_tester : MonoBehaviour
{
    [Expandable]
    public TestSO Variable;

    void Start()
    {
        Debug.Log(Variable.FloatValue);
    }
}
