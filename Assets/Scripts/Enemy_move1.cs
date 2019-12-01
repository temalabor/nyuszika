using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move1 : MonoBehaviour
{
    public Rigidbody2D rb;

    public bool right = true;

    private Vector2 _maxLeft;

    private Vector2 _maxRight;

    private float _speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 pos = rb.transform.position;
        Vector2 max=new Vector2(4, 0);
        
        _maxLeft = pos - max;
        _maxRight = pos + max;
        _speed = 20000.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        LeftOrRight();
    }

    void FixedUpdate()
    {

        if (right)
        {
            Right();
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            Left();
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void LeftOrRight()
    {
        rb.velocity = Vector2.zero;
        Vector2 current = rb.transform.position;
        //_rb.angularVelocity = 0;
        Vector2 lor = _maxRight - current;
        if (lor.x<=0.0)
        {
            right = false;
        }

        lor = current - _maxLeft;
        if (lor.x <= 0.0)
        {
            right = true;
        }
    }

    private void Right()
    {
        
        rb.AddForce(Vector2.right * (_speed * rb.mass * Time.deltaTime));
        
    }

    private void Left()
    {
        
        rb.AddForce(Vector2.left * (_speed * rb.mass * Time.deltaTime));
    }
    
    
}
