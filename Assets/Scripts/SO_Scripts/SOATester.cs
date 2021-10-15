using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using ScriptableObjectArchitecture;
using Syrinj;
using UnityEngine;

public class SOATester : MonoBehaviour
{
    [Expandable]
    public IntVariable SOATesterValue;

    [Inject,Expandable]
    public GameSO GameData;
    
    public void DebugLogValue()
    {
        Debug.Log(SOATesterValue.Value);
        Debug.Log($"Game Data | Lives: {GameData.Lives}");
    }
}
