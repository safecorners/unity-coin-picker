using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        
        if (h != 0)
        {
            Vector2 direction = new Vector2(h, 0);
            rb.velocity = direction * speed;
        }
    }
}
