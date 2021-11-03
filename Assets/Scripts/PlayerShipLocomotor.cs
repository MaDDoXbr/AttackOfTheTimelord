using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Syrinj;
using UnityEngine.Serialization;

public class PlayerShipLocomotor : MonoBehaviour
{
    public float Speed = 3f;
    [Inject]
    public BoxCollider2D MoveLimits;
    [FormerlySerializedAs("_col")] [GetComponent]
    public BoxCollider2D Col;

    void Start()
    {
        //Debug.Log($"Bounds min/max: {MoveLimits.bounds.min.x}, {MoveLimits.bounds.max.x}");
    }

    void Update()
    {
        var hor = Input.GetAxis("Horizontal");
        if (Mathf.Abs(hor) < 0.01f)
            return;
        var currentPos = transform.position;
        var offset = hor * Speed * Time.deltaTime;
        var targetXpos = currentPos.x + offset;

        targetXpos = Mathf.Clamp(targetXpos,
            MoveLimits.bounds.min.x + Col.bounds.extents.x, 
            MoveLimits.bounds.max.x - Col.bounds.extents.x);
        
        transform.position = new Vector3(targetXpos, currentPos.y, currentPos.z);
    }
}
