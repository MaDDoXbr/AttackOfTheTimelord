using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using Syrinj;

public class SceneProviders : MonoBehaviour
{
    [Provides] 
    public BoxCollider2D MoveLimits; // arraste GameObject no inspector para definir

    // v== Só use atributos [Find..] em um Provider se a prioridade do script for baixa (ex.: -1020) na Unity
    // Defina em Project Settings > Script Execution Order. Coloque o SceneProviders logo após Syrinj.InjectorComponent
    [FindResourceOfType(typeof(GameSO))]
    [Provides, Expandable]   //[Singleton] cria uma instância em memória mas não copia os valores (ainda! TODO?)
    [SerializeField]private GameSO GameData;

    [Provides("PlayerShip"), SerializeField]
    private UnityEngine.GameObject PlayerShip;

    // [Provides, FindObjectOfType(typeof(Camera))] private Camera _mainCamera;
}
