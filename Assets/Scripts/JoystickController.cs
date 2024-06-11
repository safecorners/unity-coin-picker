using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public VirtualJoystick virtualJoystick;

    private Rigidbody2D rb;
    public float moveSpeed = 5.0f;
    
    public float sensitivity = 3.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float h = virtualJoystick.Horizontal();
        
        if (h != 0)
        {
            Vector2 moveDirection = new Vector2(h, 0);
            rb.velocity = moveDirection * moveSpeed * sensitivity;
        }
    }
}
