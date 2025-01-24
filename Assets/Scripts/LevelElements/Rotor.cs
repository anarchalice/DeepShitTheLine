using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rotor : MonoBehaviour
{
    public float spinSpeed = 300f; // Speed of rotation
    public bool mustBeTriggered = false;
    public bool isTriggered = false;
    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();
        
        if (! mustBeTriggered)
            // Apply an initial angular velocity to start spinning
            rb.angularVelocity = spinSpeed;
    }

    void FixedUpdate()
    {
        // Apply a constant torque to keep spinning
        if (isTriggered||!mustBeTriggered)
            rb.AddTorque(spinSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {   
        Debug.Log(other.gameObject.name);
        isTriggered = true;
    }
}
