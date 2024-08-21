using System;
using System.Collections;
using UnityEngine;
using Syrinj;
using Random = UnityEngine.Random;

public class NPCLocomotor : MonoBehaviour
{
    public float Speed = 0.2f;
    [SerializeField]private float spd;

    void Start()
    {
        spd = Random.Range(Speed*0.4f, Speed)* (Random.Range(0, 2) == 1 ? 1 : -1);
    }
    
    void Update()
    {
        var currentPos = transform.position;

        float offset = (float)Math.Sin(Time.time) * spd * Time.deltaTime;
        
        var targetXpos = currentPos.x + offset;

        transform.position = new Vector3(targetXpos, currentPos.y, currentPos.z);
    }
}
