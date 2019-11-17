using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move2 : MonoBehaviour
{
    public Transform nyuszi;

    public bool nyusziClose = false;

    public Rigidbody2D rb;

    public float speed;

    public float maxDistance;

    private Vector2 current;

    private Vector2 nyusziCurrent;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 500.0f;
        maxDistance = 12.0f;
        current = rb.transform.position;
        nyusziCurrent = nyuszi.transform.position;
      
    }

    // Update is called once per frame
    void Update()
    {
        CheckNyusziClose();
    }

    private void FixedUpdate()
    {
        if (nyusziClose)
        {
            Vector2 dir = nyusziCurrent-current;
            dir.Normalize();
            rb.AddForce(dir*(speed*rb.mass*Time.deltaTime));
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

     
    }

    private void CheckNyusziClose()
    {
        current = rb.transform.position;
        nyusziCurrent = nyuszi.transform.position;
        if (Vector2.Distance(current, nyusziCurrent) < maxDistance)
        {
            nyusziClose = true;
        }
        else
        {
            nyusziClose = false;
        }
    }

    
    
}
