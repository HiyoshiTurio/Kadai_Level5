using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        //rb.velocity = new Vector2(h, 0);
    }
}
