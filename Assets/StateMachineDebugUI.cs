using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Syrinj;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachineDebugUI : MonoBehaviour
{
    //[Inject,SerializeField]
    private Camera _mainCam;

    private Camera MainCam
    {
        get
        {
            if (_mainCam == null)
                _mainCam = FindObjectOfType<Camera>();
            return _mainCam;
        }
    }
    //[GetComponent]
    private StateMachine _stateMachine;

    [SerializeField]private Vector2 Offset;

    private string CurrentStateTitle = "None";

    void Awake()
    {
        _mainCam = FindObjectOfType<Camera>();
        _stateMachine = GetComponent<StateMachine>();
    }
    
    // void Start()
    // {
    //     InvokeRepeating(nameof(TimedUpdate), 0f, UpdateRate);
    // }
    
    //GetComponent<StateMachine>().nest.graph.states.OfType<IGraphNesterState>().First(s => s.isActive).nest.graph.title;
    private void Update()
    {
        foreach(IState iState in _stateMachine.nest.graph.states)//_stateMachine.nest.graph.states)
        {
            IGraphElement iGraphElement;
            IGraphElementData iGraphElementData;

            _stateMachine.nest.graph.elements.TryGetValue(iState.guid, out iGraphElement);
            _stateMachine.graphData.TryGetElementData((IGraphElementWithData)iGraphElement, out iGraphElementData);
            
            var data = (State.Data)iGraphElementData;
            
            if (data.isActive)
            {
                CurrentStateTitle = ((IGraphNester) iState).nest.graph.title;
                break;
            }
        }
    }

    void OnGUI()
    {
        if (MainCam == null)
            return;
        var position = _mainCam.WorldToScreenPoint(gameObject.transform.position);
        var textSize = GUI.skin.label.CalcSize(new GUIContent(CurrentStateTitle));
        GUI.Label(new Rect(position.x + Offset.x, Screen.height - position.y - Offset.y, textSize.x, textSize.y), CurrentStateTitle);
    }
}
