using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move4 : MonoBehaviour
{
    public Rigidbody2D rb;
    

    public float jumpTime = 3.0f;

    public bool jump = false;

    public float _speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        jump = false;
        jumpTime = 3.0f;

        _speed = 20000.0f;
        rb.mass = 10;
    }

    // Update is called once per frame
    private void Update()
    {
        if (jumpTime < 0.0f)
        {
            jump = true;
            jumpTime = 3.0f;
           
        }
        else
        {
            jump = false;
            jumpTime -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {

        if (jump)
        {
            rb.AddForce(Vector2.up *(rb.mass *_speed * Time.deltaTime));
        }
    }
}