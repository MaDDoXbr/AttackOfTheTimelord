using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using ScriptableObjectArchitecture;
using UnityEngine;

[CreateAssetMenu]
public class GameSO : ScriptableObject
{
    [Expandable]
    public IntVariable Lives, Score, HighScore;
    [Expandable]
    public StringVariable TopPlayer;
}
