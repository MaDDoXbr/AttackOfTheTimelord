using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using ScriptableObjectArchitecture;
using Syrinj;
using UnityEngine;
using UnityEngine.UI;

public class UGUIBindText : MonoBehaviour
{
    [GetComponent] private Text ThisText;
    [GetComponent] private GameEventListener gameEventListener;

    public string FormatString = "0000";
    [Expandable] //não funciona com Refs, só com Vars
    public BaseVariable Variable;

    public void Start()
    {
        //IntRef.Value = 50;
    }

    public void SetText()
    {
        //Debug.Log("Trying");
        var IntVar = Variable as IntVariable;
        var FloatVar = Variable as IntVariable;
        var StringVar = Variable as StringVariable;
        if (IntVar)
            ThisText.text = IntVar.Value.ToString(FormatString);
        else if (FloatVar)
            ThisText.text = FloatVar.Value.ToString(FormatString);
        else if (StringVar)
            ThisText.text = StringVar.Value;
    }
}
