using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Syrinj;

public class PlayerShipLocomotor : MonoBehaviour
{
    public float Speed = 3f;
    [Inject]
    public BoxCollider2D MoveLimits;
    [GetComponent]
    private BoxCollider2D _col;

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
            MoveLimits.bounds.min.x + _col.bounds.extents.x, 
            MoveLimits.bounds.max.x - _col.bounds.extents.x);
        
        transform.position = new Vector3(targetXpos, currentPos.y, currentPos.z);
    }
}
