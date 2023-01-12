using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [field: SerializeField] public float Speed { get; private set; } = 10;
    [field: SerializeField] public Vector2 Direction { get; private set; }
    [SerializeField] private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Direction = Vector2.zero;
        Direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
    }

    private void FixedUpdate()
    {
        rb.velocity = Direction * Speed;
    }
}
