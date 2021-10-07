using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerShipLocomotor : MonoBehaviour
{
    public float Speed = 3f;
    public BoxCollider2D MoveLimits;

    void Start()
    {}

    void Update()
    {
        var hor = Input.GetAxis("Horizontal");
        if (Mathf.Abs(hor) < 0.01f)
            return;
        var currentPos = transform.position;
        transform.Translate(hor * Speed * Time.deltaTime, 0f, 0f);
        if (!MoveLimits.bounds.Contains(transform.position))
            transform.position = currentPos;
    }
}
